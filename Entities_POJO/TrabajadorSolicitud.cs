using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class TrabajadorSolicitud : BaseEntity
    {
        public int IdSolicitud { get; set; }
        public string IdTrabajador { get; set; }
        public string IdEmpresa { get; set; }
        public decimal Precio { get; set; }
        public string NombreUsuario { get; set; }
        public string PrimerApellidoUsuario { get; set; }
        public string SegundoApellidoUsuario { get; set; }
        public decimal Promedio { get; set; }
        public int HorasTrabajadas { get; set; }
        public string idCliente { get; set; }
        public decimal PrecioFinal { get; set; }
        public decimal PrecioMonedaUsuario { get; set; }
    }
}
