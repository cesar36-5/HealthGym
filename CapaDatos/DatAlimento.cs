using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatAlimento
    {
        #region Singleton
        private static readonly DatAlimento _instancia = new DatAlimento();
        public static DatAlimento Instancia
        {
            get { return _instancia; }
        }
        #endregion Singleton

        public List<EntAlimento> CargarAlimentos()
        {
            List<EntAlimento> alimentos = new List<EntAlimento>();

            try
            {
                using(SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    using(SqlCommand cmd = new SqlCommand("CargarAlimentos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using(SqlDataReader dr  = cmd.ExecuteReader())
                        {
                            while(dr.Read())
                            {
                                EntAlimento aliemento = new EntAlimento();
                                aliemento.Id = dr.GetInt32(0);
                                aliemento.Nombre = dr.GetString(1);
                                aliemento.Carbohidratos = dr.GetDecimal(2);
                                aliemento.Proteinas = dr.GetDecimal(3);
                                aliemento.Grasas = dr.GetDecimal(4);
                                aliemento.Calorias = dr.GetInt32(5);

                                alimentos.Add(aliemento);
                            }
                        }
                    }
                }
            }catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return alimentos;
        }
    }
}
