CREATE TABLE CLIENTES (
    id_cliente INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE,
    telefono VARCHAR(20),
    rfc VARCHAR(20),  -- For Mexican tax compliance
    fecha_registro DATETIME DEFAULT GETDATE(),
    activo BIT DEFAULT 1
);


CREATE TABLE ESTUDIOS (
    id_estudio INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(255),
    precio DECIMAL(10,2) NOT NULL,  -- No more INT money, you savage
    duracion_min INT,  -- How long the study takes
    requiere_ayuno BIT DEFAULT 0,  -- Medical requirement
    fecha_registro DATETIME DEFAULT GETDATE(),
    activo BIT DEFAULT 1
);

INSERT INTO ESTUDIOS (nombre, descripcion, precio, duracion_min, requiere_ayuno) VALUES 
('Check Up Preventivo', 'Incluye análisis básicos', 1500, 30, 1),
('Check Up Preventivo + Radiografia', 'Análisis + radiografía de tórax', 2500, 45, 1),
('Check Up Preventivo + MRI', 'Análisis + resonancia magnética', 4500, 90, 1);


select * from COMPRAS;

CREATE TABLE COMPRAS (
    id_compra INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL FOREIGN KEY REFERENCES CLIENTES(id_cliente),
    id_estudio INT NOT NULL FOREIGN KEY REFERENCES ESTUDIOS(id_estudio),
    cantidad INT NOT NULL CHECK (cantidad > 0),
    fecha_compra DATETIME DEFAULT GETDATE(),
    usuario_registro VARCHAR(50),  -- Who logged this?
    estado VARCHAR(20) DEFAULT 'ACTIVO' CHECK (estado IN ('ACTIVO', 'CANCELADO', 'REEMBOLSADO')),
    notas VARCHAR(255)  -- For refund reasons, etc.
);

CREATE TABLE FACTURAS (
    id_factura INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL FOREIGN KEY REFERENCES CLIENTES(id_cliente),
    fecha_creacion DATETIME DEFAULT GETDATE(),
    subtotal DECIMAL(10,2) NOT NULL,
    iva DECIMAL(10,2) NOT NULL,
    descuento DECIMAL(10,2) DEFAULT 0,
    total DECIMAL(10,2) NOT NULL,
    metodo_pago VARCHAR(20) CHECK (metodo_pago IN ('EFECTIVO', 'TARJETA', 'TRANSFERENCIA', 'CREDITO')),
    estado_pago VARCHAR(20) DEFAULT 'PENDIENTE' CHECK (estado_pago IN ('PAGADO', 'PENDIENTE', 'CANCELADO')),
    referencia_pago VARCHAR(50),  -- Transaction ID, etc.
    notas VARCHAR(255)  -- Any special notes
);

CREATE TABLE DETALLE_FACTURA (
    id_detalle INT PRIMARY KEY IDENTITY(1,1),
    id_factura INT NOT NULL FOREIGN KEY REFERENCES FACTURAS(id_factura),
    id_compra INT NOT NULL FOREIGN KEY REFERENCES COMPRAS(id_compra),
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10,2) NOT NULL,
    descuento DECIMAL(5,2) DEFAULT 0,
    importe DECIMAL(10,2) NOT NULL,
    notas VARCHAR(255)  -- Why was this discounted? etc.
);

CREATE TABLE CONFIGURACION (
    id_config INT PRIMARY KEY IDENTITY(1,1),
    clave VARCHAR(50) UNIQUE NOT NULL,
    valor VARCHAR(255) NOT NULL,
    descripcion VARCHAR(255)
);

-- Insert default configs
INSERT INTO CONFIGURACION (clave, valor, descripcion) VALUES
('IVA_PORCENTAJE', '0.16', 'Impuesto al Valor Agregado (16%)'),
('MONEDA', 'MXN', 'Moneda predeterminada'),
('DIAS_VALIDEZ_FACTURA', '30', 'Días antes de que una factura expire');

