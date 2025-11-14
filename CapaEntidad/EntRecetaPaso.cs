using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntRecetaPaso
    {
        public int Id { get; set; }
        public int Alimento { get; set; }
        public int Paso { get; set; }
        public string Instruccion { get; set; }
    }
}
