using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatRecetaPaso
    {
        #region Singleton

        private static readonly DatRecetaPaso _instancia = new DatRecetaPaso();

        public static DatRecetaPaso Instancia { get { return _instancia; } }

        #endregion Singleton

        public List<EntRecetaPaso> CargarPasosDe(int id)
        {
            List<EntRecetaPaso> pasos = new List<EntRecetaPaso>();

            using(SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();
                using(SqlCommand cmd = new SqlCommand("CargarPasosDe", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntRecetaPaso paso = new EntRecetaPaso();
                            paso.Id = dr.GetInt32(0);
                            paso.Alimento = dr.GetInt32(1);
                            paso.Paso = dr.GetInt32(2);
                            paso.Instruccion = dr.GetString(3);

                            pasos.Add(paso);
                        }
                    }
                }
            }

            return pasos;
        }

        public bool AgregarPaso(EntRecetaPaso pas)
        {
            bool hecho = false;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("AgregarPaso", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", pas.Alimento);
                    cmd.Parameters.AddWithValue("@pas", pas.Paso);
                    cmd.Parameters.AddWithValue("@ins", pas.Instruccion);

                    int f = cmd.ExecuteNonQuery();

                    hecho = f > 0;
                }
            }

            return hecho;
        }

        public bool EdtarPaso(EntRecetaPaso pas)
        {
            bool hecho = false;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("EditarPaso", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", pas.Id);
                    cmd.Parameters.AddWithValue("@al", pas.Alimento);
                    cmd.Parameters.AddWithValue("@pas", pas.Paso);
                    cmd.Parameters.AddWithValue("@ins", pas.Instruccion);

                    int f = cmd.ExecuteNonQuery();

                    hecho = f > 0;
                }
            }

            return hecho;
        }
    }
}
