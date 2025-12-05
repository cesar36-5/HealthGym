using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntEvaluacionNutricional
    {
        public int IdMiembro { get; set; }
        public decimal Estatura { get; set; }
        public decimal Peso { get; set; }
        public float IMC { get; set; }
        public decimal Brazo { get; set; }
        public decimal Pierna { get; set; }
        public decimal Gluteo { get; set; }
        public decimal Cintura { get; set; }
        public decimal Pecho { get; set; }
      
        public string Nota { get; set; } = string.Empty;
          
        public int ObjetivoCalorico { get; set; }
        public char NivelActividad { get; set; }
        public int FrecuenciaActividad { get; set; }

        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public int Edad { get; set; }             
        public DateTime FechaNacimiento { get; set; } 
        public DateTime? Fecha { get; set; }
    }
}
