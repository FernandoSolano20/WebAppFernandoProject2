using DataAccess.Dao;
using Entities_POJO;
using Entities_POJO.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Reportes
{
    public class IngresosDiariosMapper : EntityMapper
    {
        private const string DB_MONTO_TOTAL = "MONTO_TOTAL";
        private const string DB_FECHA = "FECHA";
        private const string DB_MOVIMIENTO = "MOVIMIENTO";


        public SqlOperation GetGananciasDiariasStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation() { ProcedureName = "TBL_TRANSACCION_REPORTE_INGRESOS_DIARIOS_SP" };
            var reporte = (IngresosDiarios)entity;

            operation.AddNVarcharParam(DB_MOVIMIENTO, reporte.TipoTransaccion);

            return operation;
        }
        
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var reporte = new IngresosDiarios()
            {
                MontoTotal = GetDecimalValue(row, DB_MONTO_TOTAL),
                Fecha = GetDateValue(row, DB_FECHA)
            };
            return reporte;
        }
    }
}
