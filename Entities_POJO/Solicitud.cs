using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Solicitud : BaseEntity
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string CodigoQR { get; set; }
        public int CalificacionTrabajo { get; set; }
        public string ComentarioTrabajo { get; set; }
        public int CalificacionEmpresa { get; set; }
        public string ComentarioEmpresa { get; set; }
        public int CalificacionTrabajador { get; set; }
        public string ComentarioTrabajador { get; set; }
        public decimal Presupuesto { get; set; }
        public string Estado { get; set; }
        public decimal PrecioFinal { get; set; }
        public string ID_Cliente { get; set; }
        public string ID_Empresa { get; set; }
        public string Especialidades { get; set; }
        public string TipoTrabajos { get; set; }

        //Valores de la empresa asignada a la solicitud
        public string CedulaEmpresa { get; set; }
        public string NombreComercial { get; set; }

        //Codigo sacado del QR utilizado para validar que el QR concuerde con el ID de la solicitud en cuestion
        public int ID_QR { get; set; }

        //Campos para mostrar el precio final de la solicitud al usuario con los valores de la moneda utilizada

        public int CostoTotal { get; set; }
        public decimal CostoNeto { get; set; }
        public decimal Impuestos { get; set; }

    }
}
