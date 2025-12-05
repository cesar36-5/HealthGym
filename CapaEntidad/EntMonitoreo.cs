using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntMonitoreo
    {
        public decimal Estatura { get; set; }
        public decimal Peso { get; set; }
        public float IMC { get; set; }
        public decimal Brazo { get; set; }
        public decimal Pierna { get; set; }
        public decimal Gluteo { get; set; }
        public decimal Cintura { get; set; }
        public decimal Pecho { get; set; }
        public string Nota { get; set; }
        public int ObjetivoCalorico { get; set; }
        public string NivelActividad { get; set; }
        public int FrecuenciaActividad { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
