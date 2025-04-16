using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoriosChoppo
{
    public class Estudios
    {
        private int id_estudio;
        private int cantidad;

        public Estudios(int id_estudio, int cantidad )
        {
            this.id_estudio = id_estudio;
            this.cantidad = cantidad;
        }
        public int id_estudio1 { get => id_estudio; set => id_estudio = value; }
        public int cantidad1 { get => cantidad; set => cantidad = value; }
    }
}
