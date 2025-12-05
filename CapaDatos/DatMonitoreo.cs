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
    public class DatMonitoreo
    {
        #region Singleton
        private static readonly DatMonitoreo _instancia = new DatMonitoreo();
        public static DatMonitoreo Instancia
        {
            get { return _instancia; }
        }
        #endregion
        public EntMonitoreo ObtenerMonitoreoReciente(int idMiembro)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerMonitoreoReciente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdMiembro", idMiembro);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new EntMonitoreo
                            {
                                Estatura = dr.GetDecimal(dr.GetOrdinal("Estatura")),
                                Peso = dr.GetDecimal(dr.GetOrdinal("Peso")),
                                IMC = Convert.ToSingle(dr["IMC"]),
                                Brazo = dr.GetDecimal(dr.GetOrdinal("Brazo")),
                                Pierna = dr.GetDecimal(dr.GetOrdinal("Pierna")),
                                Gluteo = dr.GetDecimal(dr.GetOrdinal("Gluteo")),
                                Cintura = dr.GetDecimal(dr.GetOrdinal("Cintura")),
                                Pecho = dr.GetDecimal(dr.GetOrdinal("Pecho")),
                                Nota = dr["Nota"].ToString(),
                                ObjetivoCalorico = Convert.ToInt32(dr["ObjetivoCalorico"]),
                                NivelActividad = dr["NivelActividad"].ToString(),
                                FrecuenciaActividad = Convert.ToInt32(dr["FrecuenciaActividad"])
                            };
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener monitoreo reciente: " + ex.Message);
            }
        }

        public string EvaluarObjetivoMusculo(int idMiembro, int idMusculo, decimal tamanoActual)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_EvaluarObjetivoMusculo", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdMiembro", idMiembro);
                    cmd.Parameters.AddWithValue("@IdMusculo", idMusculo);
                    cmd.Parameters.AddWithValue("@TamanoActual", tamanoActual);

                    SqlParameter salida = new SqlParameter("@Resultado", SqlDbType.Char, 1)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(salida);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    return salida.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al evaluar objetivo del músculo: " + ex.Message);
            }
        }
        public bool InsertarMonitoreo(int idMiembro, EntMonitoreo obj)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertarMonitoreo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdMiembro", idMiembro);
                        cmd.Parameters.AddWithValue("@Estatura", obj.Estatura);
                        cmd.Parameters.AddWithValue("@Peso", obj.Peso);
                        cmd.Parameters.AddWithValue("@IMC", obj.IMC);
                        cmd.Parameters.AddWithValue("@Brazo", obj.Brazo);
                        cmd.Parameters.AddWithValue("@Pierna", obj.Pierna);
                        cmd.Parameters.AddWithValue("@Gluteo", obj.Gluteo);
                        cmd.Parameters.AddWithValue("@Cintura", obj.Cintura);
                        cmd.Parameters.AddWithValue("@Pecho", obj.Pecho);
                        cmd.Parameters.AddWithValue("@Nota", obj.Nota);
                        cmd.Parameters.AddWithValue("@ObjetivoCalorico", obj.ObjetivoCalorico);
                        cmd.Parameters.AddWithValue("@NivelActividad", obj.NivelActividad);
                        cmd.Parameters.AddWithValue("@FrecuenciaActividad", obj.FrecuenciaActividad);

                        cn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el monitoreo: " + ex.Message);
            }
        }

    }
}
