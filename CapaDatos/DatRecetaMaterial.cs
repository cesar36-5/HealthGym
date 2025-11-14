using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatRecetaMaterial
    {
        #region Singleton

        private static readonly DatRecetaMaterial _instancia = new DatRecetaMaterial();

        public static DatRecetaMaterial Instancia { get {  return _instancia; } }

        #endregion Singleton

        public List<EntRecetaMaterial> CargarMaterialesDe(int id)
        {
            List<EntRecetaMaterial> mats = new List<EntRecetaMaterial>();

            using(SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();
                using(SqlCommand cmd = new SqlCommand("CargarMaterialesDe", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntRecetaMaterial mat = new EntRecetaMaterial();
                            mat.Id = dr.GetInt32(0);
                            mat.Alimento = dr.GetInt32(1);
                            mat.Material = dr.GetString(2);
                            mat.Cantidad = dr.GetDecimal(3);
                            mat.Medida = dr.GetString(4);

                            mats.Add(mat);
                        }
                    }
                }
            }

            return mats;
        }

        public bool AgregarMaterial(EntRecetaMaterial mat)
        {
            bool hecho = false;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("AgregarMaterial", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", mat.Alimento);
                    cmd.Parameters.AddWithValue("@mat", mat.Material);
                    cmd.Parameters.AddWithValue("@cant", mat.Cantidad);
                    cmd.Parameters.AddWithValue("@med", mat.Medida);

                    hecho = cmd.ExecuteNonQuery() > 0;
                }
            }

            return hecho;
        }

        public bool EditarMaterial(EntRecetaMaterial mat)
        {
            bool hecho = false;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("EditarMaterial", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", mat.Id);
                    cmd.Parameters.AddWithValue("@al", mat.Alimento);
                    cmd.Parameters.AddWithValue("@mat", mat.Material);
                    cmd.Parameters.AddWithValue("@cant", mat.Cantidad);
                    cmd.Parameters.AddWithValue("@med", mat.Medida);

                    hecho = cmd.ExecuteNonQuery() > 0;
                }
            }

            return hecho;
        }
    }
}
