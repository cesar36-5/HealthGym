using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Miembro
    {
        public int IdMiembro { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? DNI { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string NombreCompleto
        {
            get { return $"{Nombres} {Apellidos}"; }
        }
    }
}
