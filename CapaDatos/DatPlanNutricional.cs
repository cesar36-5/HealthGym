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
    public class DatPlanNutricional
    {
        #region Singleton
        private static readonly DatPlanNutricional _instancia = new DatPlanNutricional();
        public static DatPlanNutricional Instancia
        {
            get { return _instancia; }
        }
        #endregion

        public int CrearPlan(string dni)
        {
            int idPlan = -1;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("CrearPlanNutricional", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@dni", dni);

                    SqlParameter paramSalida = new SqlParameter("@IdPlanSalida", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramSalida);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    idPlan = Convert.ToInt32(paramSalida.Value);
                }
            }

            return idPlan;
        }

        public bool InsertarDetallesPlan(List<EntDetallePlan> detalles)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cn.Open();

                    foreach (var detalle in detalles)
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertarDetallePlan", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@IdPlanNutricional", detalle.IdPlan);
                            cmd.Parameters.AddWithValue("@IdPlatillo", detalle.IdPlatillo);
                            cmd.Parameters.AddWithValue("@Dia", detalle.Dia);
                            cmd.Parameters.AddWithValue("@Momento", detalle.Momento);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
