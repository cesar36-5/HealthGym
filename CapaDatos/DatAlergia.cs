using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatAlergia
    {
        #region singleton
        private static readonly DatAlergia _instancia = new DatAlergia();
        public static DatAlergia Instancia => _instancia;
        #endregion

        #region metodos

        // Listar
        public List<EntAlergia> ListarAlergia()
        {
            List<EntAlergia> lista = new List<EntAlergia>();
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                using (SqlCommand cmd = new SqlCommand("sp_ListarAlergias", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntAlergia aler = new EntAlergia
                            {
                                IdAlergia = Convert.ToInt32(dr["IdAlergia"]),
                                Nombre = dr["Nombre"].ToString()
                            };
                            lista.Add(aler);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        // Insertar
        public bool AgregarAlergia(EntAlergia aler)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                using (SqlCommand cmd = new SqlCommand("sp_AgregarAlergia", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", aler.Nombre);
                    cn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ExisteNombreAlergia(string nombre, int idIgnorado)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                string query = "SELECT COUNT(*) FROM Alergia WHERE Nombre = @nombre AND IdAlergia != @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@id", idIgnorado);
                cn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Editar
        public bool EditarAlergia(EntAlergia aler)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                using (SqlCommand cmd = new SqlCommand("sp_EditarAlergia", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdAlergia", aler.IdAlergia);
                    cmd.Parameters.AddWithValue("@Nombre", aler.Nombre);
                    cn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}

