using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntDetallePlan
    {
        public int IdPlan {  get; set; }
        public int IdPlatillo { get; set; }
        public int Dia {  get; set; }
        public int Momento { get; set; }
    }
}
