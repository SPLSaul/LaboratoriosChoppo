using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoriosChoppo
{
    public class GeneradorFacturas : GeneradorFacturaBase
    {
        public GeneradorFacturas(IFormatoArchivo formatoArchivo) : base(formatoArchivo)
        {
        }
        public override void Generar(Dictionary<string, string> datosEmisor, Dictionary<string, string> datosReceptor)
        {
            StringBuilder contenido = new StringBuilder();

            // Encabezado
            contenido.AppendLine("FACTURA ELECTRÓNICA CFDI 4.0 - SAT");
            contenido.AppendLine(new string('=', 50));
            contenido.AppendLine($"Fecha y hora de generación: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            contenido.AppendLine($"Folio fiscal: {Guid.NewGuid()}");
            contenido.AppendLine();

            // Datos del Emisor (formato alineado)
            contenido.AppendLine("EMISOR:");
            contenido.AppendLine(new string('-', 50));
            contenido.AppendLine($"RFC:            {ObtenerValor(datosEmisor, "rfc", "N/A")}");
            contenido.AppendLine($"Nombre:         {ObtenerValor(datosEmisor, "razonSocial", "N/A")}");
            contenido.AppendLine($"Regimen Fiscal: {ObtenerValor(datosEmisor, "regimen", "N/A")}");
            contenido.AppendLine($"Domicilio:      {ObtenerValor(datosEmisor, "domicilio", "N/A")}");
            contenido.AppendLine($"Lugar Exped.:   {ObtenerValor(datosEmisor, "expedicion", "N/A")}");
            contenido.AppendLine();

            // Datos del Receptor
            contenido.AppendLine("RECEPTOR:");
            contenido.AppendLine(new string('-', 50));
            contenido.AppendLine($"RFC:            {ObtenerValor(datosReceptor, "rfc", "N/A")}");
            contenido.AppendLine($"Nombre:         {ObtenerValor(datosReceptor, "razonSocial", "N/A")}");
            contenido.AppendLine($"Uso CFDI:       {ObtenerValor(datosReceptor, "usoCFDI", "N/A")}");
            contenido.AppendLine($"Domicilio:      {ObtenerValor(datosReceptor, "domicilio", "No especificado")}");
            contenido.AppendLine();

            // Datos de la Factura
            contenido.AppendLine("DETALLES DE LA FACTURA:");
            contenido.AppendLine(new string('-', 50));
            contenido.AppendLine("Conceptos:");
            contenido.AppendLine($"  - Servicios profesionales (1 unidad)      $1,000.00");
            contenido.AppendLine();
            contenido.AppendLine("Subtotal:                                $1,000.00");
            contenido.AppendLine("IVA (16%):                                $160.00");
            contenido.AppendLine("Total:                                  $1,160.00");
            contenido.AppendLine();
            contenido.AppendLine($"Forma de pago: 01 - Efectivo");
            contenido.AppendLine($"Método de pago: PUE - Pago en una sola exhibición");
            contenido.AppendLine();
            contenido.AppendLine("Sello Digital SAT:");
            contenido.AppendLine(new string('~', 50));
            contenido.AppendLine("Este documento es una representación impresa de un CFDI");

            string nombreArchivo = $"Factura_{ObtenerValor(datosEmisor, "rfc", "Generic")}_{DateTime.Now:yyyyMMddHHmmss}.txt";
            formatoArchivo.Guardar(contenido.ToString(), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo));
        }
        private string ObtenerValor(Dictionary<string, string> diccionario, string clave, string valorPredeterminado)
        {
            if (diccionario.ContainsKey(clave))
                return diccionario[clave];
            return valorPredeterminado;
        }
    }
}
