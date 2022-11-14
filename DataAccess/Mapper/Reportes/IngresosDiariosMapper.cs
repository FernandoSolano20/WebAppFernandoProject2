using DataAccess.Dao;
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

        public SqlOperation GetGananciasDiariasStatement()
        {
            SqlOperation operation = new SqlOperation() { ProcedureName = "REPORTE_GANANCIAS_DIARIAS_PLATAFORMA" };

            return operation;
        }
        
        public IngresosDiarios BuildObject(Dictionary<string, object> row)
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
