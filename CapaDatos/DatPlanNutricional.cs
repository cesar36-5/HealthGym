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

        public List<EntPlanNutricional> ListarPlanesPorDNI(string dni)
        {
            List<EntPlanNutricional> lista = new List<EntPlanNutricional>();

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ListarPlanesPorDNI", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNI", dni);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntPlanNutricional obj = new EntPlanNutricional();

                            obj.Id = dr.GetInt32(dr.GetOrdinal("IdPlanNutricional"));

                            int idxFechaFin = dr.GetOrdinal("FechaFin");
                            if (!dr.IsDBNull(idxFechaFin))
                                obj.FechaFin = dr.GetDateTime(idxFechaFin);
                            else
                                obj.FechaFin = null;

                            lista.Add(obj);
                        }
                    }
                }
            }

            return lista;
        }
        public List<EntDetallePlan> ListarPlanDetallePorIdPlan(int idPlan)
        {
            List<EntDetallePlan> lista = new List<EntDetallePlan>();

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ListarPlanDetallePorIdPlan", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPlan", idPlan);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntDetallePlan obj = new EntDetallePlan();

                            obj.IdPlan = dr.GetInt32(dr.GetOrdinal("IdPlanNutricional"));
                            obj.IdPlatillo = dr.GetInt32(dr.GetOrdinal("IdPlatillo"));
                            obj.Dia = dr.GetInt32(dr.GetOrdinal("Dia"));
                            obj.Momento = dr.GetInt32(dr.GetOrdinal("Momento"));

                            lista.Add(obj);
                        }
                    }
                }
            }

            return lista;
        }

    }
}
