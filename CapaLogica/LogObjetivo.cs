using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaLogica
{
    public class LogObjetivo
    {
        #region Singleton
        private static readonly LogObjetivo _instancia = new LogObjetivo();
        public static LogObjetivo Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region Métodos
        
        #endregion
    }
}
