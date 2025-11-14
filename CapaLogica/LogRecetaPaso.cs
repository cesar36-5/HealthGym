using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogRecetaPaso
    {
        #region Singleton

        public static readonly LogRecetaPaso _instancia = new LogRecetaPaso();

        public static LogRecetaPaso Instancia { get { return _instancia; } }

        #endregion Singleton

        public List<EntRecetaPaso> CargarPasosDe(EntAlimento a)
        {
            return DatRecetaPaso.Instancia.CargarPasosDe(a.Id);
        }

        public bool AgregarPaso(EntRecetaPaso a)
        {
            return DatRecetaPaso.Instancia.AgregarPaso(a);
        }

        public bool EditarPaso(EntRecetaPaso a)
        {
            return DatRecetaPaso.Instancia.EdtarPaso(a);
        }
    }
}
