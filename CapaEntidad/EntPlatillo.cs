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
        public int Calorias { get; set; }
        public decimal Carbohidratos { get; set; }
        public decimal Grasas { get; set; }
        public decimal Proteinas { get; set; }
    }
}
