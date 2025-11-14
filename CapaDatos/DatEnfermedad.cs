using System;
using System.Collections.Generic;
using System.Data;
using CapaEntidad;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatEnfermedad
    {
        #region singleton
        private static readonly DatEnfermedad _instancia = new DatEnfermedad();
        public static DatEnfermedad Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region metodos

        // LISTAR
        public List<EntEnfermedad> ListarEnfermedad()
        {
            SqlCommand cmd = null;
            List<EntEnfermedad> lista = new List<EntEnfermedad>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarEnfermedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EntEnfermedad enf = new EntEnfermedad();
                    enf.Id = Convert.ToInt32(dr["Id"]);
                    enf.Nombre = dr["Nombre"].ToString();
                    lista.Add(enf);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return lista;
        }

        // INSERTAR
        public bool InsertarEnfermedad(EntEnfermedad enf)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarEnfermedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", enf.Nombre);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) inserta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return inserta;
        }

        // EDITAR
        public bool EditarEnfermedad(EntEnfermedad enf)
        {
            SqlCommand cmd = null;
            bool edita = false;


            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarEnfermedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", enf.Id);
                cmd.Parameters.AddWithValue("@Nombre", enf.Nombre);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) edita = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null && cmd.Connection != null)
                    cmd.Connection.Close();
            }

            return edita;
        }

        #endregion
    }
}

