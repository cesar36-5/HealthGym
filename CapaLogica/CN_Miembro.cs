using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CN_Miembro
    {
        private CD_Miembro objCapaDato = new CD_Miembro();

        public Miembro? BuscarPorDNI(string dni, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(dni))
            {
                Mensaje = "Debe ingresar el DNI para buscar al miembro.";
                return null;
            }

            return objCapaDato.BuscarPorDNI(dni, out Mensaje);
        }
    }
}
