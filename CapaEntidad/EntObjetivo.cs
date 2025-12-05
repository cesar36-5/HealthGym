using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntObjetivo
    {
        public int IdMiembro {get;set;}
        public int IdMusculo { get; set; }
        public decimal Tamano { get; set; }

        public string NombreMusculo { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
    }
}
