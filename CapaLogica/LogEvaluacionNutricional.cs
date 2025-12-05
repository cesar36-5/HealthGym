using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogEvaluacionNutricional
    {
        #region singleton
        private static readonly LogEvaluacionNutricional _instancia = new LogEvaluacionNutricional();
        public static LogEvaluacionNutricional Instancia => _instancia;
        #endregion singleton

        #region métodos

        //Registrar Evaluación Nutri
        public bool RegistrarEvaluacion(EntEvaluacionNutricional obj)
        {
            return DatEvaluacionNutricional.Instancia.RegistrarEvaluacion(obj);
        }
        public EntEvaluacionNutricional BuscarPorDNI(string dni)
        {
            return DatEvaluacionNutricional.Instancia.BuscarPorDNI(dni)
                   ?? throw new InvalidOperationException("No se encontró la evaluación nutricional para el DNI proporcionado.");
        }
        public bool EvaluacionYaRegistrada(int idMiembro)
        {
            return DatEvaluacionNutricional.Instancia.ExisteEvaluacionPorMiembro(idMiembro);
        }

        public EntEvaluacionNutricional BuscarEvaluacion(string dni)
        {
            return DatEvaluacionNutricional.Instancia.BuscarPorDNI(dni);
        }

        #endregion métodos
    }
}

