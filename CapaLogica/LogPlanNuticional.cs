using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogPlanNuticional
    {
        #region Singleton
        private static readonly DatPlanNutricional _instancia = new DatPlanNutricional();
        public static DatPlanNutricional Instancia
        {
            get { return _instancia; }
        }
        #endregion

        public int CrearPlan(string dni)
        {
            return DatPlanNutricional.Instancia.CrearPlan(dni);
        }

        public bool InsertarDetalles(List<EntDetallePlan> lista)
        {
            return DatPlanNutricional.Instancia.InsertarDetallesPlan(lista);
        }

        public List<EntPlanNutricional> ListarPlanesDNI(string dni)
        {
            return DatPlanNutricional.Instancia.ListarPlanesPorDNI(dni);
        }

        public List<EntDetallePlan> ListarDetalles(int id)
        {
            return DatPlanNutricional.Instancia.ListarPlanDetallePorIdPlan(id);
        }
    }
}
