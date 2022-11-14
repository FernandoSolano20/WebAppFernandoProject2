using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Oferta : BaseEntity
    {
        public int IdSolicitud { get; set; }
        public string IdEmpresa { get; set; }
        public decimal Precio { get; set; }
        public string TipoCobro { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cancelacion { get; set; }
        public string Estado { get; set; }
        public string Moneda { get; set; }
        public decimal Promedio { get; set; }
        public string NombreComercial { get; set; }
        public string FormatoFecha { get; set; }

        //Valores con formato
        public decimal PrecioCliente { get; set; }
        public decimal CancelacionCliente { get; set; }
    }
}
