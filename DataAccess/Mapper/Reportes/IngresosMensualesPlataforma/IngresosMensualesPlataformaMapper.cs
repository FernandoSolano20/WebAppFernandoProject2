using DataAccess.Dao;
using Entities_POJO;
using Entities_POJO.Reportes.IngresosPeriodoPlataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Reportes.IngresosMensualesPlataforma
{
    public class IngresosMensualesPlataformaMapper : EntityMapper
    {
        private const string DB_COL_ANNO = "ANNO";
        private const string DB_COL_MES = "MES";
        private const string DB_COL_INGRESOS = "INGRESOS";
        private const string DB_COL_PERIODO = "PERIODO";
        private const string DB_COL_MOVIMIENTO = "MOVIMIENTO";

        private string[] MesesAnno = { "ENERO","FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"};

        public SqlOperation GetGananciasMensualesStatement(BaseEntity baseEntity)
        { 
            SqlOperation operation = new SqlOperation() { ProcedureName = "TBL_TRANSACCION_REPORTE_INGRESOS_MENSUALES" };
            var reporte = (IngresosMensuales)baseEntity;

            operation.AddIntParam(DB_COL_PERIODO, reporte.PeriodoMeses);
            operation.AddNVarcharParam(DB_COL_MOVIMIENTO, reporte.TipoMovimiento);

            return operation;
        }

        public IngresoMensual BuildObject(Dictionary<string, object> row)
        {
            var reporte = new IngresoMensual()
            {
                Anno = GetIntValue(row, DB_COL_ANNO),
                Mes = GetIntValue(row, DB_COL_MES),
                Ingreso = GetDecimalValue(row, DB_COL_INGRESOS)
            };
            return reporte;
        }

        public BaseEntity BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            //Se inicializa el objeto reporteIngresosMensuales con la cantidad meses con ingresos encontrados en la base de datos
            var reporteIngresosMensuales = new IngresosMensuales(lstRows.Count);
            int contador = 0;
            foreach (var element in lstRows)
            {
                var ingresoMensual = BuildObject(element);

                reporteIngresosMensuales.Meses[contador] = MesesAnno[ingresoMensual.Mes - 1] + " " + ingresoMensual.Anno;
                reporteIngresosMensuales.Ingresos[contador] = ingresoMensual.Ingreso;

                contador++;
            }
            return reporteIngresosMensuales;
        }
    }
}
