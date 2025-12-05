using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string BuscarDNI(string dni)
        {
            return DatObjetivo.Instancia.BuscarDNI(dni);
        }
        public DataTable Listar(string dni)
        {
            return DatObjetivo.Instancia.Listar(dni);
        }
        public List<EntObjetivo> ListarMusculos()
        {
            return DatObjetivo.Instancia.ListarMusculos();
        }
        public bool InsertarObjetivo(EntObjetivo obj)
        {
            return DatObjetivo.Instancia.InsertarObjetivo(obj);
        }
        public bool EditarObjetivo(EntObjetivo obj)
        {
            return DatObjetivo.Instancia.EditarObjetivo(obj);
        }
        public bool EliminarObjetivo(string dni, int idMusculo)
        {
            return DatObjetivo.Instancia.EliminarObjetivo(dni, idMusculo);
        }
        #endregion
    }
}
