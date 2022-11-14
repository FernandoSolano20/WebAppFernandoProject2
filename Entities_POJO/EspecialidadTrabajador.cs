using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class EspecialidadTrabajador : BaseEntity
    {
        public int ID_Especialidad { get; set; }
        public string ID_Trabajador { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Especialidad { get; set; }
        public string Estado { get; set; }
    }
}

