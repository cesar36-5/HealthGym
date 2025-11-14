using CapaEntidad;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public  class DatAlergia
    {
        #region singleton

        private static readonly DatAlergia _instancia = new DatAlergia();
        public static DatAlergia Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region metodos
        //Listar 
        public List<EntAlergia> ListarAlergia()
        { 
            SqlCommand cmd = null;
            List<EntAlergia> lista = new List<EntAlergia>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarAlergia", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntAlergia aler = new EntAlergia();
                    aler.Id = Convert.ToInt32(dr["Id"]);
                    aler.Nombre = dr["Nombre"].ToString();
                    lista.Add(aler);
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

        //Insertar 
        public bool InsertarAlergia(EntAlergia aler)
        {
            SqlCommand cmd = null;
            bool inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarAlergia", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", aler.Nombre);
                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    inserto = true;
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
            return inserto;
        }
        //Editar
        public bool EditarAlergia(EntAlergia aler)
        {
            SqlCommand cmd = null;
            bool edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarAlergia", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", aler.Id);
                cmd.Parameters.AddWithValue("@Nombre", aler.Nombre);
                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    edito = true;
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
            return edito;
        }

    }
    #endregion
}
