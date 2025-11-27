using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntPlatillo
    {
        public int IdPlatillo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public double Calorias { get; set; }
        public double Carbohidratos { get; set; }
        public double Grasas { get; set; }
        public double Proteinas { get; set; }
    }
}
