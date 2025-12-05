using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Monitoreo
    {
        public int IdMonitoreo { get; set; }
        public Miembro? oMiembro { get; set; }
        public decimal Estatura { get; set; }
        public decimal Peso { get; set; }
        public double IMC { get; set; }
        public decimal Brazo { get; set; }
        public decimal Pierna { get; set; }
        public decimal Gluteo { get; set; }
        public decimal Cintura { get; set; }
        public decimal Pecho { get; set; }
        public string? Nota { get; set; }
        public int ObjetivoCalorico { get; set; }
        public string NivelActividad { get; set; }
        public int FrecuenciaActividad { get; set; }
    }
}
