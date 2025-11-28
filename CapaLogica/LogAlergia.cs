using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogAlergia
    {
        #region singleton
        private static readonly LogAlergia _instancia = new LogAlergia();
        public static LogAlergia Instancia => _instancia;
        #endregion

        #region metodos

        // Listar todas las alergias
        public List<EntAlergia> ListarAlergia()
        {
            try
            {
                return DatAlergia.Instancia.ListarAlergia();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar alergias: " + ex.Message);
            }
        }

        // Agregar una alergia
        public bool AgregarAlergia(EntAlergia aler)
        {
            if (string.IsNullOrWhiteSpace(aler.Nombre))
                throw new Exception("El nombre de la alergia no puede estar vacío.");

            try
            {
                return DatAlergia.Instancia.AgregarAlergia(aler);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar alergia: " + ex.Message);
            }
        }
        public bool ExisteNombre(string nombre, int idIgnorado)
        {
            return DatAlergia.Instancia.ExisteNombreAlergia(nombre, idIgnorado);
        }


        // Editar una alergia existente
        public bool EditarAlergia(EntAlergia aler)
        {
            if (aler.IdAlergia <= 0)
                throw new Exception("Seleccione una alergia válida para editar.");

            if (string.IsNullOrWhiteSpace(aler.Nombre))
                throw new Exception("El nombre de la alergia no puede estar vacío.");

            try
            {
                return DatAlergia.Instancia.EditarAlergia(aler);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar alergia: " + ex.Message);
            }
        }

        #endregion
    }
}

