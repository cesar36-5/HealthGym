using CapaDatos;
using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogEnfermedad
    {
        #region Singleton
        private static readonly LogEnfermedad _instancia = new LogEnfermedad();
        public static LogEnfermedad Instancia => _instancia;
        #endregion
        #region 

        public List<EntEnfermedad> Listar()
        {
            return DatEnfermedad.Instancia.ListarEnfermedad();
        }

        public List<EntEnfermedad> ListarEnfermedadesPorMusculo(int idMusculo)
        {
            return DatEnfermedad.Instancia.ListarEnfermedadesPorMusculo(idMusculo);
        }

        public bool Agregar(EntEnfermedad e)
        {
            return DatEnfermedad.Instancia.AgregarEnfermedad(e);
        }
        public bool ExisteNombre(string nombre, int idIgnorado)
        {
            return DatEnfermedad.Instancia.ExisteNombreEnfermedad(nombre, idIgnorado);
        }
        public bool Editar(EntEnfermedad e)
        {
            return DatEnfermedad.Instancia.EditarEnfermedad(e);
        }

        public bool AgregarMusculo(EntEnfermedad e)
        {
            return DatEnfermedad.Instancia.AgregarEnfermedadMusculo(e);
        }

        public bool EliminarMusculo(EntEnfermedad e)
        {
            return DatEnfermedad.Instancia.EliminarEnfermedadMusculo(e);
        }

        #endregion
    }
}


