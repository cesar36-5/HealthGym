using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogMiembro
    {
        #region
        private static readonly LogMiembro _instancia = new LogMiembro();
        public static LogMiembro instancia
        {
            get { return _instancia; }
        }
        #endregion

        public EntMiembro BuscarMiembro(string dni)
        {
            return DatMiembro.Instancia.BuscarMiembroPorDNI(dni);
        }
    }
}
