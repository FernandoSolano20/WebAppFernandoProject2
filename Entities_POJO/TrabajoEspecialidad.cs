using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class TrabajoEspecialidad : BaseEntity
    {
        public string NombreEspecialidad { get; set; }
        public string TituloTrabajo { get; set; }
        public int ID_Trabajo { get; set; }
        public int ID_Especialidad { get; set; }
    }
}
