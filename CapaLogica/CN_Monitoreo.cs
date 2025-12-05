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

        public ResultadoProgreso EvaluarProgreso(Monitoreo obj)
        {
            double estatura = (double)obj.Estatura;
            double peso = (double)obj.Peso;
            obj.IMC = Math.Round(peso / (estatura * estatura), 2);

            ResultadoProgreso resultado = new ResultadoProgreso();

            if (obj.IMC >= 18.5 && obj.IMC < 25) // Peso Normal
            {
                resultado.Nota = "A";
                resultado.Mensaje = "¡Progreso Excelente! Mantén tu disciplina y considera un nuevo objetivo de fuerza o resistencia.";
            }
            else if (obj.IMC >= 25 && obj.IMC < 30) // Sobrepeso
            {
                resultado.Nota = "B";
                resultado.Mensaje = "Buen Avance. Enfócate en la quema de calorías para alcanzar tu objetivo de peso.";
            }
            else
            {
                resultado.Nota = "C";
                resultado.Mensaje = "Progreso Lento. Es crucial revisar la dieta y la intensidad del entrenamiento para ver cambios.";
            }

            obj.Nota = resultado.Nota;
            return resultado;
        }

        public int Registrar(Monitoreo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Estatura <= 0 || obj.Peso <= 0) { Mensaje = "Estatura y Peso deben ser válidos."; return 0; }

            // Ejecuta la evaluación 
            EvaluarProgreso(obj);

            return objCapaDato.Registrar(obj, out Mensaje);
        }

        public List<Monitoreo> Listar(int IdMiembro)
        {
            return objCapaDato.Listar(IdMiembro);
        }
    }
}
