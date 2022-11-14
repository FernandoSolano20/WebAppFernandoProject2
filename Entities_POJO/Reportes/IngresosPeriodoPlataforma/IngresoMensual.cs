using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO.Reportes.IngresosPeriodoPlataforma
{
    public class IngresoMensual : BaseEntity
    {
        public int Anno { get; set; }
        public int Mes { get; set; }
        public decimal Ingreso {get; set; }
    }
}
