using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    public class DatEvaluacionNutricional
    {
        #region singleton
        private static readonly DatEvaluacionNutricional _instancia = new DatEvaluacionNutricional();
        public static DatEvaluacionNutricional Instancia => _instancia;
        #endregion singleton

        #region métodos

        public bool RegistrarEvaluacion(EntEvaluacionNutricional obj)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("spRegistrarEvaluacionNutricional", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdMiembro", obj.IdMiembro);
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
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la evaluación: " + ex.Message);
            }
        }

        public bool ExisteEvaluacionPorMiembro(int idMiembro)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM EvaluacionNutricional WHERE IdMiembro = @id", cn);
                cmd.Parameters.AddWithValue("@id", idMiembro);
                cn.Open();

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        //Buscar Miembro 
        public EntEvaluacionNutricional? BuscarPorDNI(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("Debe ingresar un DNI.");

            EntEvaluacionNutricional? e = null;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                using (SqlCommand cmd = new SqlCommand("spBuscarMiemPorDNI", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DNI", SqlDbType.VarChar, 8).Value = dni;

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            e = new EntEvaluacionNutricional
                            {
                                IdMiembro = Convert.ToInt32(dr["IdMiembro"]),
                                DNI = dr["DNI"]?.ToString() ?? string.Empty,
                                Apellidos = dr["Apellidos"]?.ToString() ?? string.Empty,
                                Nombres = dr["Nombres"]?.ToString() ?? string.Empty,
                                Sexo = dr["Sexo"]?.ToString() ?? string.Empty,
                                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                            };

                            e.Edad = DateTime.Now.Year - e.FechaNacimiento.Year;
                            if (DateTime.Now < e.FechaNacimiento.AddYears(e.Edad))
                                e.Edad--;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar miembro por DNI: " + ex.Message);
            }

            return e;
        }

        public EntEvaluacionNutricional ObtenerEvaluacionRecientePorDNI(string dni)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_BuscarEvaluacionReciente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DNI", dni);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new EntEvaluacionNutricional
                            {
                                IdMiembro = Convert.ToInt32(dr["IdMiembro"]),
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
                                NivelActividad = Convert.ToChar(dr["NivelActividad"]),
                                FrecuenciaActividad = Convert.ToInt32(dr["FrecuenciaActividad"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"]),

                                // Datos del miembro
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                DNI = dr["DNI"].ToString(),
                                Sexo = dr["Sexo"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                                Edad = Convert.ToInt32(dr["Edad"])
                            };
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener evaluación reciente por DNI: " + ex.Message);
            }
        }

        #endregion métodos
    }
}
