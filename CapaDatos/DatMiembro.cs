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
    public class DatMiembro
    {
        #region singleton
        private static readonly DatMiembro _instancia = new DatMiembro();
        public static DatMiembro Instancia => _instancia;
        #endregion

        public EntMiembro BuscarMiembroPorDNI(string dni)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerMiembroPorDNI", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DNI", dni);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            EntMiembro m = new EntMiembro();

                            m.Id = Convert.ToInt32(dr["IdMiembro"]);
                            m.Nombre = dr["NombreCompleto"].ToString();
                            m.Sexo = dr["Sexo"].ToString();
                            m.Edad = Convert.ToInt32(dr["Edad"]);

                            return m;
                        }
                    }
                }

                // Si no encontró nada
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar miembro: " + ex.Message);
            }
        }

    }
}
