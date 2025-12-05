using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogMonitoreo
    {
        #region Singleton
        private static readonly LogMonitoreo _instancia = new LogMonitoreo();
        public static LogMonitoreo Instancia => _instancia;
        #endregion

        public EntMonitoreo BuscarMonitoreoReciente(int id)
        {
            return DatMonitoreo.Instancia.ObtenerMonitoreoReciente(id);
        }

        public string CalcularCalificacion(int mus, int mie, decimal tam)
        {
            return DatMonitoreo.Instancia.EvaluarObjetivoMusculo(mus, mie, tam);
        }

        public bool InsertarMonitoreo(int id, EntMonitoreo obj)
        {
            return DatMonitoreo.Instancia.InsertarMonitoreo(id, obj);
        }
    }
}
