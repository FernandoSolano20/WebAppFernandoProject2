using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class TrabajoTipoTrabajo : BaseEntity
    {
        public string NombreTipoTrabajo { get; set; }
        public string TituloTrabajo { get; set; }
        public int ID_Trabajo { get; set; }
        public int ID_Tipo_Trabajo { get; set; }
        public decimal Precio { get; set; }
        public int Horas_Trabajadas { get; set; }
        public decimal Cancelacion { get; set; }
    }
}
