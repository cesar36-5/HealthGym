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
    public class DatPlatillo
    {
        #region Singleton
        private static readonly DatPlatillo _instancia = new DatPlatillo();
        public static DatPlatillo Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region Métodos

        // LISTAR
        public List<EntPlatillo> ListarPlatillo()
        {
            SqlCommand cmd = null;
            List<EntPlatillo> lista = new List<EntPlatillo>();

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("spListarPlatillo", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EntPlatillo p = new EntPlatillo
                        {
                            IdPlatillo = Convert.ToInt32(dr["IdPlatillo"]),
                            Nombre = dr["Nombre"].ToString(),
                            Calorias = Convert.ToInt32(dr["Calorias"]),
                            Carbohidratos = Convert.ToDecimal(dr["Carbohidratos"]),
                            Grasas = Convert.ToDecimal(dr["Grasas"]),
                            Proteinas = Convert.ToDecimal(dr["Proteinas"]),
                            Categoria = dr["Categoria"].ToString()
                        };

                        lista.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar Platillos" + ex.Message, ex);
            }

            return lista;
        }

        // INSERTAR
        public bool InsertarPlatillo(EntPlatillo platillo)
        {
            SqlCommand cmd = null;
            bool insertado = false;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("spInsertarPlatillo", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", platillo.Nombre);
                    cmd.Parameters.AddWithValue("@Calorias", platillo.Calorias);
                    cmd.Parameters.AddWithValue("@Carbohidratos", platillo.Carbohidratos);
                    cmd.Parameters.AddWithValue("@Grasas", platillo.Grasas);
                    cmd.Parameters.AddWithValue("@Proteinas", platillo.Proteinas);
                    cmd.Parameters.AddWithValue("@Categoria", platillo.Categoria);

                    cn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0) insertado = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al añadir Platillo" + ex.Message, ex);
            }

            return insertado;
        }

        // EDITAR
        public bool EditarPlatillo(EntPlatillo platillo)
        {
            SqlCommand cmd = null;
            bool editado = false;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("spEditarPlatillo", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPlatillo", platillo.IdPlatillo);
                    cmd.Parameters.AddWithValue("@Nombre", platillo.Nombre);
                    cmd.Parameters.AddWithValue("@Calorias", platillo.Calorias);
                    cmd.Parameters.AddWithValue("@Carbohidratos", platillo.Carbohidratos);
                    cmd.Parameters.AddWithValue("@Grasas", platillo.Grasas);
                    cmd.Parameters.AddWithValue("@Proteinas", platillo.Proteinas);
                    cmd.Parameters.AddWithValue("@Categoria", platillo.Categoria);

                    cn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0) editado = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception ("Error al editar Platillo" + ex.Message,ex);
            }

            return editado;
        }

        #endregion
    }
}
