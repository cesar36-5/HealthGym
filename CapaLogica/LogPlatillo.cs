using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaLogica
{
    public class LogPlatillo
    {
        #region Singleton
        private static readonly LogPlatillo _instancia = new LogPlatillo();
        public static LogPlatillo Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region
        public List<EntPlatillo> ListarPlatillo()
        {
            return DatPlatillo.Instancia.ListarPlatillo();
        }
        public bool InserPlatillo(EntPlatillo plat)
        {
            return DatPlatillo.Instancia.InsertarPlatillo(plat);
        }
        public bool EditAli(EntPlatillo plat)
        {
            return DatPlatillo.Instancia.EditarPlatillo(plat);
        }
        #endregion
    }
}
