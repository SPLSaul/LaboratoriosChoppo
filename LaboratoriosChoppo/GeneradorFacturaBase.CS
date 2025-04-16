using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoriosChoppo
{
    public abstract class GeneradorFacturaBase
    {
        protected IFormatoArchivo formatoArchivo;

        protected GeneradorFacturaBase(IFormatoArchivo formatoArchivo)
        {
            this.formatoArchivo = formatoArchivo;
        }
        public abstract void Generar(Dictionary<string, string> datosEmisor, Dictionary<string, string> datosReceptor);
    }
}
