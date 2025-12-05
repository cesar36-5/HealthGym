using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CN_Monitoreo
    {
        private CD_Monitoreo objCapaDato = new CD_Monitoreo();

       

        public int Registrar(Monitoreo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

          
            if (obj.Estatura <= 0 || obj.Peso <= 0)
            {
                Mensaje = "Estatura y Peso deben ser válidos.";
                return 0;
            }


            return objCapaDato.Registrar(obj, out Mensaje);
        }

        public List<Monitoreo> Listar(int IdMiembro)
        {
            return objCapaDato.Listar(IdMiembro);
        }
    }
}
