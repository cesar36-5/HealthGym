using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntAlimento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Carbohidratos { get; set; }
        public decimal Proteinas { get; set; }
        public decimal Grasas { get; set; }
        public int Calorias { get; set; }
    }
}
