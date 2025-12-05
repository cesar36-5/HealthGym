using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntPlanNutricional
    {
        public int? Id { get; set; }
        public int IdMiembro {  get; set; }
        public DateTime? FechaFin {  get; set; }
    }
}
