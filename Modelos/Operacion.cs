using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachProject.Modelos
{
    public class Operacion
    {
        public int tiempo { get; set; }
        public string operacion { get; set; }
        public double resultado { get; set; }

        public Operacion(int tiempo =0, string operacion = "", double resultado = 0)
        {
            this.tiempo = tiempo;
            this.operacion = operacion;
            this.resultado = resultado;
        }
    }
}
