using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntRecetaMaterial
    {
        public int Id { get; set; }
        public int Alimento { get; set; }
        public string Material { get; set; }
        public decimal Cantidad { get; set; }
        public string Medida { get; set; }
    }
}
