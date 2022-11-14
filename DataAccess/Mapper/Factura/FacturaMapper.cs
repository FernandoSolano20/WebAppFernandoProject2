using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Factura
{
    public class FacturaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        public const string DB_COL_ID = "ID";
        public const string DB_COL_FECHA = "FECHA";
        public const string DB_COL_ID_TRANSACCION = "ID_TRANSACCION";
        public const string DB_COL_ID_PROVEEDOR = "ID_PROVEEDOR";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_FACTURA_INSERT_SP" };
            var factura = (Entities_POJO.Factura)entity;

            operation.AddDatetimeParam(DB_COL_FECHA, factura.Fecha);
            operation.AddIntParam(DB_COL_ID_TRANSACCION, factura.ID_Transaccion);
            operation.AddNVarcharParam(DB_COL_ID_PROVEEDOR, factura.ID_Proveedor);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_FACTURA_DELETE_SP" };
            var factura = (Entities_POJO.Factura)entity;

            operation.AddIntParam(DB_COL_ID, factura.ID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_FACTURA_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_FACTURA_SELECT_ID_SP" };
            var factura = (Entities_POJO.Factura)entity;

            operation.AddIntParam(DB_COL_ID, factura.ID);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_UPDATE_SP" };
            var factura = (Entities_POJO.Factura)entity;

            operation.AddIntParam(DB_COL_ID, factura.ID);
            operation.AddDatetimeParam(DB_COL_FECHA, factura.Fecha);
            operation.AddIntParam(DB_COL_ID_TRANSACCION, factura.ID_Transaccion);
            operation.AddNVarcharParam(DB_COL_ID_PROVEEDOR, factura.ID_Proveedor);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var factura = new Entities_POJO.Factura()
            {
                ID = GetIntValue(row, DB_COL_ID),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                ID_Proveedor = GetStringValue(row, DB_COL_ID_PROVEEDOR),
                ID_Transaccion = GetIntValue(row, DB_COL_ID_TRANSACCION)
            };

            return factura;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var factura = BuildObject(element);
                listResults.Add(factura);
            }
            return listResults;
        }
    }
}
