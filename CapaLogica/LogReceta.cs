using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogReceta
    {
        #region
        private static readonly LogReceta _instancia = new LogReceta();
        public static LogReceta instancia
        {
            get { return _instancia; }
        }
        #endregion

        public int BuscarReceta(string dni)
        {
            return DatReceta.instancia.ObtenerReceta(dni);
        }

        public List<EntDetalleReceta> BuscarDetalles(int id)
        {
            return DatReceta.instancia.CargarDetalles(id);
        }
    }
}
