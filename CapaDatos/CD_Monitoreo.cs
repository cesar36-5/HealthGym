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
    public class CD_Monitoreo
    {
        public int Registrar(Monitoreo obj, out string Mensaje)
        {
            int idMonitoreoGenerado = 0;
            Mensaje = string.Empty;
            if (obj.oMiembro == null) { Mensaje = "Miembro no asociado."; return 0; }

            try
            {
                using (SqlConnection oconexion = Conexion.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarMonitoreo", oconexion);
                    cmd.Parameters.AddWithValue("IdMiembro", obj.oMiembro.IdMiembro);
                    cmd.Parameters.AddWithValue("Estatura", obj.Estatura);
                    cmd.Parameters.AddWithValue("Peso", obj.Peso);
                    cmd.Parameters.AddWithValue("IMC", obj.IMC);
                    cmd.Parameters.AddWithValue("Brazo", obj.Brazo);
                    cmd.Parameters.AddWithValue("Pierna", obj.Pierna);
                    cmd.Parameters.AddWithValue("Gluteo", obj.Gluteo);
                    cmd.Parameters.AddWithValue("Cintura", obj.Cintura);
                    cmd.Parameters.AddWithValue("Pecho", obj.Pecho);
                    cmd.Parameters.AddWithValue("Nota", obj.Nota ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("ObjetivoCalorico", obj.ObjetivoCalorico);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idMonitoreoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                }
            }
            catch (Exception ex)
            {
                idMonitoreoGenerado = 0;
                Mensaje = "Error DB: " + ex.Message;
            }
            return idMonitoreoGenerado;
        }

        public List<Monitoreo> Listar(int IdMiembro)
        {
            List<Monitoreo> lista = new List<Monitoreo>();
            try
            {
                using (SqlConnection oconexion = Conexion.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerMonitoreoPorMiembro", oconexion);
                    cmd.Parameters.AddWithValue("IdMiembro", IdMiembro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Monitoreo()
                            {
                                IdMonitoreo = Convert.ToInt32(dr["IdMonitoreo"]),
                                Estatura = Convert.ToDecimal(dr["Estatura"]),
                                Peso = Convert.ToDecimal(dr["Peso"]),
                                IMC = Convert.ToDouble(dr["IMC"]),
                                Brazo = Convert.ToDecimal(dr["Brazo"]),
                                Pierna = Convert.ToDecimal(dr["Pierna"]),
                                Gluteo = Convert.ToDecimal(dr["Gluteo"]),
                                Cintura = Convert.ToDecimal(dr["Cintura"]),
                                Pecho = Convert.ToDecimal(dr["Pecho"]),
                                Nota = dr["Nota"]?.ToString(),
                                ObjetivoCalorico = Convert.ToInt32(dr["ObjetivoCalorico"])
                            });
                        }
                    }
                }
            }
            catch { lista = new List<Monitoreo>(); }
            return lista;
        }
    }
}
