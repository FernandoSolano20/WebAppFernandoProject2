using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO.Reportes
{
    public class IngresosDiarios : BaseEntity
    {
        public decimal MontoTotal { get; set; }
        public DateTime Fecha { get; set; }

        public string TipoTransaccion { get; set; }
    }
}
