using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogRecetaMaterial
    {
        #region Singleton

        public static readonly LogRecetaMaterial _instancia = new LogRecetaMaterial();

        public static LogRecetaMaterial Instancia { get { return _instancia; } }

        #endregion Singleton

        public List<EntRecetaMaterial> CargarMaterialesDe(EntAlimento e)
        {
            return DatRecetaMaterial.Instancia.CargarMaterialesDe(e.Id);
        }

        public bool AgregarMaterial(EntRecetaMaterial m)
        {
            return DatRecetaMaterial.Instancia.AgregarMaterial(m);
        }

        public bool EditarMaterial(EntRecetaMaterial m)
        {
            return DatRecetaMaterial.Instancia.EditarMaterial(m);
        }
    }
}
