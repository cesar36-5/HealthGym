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
    public class DatObjetivo
    {
        #region Singleton
        private static readonly DatObjetivo _instancia = new DatObjetivo();
        public static DatObjetivo Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region Métodos
        public string BuscarDNI(string dni)
        {
            string nombre = "";
            try
            {
                using (SqlConnection con = Conexion.Instancia.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand("spBuscarDNI", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DNI", dni);

                        con.Open();

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            nombre = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                nombre = "";
                throw new Exception("Error al encontrar miembro" + ex.Message, ex);
            }

            return nombre;
        }

        public DataTable Listar(string dni)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = Conexion.Instancia.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand("spListarObjetivo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DNI", dni);

                        con.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar objetivos por DNI: " + ex.Message, ex);
            }

            return dt;
        }

        public List<EntObjetivo> ListarMusculos()
        {
            List<EntObjetivo> lista = new List<EntObjetivo>();

            try
            {
                using (SqlConnection con = Conexion.Instancia.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand("spListarMusculos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new EntObjetivo
                                {
                                    IdMusculo = Convert.ToInt32(dr["IdMusculo"]),
                                    NombreMusculo = dr["Nombre"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar músculos: " + ex.Message, ex);
            }

            return lista;
        }

        public bool InsertarObjetivo(EntObjetivo obj)
        {
            try
            {
                using (SqlConnection con = Conexion.Instancia.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertarObjetivo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DNI", obj.DNI);
                        cmd.Parameters.AddWithValue("@IdMusculo", obj.IdMusculo);
                        cmd.Parameters.AddWithValue("@Tamano", obj.Tamano);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new Exception("El miembro ya tiene un objetivo para ese músculo.");

                throw new Exception("Error al insertar objetivo: " + ex.Message, ex);
            }
        }


        public bool EditarObjetivo(EntObjetivo obj)
        {
            try
            {
                using (SqlConnection con = Conexion.Instancia.Conectar())
                using (SqlCommand cmd = new SqlCommand("spEditarObjetivo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DNI", obj.DNI);
                    cmd.Parameters.AddWithValue("@IdMusculo", obj.IdMusculo);
                    cmd.Parameters.AddWithValue("@Tamano", obj.Tamano);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar objetivo: " + ex.Message, ex);
            }
        }

        public bool EliminarObjetivo(string dni, int idMusculo)
        {
            try
            {
                using (SqlConnection con = Conexion.Instancia.Conectar())
                using (SqlCommand cmd = new SqlCommand("spEliminarObjetivo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DNI", dni);
                    cmd.Parameters.AddWithValue("@IdMusculo", idMusculo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar objetivo: " + ex.Message, ex);
            }
        }
        #endregion
    }
}
