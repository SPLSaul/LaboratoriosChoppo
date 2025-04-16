using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoriosChoppo
{
    public interface IGeneradorFactura
    {
        void Generar(Dictionary<string, object> datosEmisor, Dictionary<string,string> datosReceptor);
    }
    public interface IFormatoArchivo
    {
        void Guardar(string contenido, string ruta);
    }
}
