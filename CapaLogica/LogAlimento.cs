using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogAlimento
    {
        #region Singleton

        public static readonly LogAlimento _instancia = new LogAlimento();

        public static LogAlimento Instancia
        {
            get { return _instancia; }
        }

        #endregion Singleton

        public List<EntAlimento> CargarAlimentos()
        {
            return DatAlimento.Instancia.CargarAlimentos();
        }
    }
}
