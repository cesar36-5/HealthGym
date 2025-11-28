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
        

        #endregion métodos
    }
}
