using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace CapaDatos

{
    public class Conexion
    {
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia
        {
            get { return _instancia; }
        }

        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString =
                "Server=localhost\\SQLEXPRESS;" +
                "Database=HealthGym;" +
                "Integrated Security=True;" +
                "TrustServerCertificate=True;" +
                "Encrypt=False;";
            return cn;
        }
    }
}