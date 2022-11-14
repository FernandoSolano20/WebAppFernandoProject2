using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Detalle
{
    public class DetalleMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_PRECIO = "PRECIO";
        private const string DB_COL_CANTIDAD = "CANTIDAD";
        private const string DB_COL_ID_FACTURA = "IDFACTURA";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DETALLE_INSERT_SP" };
            var detalle = (Entities_POJO.Detalle)entity;

            operation.AddNVarcharParam(DB_COL_NOMBRE, detalle.Nombre);
            operation.AddDecimalParam(DB_COL_PRECIO, detalle.Precio);
            operation.AddIntParam(DB_COL_CANTIDAD, detalle.Cantidad);
            operation.AddIntParam(DB_COL_ID_FACTURA, detalle.ID_Factura);
            operation.AddNVarcharParam(DB_COL_DESCRIPCION, detalle.Descripcion);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_DELETE_SP" };
            var detalle = (Entities_POJO.Detalle)entity;

            operation.AddIntParam(DB_COL_ID, detalle.ID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DETALLE_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DETALLE_SELECT_ID_SP" };
            var detalle = (Entities_POJO.Detalle)entity;

            operation.AddIntParam(DB_COL_ID, detalle.ID);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DETALLE_UPDATE_SP" };
            var detalle = (Entities_POJO.Detalle)entity;

            operation.AddIntParam(DB_COL_ID, detalle.ID);
            operation.AddNVarcharParam(DB_COL_NOMBRE, detalle.Nombre);
            operation.AddDecimalParam(DB_COL_PRECIO, detalle.Precio);
            operation.AddIntParam(DB_COL_CANTIDAD, detalle.Cantidad);
            operation.AddIntParam(DB_COL_ID_FACTURA, detalle.ID_Factura);
            operation.AddNVarcharParam(DB_COL_DESCRIPCION, detalle.Descripcion);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var detalle = new Entities_POJO.Detalle()
            {
                ID = GetIntValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Precio = GetDecimalValue(row, DB_COL_PRECIO),
                Cantidad = GetIntValue(row, DB_COL_CANTIDAD),
                ID_Factura = GetIntValue(row, DB_COL_ID_FACTURA),
                Descripcion = GetStringValue(row, DB_COL_DESCRIPCION)
            };

            return detalle;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var detalle = BuildObject(element);
                listResults.Add(detalle);
            }
            return listResults;
        }
    }
}
