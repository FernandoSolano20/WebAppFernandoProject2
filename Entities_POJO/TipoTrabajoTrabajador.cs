﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class TipoTrabajoTrabajador : BaseEntity
    {
        public int Id_TipoTrabajo { get; set; }
        public string Id_Trabajador { get; set; }
        public decimal Precio_Hora { get; set; }
        public DateTime Fecha { get; set; }  
        public string Estado { get; set; }
        public string nombreTrabajador { get; set; }
        public string apellidosTrabajador { get; set; }
        public string tipoTrabajo { get; set; }
    }
}
