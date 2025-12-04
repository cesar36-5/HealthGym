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
    public class DatEnfermedad
    {
        #region Singleton
        private static readonly DatEnfermedad _instancia = new DatEnfermedad();
        public static DatEnfermedad Instancia => _instancia;
        #endregion

        #region 
        public List<EntEnfermedad> ListarEnfermedad()
        {
            List<EntEnfermedad> lista = new List<EntEnfermedad>();

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("sp_ListarEnfermedad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new EntEnfermedad
                    {
                        IdEnfermedad = Convert.ToInt32(dr["IdEnfermedad"]),
                        Nombre = dr["Nombre"].ToString()
                    });
                }
            }

            return lista;
        }

        // AGREGAR ENFERMEDAD
        public bool AgregarEnfermedad(EntEnfermedad e)
        {
            SqlCommand cmd = null;
            bool ok = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_AñadirEnfermedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", e.Nombre);

                cn.Open();
                ok = cmd.ExecuteNonQuery() > 0;
            }
            finally { cmd.Connection.Close(); }

            return ok;
        }
        public bool ExisteNombreEnfermedad(string nombre, int idIgnorado)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                string query = "SELECT COUNT(*) FROM Enfermedad WHERE Nombre = @nombre AND IdEnfermedad != @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@id", idIgnorado);
                cn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }


        // EDITAR ENFERMEDAD
        public bool EditarEnfermedad(EntEnfermedad e)
        {
            SqlCommand cmd = null;
            bool ok = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_EditarEnfermedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdEnfermedad", e.IdEnfermedad);
                cmd.Parameters.AddWithValue("@Nombre", e.Nombre);

                cn.Open();
                ok = cmd.ExecuteNonQuery() > 0;
            }
            finally { cmd.Connection.Close(); }

            return ok;
        }
        //Listar músculos afectados por enfermedad
        public List<EntEnfermedad> ListarEnfermedadesPorMusculo(int idMusculo)
        {
            List<EntEnfermedad> lista = new List<EntEnfermedad>();
            SqlCommand cmd = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_ListarEnfermedadesPorMusculo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdMusculo", idMusculo);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new EntEnfermedad
                    {
                        IdEnfermedad = Convert.ToInt32(dr["IdEnfermedad"]),
                        Nombre = dr["Nombre"].ToString()
                    });
                }
            }
            finally
            {
                if (cmd != null) cmd.Connection.Close();
            }

            return lista;
        }


        // AGREGAR MÚSCULO AFECTADO
        public bool AgregarEnfermedadMusculo(EntEnfermedad e)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();

                // VALIDAR DUPLICADO
                using (SqlCommand check = new SqlCommand(
                    "SELECT COUNT(*) FROM EnfermedadMusculo WHERE IdEnfermedad=@idE AND IdMusculo=@idM", cn))
                {
                    check.Parameters.AddWithValue("@idE", e.IdEnfermedad);
                    check.Parameters.AddWithValue("@idM", e.IdMusculo);

                    int count = (int)check.ExecuteScalar();
                    if (count > 0) return false;
                }

                // INSERTAR
                using (SqlCommand cmd = new SqlCommand("sp_AñadirEnfermedadMusculo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdEnfermedad", e.IdEnfermedad);
                    cmd.Parameters.AddWithValue("@IdMusculo", e.IdMusculo);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ELIMINAR UN MÚSCULO ASOCIADO
        public bool EliminarEnfermedadMusculo(EntEnfermedad e)
        {
            SqlCommand cmd = null;
            bool ok = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_EliminarEnfermedadMusculo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdEnfermedad", e.IdEnfermedad);
                cmd.Parameters.AddWithValue("@IdMusculo", e.IdMusculo);

                cn.Open();
                ok = cmd.ExecuteNonQuery() > 0;
            }
            finally { cmd.Connection.Close(); }

            return ok;
        }

        #endregion
    }
}