CREATE PROCEDURE sp_AgregarCompraYFactura
    @id_cliente INT,
    @id_estudio INT,
    @cantidad INT,
    @metodo_pago VARCHAR(20) = NULL,
    @descuento DECIMAL(5,2) = 0,
    @notas VARCHAR(255) = NULL,
    @id_factura_existente INT = NULL  -- Optional: Add to existing invoice
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @precio DECIMAL(10,2);
    DECLARE @subtotal DECIMAL(10,2);
    DECLARE @iva DECIMAL(10,2);
    DECLARE @total DECIMAL(10,2);
    DECLARE @tasa_iva DECIMAL(5,2);
    DECLARE @id_compra INT;
    DECLARE @id_factura INT;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Get study price
        SELECT @precio = precio 
        FROM ESTUDIOS 
        WHERE id_estudio = @id_estudio AND activo = 1;
        
        IF @precio IS NULL
            RAISERROR('ESTUDIO_NO_ENCONTRADO', 16, 1);
        
        -- Get current IVA rate
        SELECT @tasa_iva = CAST(valor AS DECIMAL(5,2))
        FROM CONFIGURACION 
        WHERE clave = 'IVA_PORCENTAJE';
        
        -- Add purchase record
        INSERT INTO COMPRAS (id_cliente, id_estudio, cantidad, usuario_registro, notas)
        VALUES (@id_cliente, @id_estudio, @cantidad, SYSTEM_USER, @notas);
        
        SET @id_compra = SCOPE_IDENTITY();
        
        -- Calculate amounts
        SET @subtotal = (@precio * @cantidad) - @descuento;
        SET @iva = @subtotal * @tasa_iva;
        SET @total = @subtotal + @iva;
        
        -- Handle invoice (new or existing)
        IF @id_factura_existente IS NULL
        BEGIN
            INSERT INTO FACTURAS (id_cliente, subtotal, iva, descuento, total, metodo_pago)
            VALUES (@id_cliente, @subtotal, @iva, @descuento, @total, @metodo_pago);
            
            SET @id_factura = SCOPE_IDENTITY();
        END
        ELSE
        BEGIN
            SET @id_factura = @id_factura_existente;
            
            -- Update existing invoice
            UPDATE FACTURAS 
            SET 
                subtotal = subtotal + @subtotal,
                iva = iva + @iva,
                descuento = descuento + @descuento,
                total = total + @total
            WHERE id_factura = @id_factura;
        END
        
        -- Add invoice detail
        INSERT INTO DETALLE_FACTURA (id_factura, id_compra, cantidad, precio_unitario, descuento, importe)
        VALUES (@id_factura, @id_compra, @cantidad, @precio, @descuento, @subtotal);
        
        COMMIT TRANSACTION;
        
        -- Return success + invoice ID
        SELECT 
            'SUCCESS' AS status,
            @id_factura AS id_factura,
            @total AS total;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        
        -- Return structured error
        SELECT 
            'ERROR' AS status,
            ERROR_NUMBER() AS error_code,
            ERROR_MESSAGE() AS error_message;
    END CATCH;
END;

CREATE VIEW vw_ReporteFacturas AS
SELECT 
    F.id_factura,
    F.fecha_creacion,
    C.nombre AS cliente,
    E.nombre AS estudio,
    DF.cantidad,
    DF.precio_unitario,
    DF.descuento,
    DF.importe,
    F.subtotal,
    F.iva,
    F.total,
    F.metodo_pago,
    F.estado_pago,
    CASE 
        WHEN F.estado_pago = 'PAGADO' THEN '✅ PAGADO'
        WHEN F.estado_pago = 'PENDIENTE' AND F.fecha_creacion < DATEADD(DAY, -30, GETDATE()) THEN '⚠ VENCIDO'
        ELSE '⌛ PENDIENTE'
    END AS estado_visual
FROM 
    FACTURAS F
JOIN 
    CLIENTES C ON F.id_cliente = C.id_cliente
JOIN 
    DETALLE_FACTURA DF ON F.id_factura = DF.id_factura
JOIN 
    COMPRAS CO ON DF.id_compra = CO.id_compra
JOIN 
    ESTUDIOS E ON CO.id_estudio = E.id_estudio;
-- Faster client lookups
CREATE INDEX idx_clientes_nombre ON CLIENTES(nombre);
CREATE INDEX idx_clientes_rfc ON CLIENTES(rfc);

-- Faster invoice filtering
CREATE INDEX idx_facturas_fecha ON FACTURAS(fecha_creacion);
CREATE INDEX idx_facturas_estado ON FACTURAS(estado_pago);

-- Faster study searches
CREATE INDEX idx_estudios_nombre ON ESTUDIOS(nombre);
CREATE INDEX idx_estudios_activo ON ESTUDIOS(activo);






INSERT INTO CLIENTES (nombre, email, telefono, rfc)
VALUES 
('Juan Pérez', 'juan.perez@example.com', '6641234567', 'JUAP800101XYZ'),
('María López', 'maria.lopez@example.com', '6647654321', 'MALM850202ABC'),
('Carlos Gómez', 'carlos.gomez@example.com', '6645551234', 'CAGO900303DEF'),
('Ana Torres', 'ana.torres@example.com', '6648889988', 'ANTO950404GHI'),
('Luis Ramírez', 'luis.ramirez@example.com', '6642223344', 'LURA960505JKL');
