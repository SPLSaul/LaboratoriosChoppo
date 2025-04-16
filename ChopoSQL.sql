use Choppo;

CREATE TABLE ESTUDIOS (
    id_Estudio INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    estudio_nombre VARCHAR(100) NOT NULL,
    precio INT NOT NULL
);

INSERT INTO ESTUDIOS (estudio_nombre, precio) VALUES 
('Check Up Preventivo', 1500),
('Check Up Preventivo + Radiografia', 2500),
('Check Up Preventivo + MRI', 4500);


select * from COMPRA;

CREATE TABLE COMPRA(
    id_compra int not null primary key IDENTITY(1,1),
    id_Estudio int not null,
    cantidad int not null,
    FOREIGN KEY (id_Estudio) REFERENCES ESTUDIOS(id_Estudio)
);

CREATE TABLE FACTURA (
    id_factura INT NOT NULL PRIMARY KEY identity(1,1),
    fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    id_cliente INT,  -- Si tienes tabla de clientes
    subtotal DECIMAL(10,2) NOT NULL,
    iva DECIMAL(10,2) NOT NULL,
    total DECIMAL(10,2) NOT NULL,
);


CREATE TABLE DETALLE_FACTURA (
    id_detalle INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_factura INT NOT NULL,
    id_compra INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10,2) NOT NULL,
    importe DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_factura) REFERENCES FACTURA(id_factura),
    FOREIGN KEY (id_compra) REFERENCES COMPRA(id_compra)
);

CREATE INDEX idx_factura_cliente ON factura(id_cliente);
CREATE INDEX idx_detalle_factura ON detalle_factura(id_factura);


SELECT * FROM VistaAdministradorPagos

CREATE VIEW VistaAdministradorPagos AS
SELECT 
    E.estudio_nombre,
    DF.cantidad AS cantidad_estudios,
    DF.precio_unitario,
    DF.importe AS importe_parcial,
    F.id_factura,
    F.fecha,
    F.subtotal,
    F.iva,
    F.total,
    C.id_compra,
    CASE 
        WHEN ABS(F.total - (SELECT SUM(importe) FROM DETALLE_FACTURA WHERE id_factura = F.id_factura) * 1.16) < 0.01
        THEN 'Correcto' 
        ELSE 'Revisar' 
    END AS estado_calculo
FROM 
    FACTURA F
JOIN 
    DETALLE_FACTURA DF ON F.id_factura = DF.id_factura
JOIN 
    COMPRA C ON DF.id_compra = C.id_compra
JOIN 
    ESTUDIOS E ON C.id_Estudio = E.id_Estudio;

alter table FACTURA drop column id_cliente;
EXEC AGREGAR_COMPRA @id_Estudio = 1, @cantidad = 2;

SELECT * FROM COMPRA;

GO
CREATE PROCEDURE AGREGAR_COMPRA 
@id_Estudio INT,
@cantidad int
AS 
BEGIN 
    SET NOCOUNT ON;
    DECLARE @subtotal DECIMAL(10,2);
    DECLARE @iva DECIMAL(10,2);
    DECLARE @total DECIMAL(10,2);
    DECLARE @precio_unitario DECIMAL(10,2);
    DECLARE @id_compra INT;
    DECLARE @id_factura INT;
    
    BEGIN TRANSACTION;

    BEGIN TRY
        SELECT @precio_unitario = precio
        FROM ESTUDIOS
        WHERE id_Estudio = @id_Estudio;

        INSERT INTO COMPRA(id_Estudio,cantidad)
        VALUES (@id_Estudio,@cantidad);

        SET @id_compra =SCOPE_IDENTITY();

        SET @subtotal = (@precio_unitario * @cantidad);
        SET @iva = @subtotal * 0.16;
        SET @total = @subtotal + @iva;

        INSERT INTO FACTURA(subtotal,iva,total)
        VALUES (@subtotal,@iva,@total);

        SET @id_factura = SCOPE_IDENTITY();

        INSERT INTO DETALLE_FACTURA(id_factura,id_compra,cantidad,precio_unitario,importe)
        VALUES (@id_factura,@id_compra,@cantidad,@precio_unitario,@subtotal);

        COMMIT TRANSACTION;

        SELECT @id_factura as id_factura_generada;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMeesage;
    END CATCH;
END;
GO
