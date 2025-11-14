using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;    
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogEnfermedad
    {
        #region singleton
        private static readonly LogEnfermedad _instancia = new LogEnfermedad();
        public static LogEnfermedad Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region metodos

        public List<EntEnfermedad> ListarEnfermedad()
        {
            return DatEnfermedad.Instancia.ListarEnfermedad();
        }

        public void InsertarEnfermedad(EntEnfermedad enf)
        {
            if (string.IsNullOrWhiteSpace(enf.Nombre))
                throw new Exception("Debe llenar el nombre.");

            var lista = DatEnfermedad.Instancia.ListarEnfermedad();

            bool existe = lista.Any(x =>
                x.Nombre.Equals(enf.Nombre, StringComparison.OrdinalIgnoreCase)
            );

            if (existe)
                throw new Exception("Ya existe una enfermedad con ese nombre.");

            bool ok = DatEnfermedad.Instancia.InsertarEnfermedad(enf);
            if (!ok)
                throw new Exception("No se pudo insertar la enfermedad.");
        }


        public void EditarEnfermedad(EntEnfermedad enf)
        {
            if (string.IsNullOrWhiteSpace(enf.Nombre))
                throw new Exception("Debe llenar el nombre.");

            var lista = DatEnfermedad.Instancia.ListarEnfermedad();

            bool existeOtro = lista.Any(x =>
                x.Nombre.Equals(enf.Nombre, StringComparison.OrdinalIgnoreCase)
                && x.Id != enf.Id
            );

            if (existeOtro)
                throw new Exception("Ya existe otra enfermedad con ese nombre.");

            bool ok = DatEnfermedad.Instancia.EditarEnfermedad(enf);

            if (!ok)
                throw new Exception("No se pudo editar la enfermedad.");
        }


        #endregion
    }
}
