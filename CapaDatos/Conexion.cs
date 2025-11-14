using System.Data.SqlClient;
<<<<<<< HEAD
using Microsoft.Data.SqlClient;
=======
>>>>>>> 8f9e504544c1401ea82fbde3c5524f27251837e7
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
<<<<<<< HEAD
                "Server=localhost;" +
                "Database=HealthGymMoanso;" +
                "User Id=sa;" +
                "Password=12345678;" +
=======
                "Server=localhost\\SQLEXPRESS;" +
                "Database=HealthGymMoanso;" +
                "Integrated Security=True;" +
>>>>>>> 8f9e504544c1401ea82fbde3c5524f27251837e7
                "TrustServerCertificate=True;" +
                "Encrypt=False;";

            return cn;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 8f9e504544c1401ea82fbde3c5524f27251837e7
