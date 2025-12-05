using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatObjetivo
    {
        #region Singleton
        private static readonly DatObjetivo _instancia = new DatObjetivo();
        public static DatObjetivo Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region Métodos
        
        #endregion
    }
}
