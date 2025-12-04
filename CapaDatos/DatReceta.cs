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
    public class DatReceta
    {
        #region
        private static readonly DatReceta _instancia = new DatReceta();
        public static DatReceta instancia
        {
            get { return _instancia; }
        }
        #endregion

        public int ObtenerReceta(string dni)
        {
            int idReceta = -1;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("BuscarReceta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@dni", dni);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            idReceta = Convert.ToInt32(dr["IdReceta"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener receta: " + ex.Message);
            }

            return idReceta;
        }

        public List<EntDetalleReceta> CargarDetalles(int idReceta)
        {
            List<EntDetalleReceta> lista = new List<EntDetalleReceta>();

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("CargarDetallesReceta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", idReceta);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntDetalleReceta det = new EntDetalleReceta
                            {
                                IdPlatillo = Convert.ToInt32(dr["IdPlatillo"]),
                                Dia = Convert.ToInt32(dr["Dia"]),
                                Momento = Convert.ToInt32(dr["Momento"])
                            };

                            lista.Add(det);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar detalles: " + ex.Message);
            }

            return lista;
        }

    }
}
