using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogAlergia
    {
        #region singleton
        private static readonly LogAlergia _instancia = new LogAlergia();
        public static LogAlergia Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region metodos
        public List<EntAlergia> ListarAlergia()
        {
            return DatAlergia.Instancia.ListarAlergia();
        }

        public void InsertarAlergia(EntAlergia aler)
        {
            if (string.IsNullOrWhiteSpace(aler.Nombre))
                throw new Exception("Debe llenar el nombre.");
            var lista = DatAlergia.Instancia.ListarAlergia();
            bool existe = lista.Any(x =>
                x.Nombre.Equals(aler.Nombre, StringComparison.OrdinalIgnoreCase)
            );
            if (existe)
                throw new Exception("Ya existe una alergia con ese nombre.");
            bool ok = DatAlergia.Instancia.InsertarAlergia(aler);
            if (!ok)
                throw new Exception("No se pudo insertar la alergia.");
        }

        public void EditarAlergia(EntAlergia aler)
        {
            if (string.IsNullOrWhiteSpace(aler.Nombre))
                throw new Exception("Debe llenar el nombre.");
            var lista = DatAlergia.Instancia.ListarAlergia();
            bool existeOtro = lista.Any(x =>
                x.Nombre.Equals(aler.Nombre, StringComparison.OrdinalIgnoreCase)
                && x.Id != aler.Id
            );
            if (existeOtro)
                throw new Exception("Ya existe otra alergia con ese nombre.");
            bool ok = DatAlergia.Instancia.EditarAlergia(aler);
            if (!ok)
                throw new Exception("No se pudo editar la alergia.");
        }
    }
    #endregion
}
