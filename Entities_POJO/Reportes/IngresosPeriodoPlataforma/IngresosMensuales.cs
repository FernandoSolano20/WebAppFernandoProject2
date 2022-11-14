using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO.Reportes.IngresosPeriodoPlataforma
{
    public class IngresosMensuales : BaseEntity
    {
        public IngresosMensuales(int cantidadRegistros)
        {
            Meses = new string[cantidadRegistros];
            Ingresos = new decimal[cantidadRegistros];
        }

        public IngresosMensuales()
        {
            Meses = new string[0];
            Ingresos = new decimal[0];
        }

        //Lista de los meses encontrados en la base de datos con ingresos relacionados
        public string[] Meses { get; set; }
        //Arreglo de los Ingresos encontrados en la DB. Es la suma (SUM() Y GroupBy()) de todas las trasacciones entrantes
        public decimal[] Ingresos { get; set; }
        //Total de meses por el que se desea que se realice el reporte. Seis meses, 12 meses, 18 meses...
        public int PeriodoMeses { get; set; }
        //Determina el tipo de movimiento realizado en la transaccion. Ya sea entrante en la plataforma, saliente...
        public string TipoMovimiento { get; set; }
    }
}
