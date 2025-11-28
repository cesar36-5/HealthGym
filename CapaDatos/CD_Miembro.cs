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
    public class CD_Miembro
    {
        public Miembro? BuscarPorDNI(string dni, out string Mensaje)
        {
            Miembro? oMiembro = null;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = Conexion.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_BuscarMiembroPorDNI", oconexion);
                    cmd.Parameters.AddWithValue("DNI", dni);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oMiembro = new Miembro()
                            {
                                IdMiembro = Convert.ToInt32(dr["IdMiembro"]),
                                Nombres = dr["Nombres"]?.ToString() ?? string.Empty,
                                Apellidos = dr["Apellidos"]?.ToString() ?? string.Empty,
                                DNI = dr["DNI"]?.ToString() ?? string.Empty
                            };
                        }
                        else
                        {
                            Mensaje = "No se encontró ningún miembro con ese DNI.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensaje = "Error en la búsqueda de la base de datos: " + ex.Message;
                oMiembro = null;
            }
            return oMiembro;
        }
    }
}
