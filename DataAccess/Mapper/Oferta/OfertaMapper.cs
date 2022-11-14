using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper.Oferta
{
    public class OfertaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_EMPRESA = "ID_EMPRESA";
        private const string DB_COL_ID_SOLICITUD = "ID_SOLICITUD";
        private const string DB_COL_PRECIO = "PRECIO";
        private const string DB_COL_TIPO_COBRO = "TIPO_COBRO";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_CANCELACION = "CANCELACION";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_MONEDA = "MONEDA";
        private const string DB_COL_PROMEDIO = "PROMEDIO";

        //Informacion de la empresa
        private const string DB_COL_NOMBRE_COMERCIAL = "NOMBRE_COMERCIAL";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_OFERTA_CRE_OFERTA_SP" };

            var c = (Entities_POJO.Oferta)entity;
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);
            operation.AddDecimalParam(DB_COL_PRECIO, c.Precio);
            operation.AddNVarcharParam(DB_COL_TIPO_COBRO, c.TipoCobro);
            operation.AddDatetimeParam(DB_COL_FECHA, c.Fecha);
            operation.AddDecimalParam(DB_COL_CANCELACION, c.Cancelacion);
            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddNVarcharParam(DB_COL_MONEDA, c.Moneda);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_OFERTA_RET_OFERTA_ID_SP" };

            var c = (Entities_POJO.Oferta)entity;
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);

            return operation;
        }

        public SqlOperation GetRetriveByEmpresaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_OFERTA_RET_OFERTA_ID_EMPRESA_SP" };

            var c = (Entities_POJO.Oferta)entity;
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);

            return operation;
        }

        public SqlOperation GetRetriveAverageStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_OFERTA_RET_OFERTA_ID_SOLICITUD_AVERAGE_SP" };

            var c = (Entities_POJO.Oferta)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);

            return operation;
        }

        public SqlOperation GetRetriveLowestOfferStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_OFERTA_RET_LOWEST_OFERTA_ID_SOLICITUD_SP" };

            var c = (Entities_POJO.Oferta)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_OFERTA_UPD_OFERTA_SP" };

            var c = (Entities_POJO.Oferta)entity;
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);
            operation.AddDecimalParam(DB_COL_PRECIO, c.Precio);
            operation.AddNVarcharParam(DB_COL_TIPO_COBRO, c.TipoCobro);
            operation.AddDatetimeParam(DB_COL_FECHA, c.Fecha);
            operation.AddDecimalParam(DB_COL_CANCELACION, c.Cancelacion);

            return operation;
        }

        public SqlOperation GetUpdateStatusStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_OFERTA_UPDATE_STATUS_SP" };

            var c = (Entities_POJO.Oferta)entity;
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);
            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_OFERTA_DEL_OFERTA_SP" };

            var c = (Entities_POJO.Oferta)entity;
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);

            return operation;
        }

        //Obtener ofertas por id de solicitud
        public SqlOperation GetRetrieveAllPerSolicitudId(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_OFERTA_RETRIEVE_ID_SOLICITUD_SP" };

            var oferta = (Entities_POJO.Oferta)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, oferta.IdSolicitud);
            operation.AddNVarcharParam(DB_COL_ESTADO, oferta.Estado);

            return operation;
        }

        public SqlOperation GetRetrieveConEmpresaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_OFERTA_RETRIEVE_ID_SOLICITUD_EMPRESA_SP" };

            var c = (Entities_POJO.Oferta)entity;
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var oferta = new Entities_POJO.Oferta();

            if (row.ContainsKey(DB_COL_NOMBRE_COMERCIAL))
            {
                oferta = new Entities_POJO.Oferta
                {
                    IdEmpresa = GetStringValue(row, DB_COL_ID_EMPRESA),
                    IdSolicitud = GetIntValue(row, DB_COL_ID_SOLICITUD),
                    Precio = GetDecimalValue(row, DB_COL_PRECIO),
                    TipoCobro = GetStringValue(row, DB_COL_TIPO_COBRO),
                    Fecha = GetDateValue(row, DB_COL_FECHA),
                    Cancelacion = GetDecimalValue(row, DB_COL_CANCELACION),
                    Estado = GetStringValue(row, DB_COL_ESTADO),
                    Moneda = GetStringValue(row, DB_COL_MONEDA),
                    NombreComercial = GetStringValue(row, DB_COL_NOMBRE_COMERCIAL),
                    FormatoFecha = GetDateValue(row, DB_COL_FECHA).ToString("dd/MM/yyyy")
                };
            }
            else
            {
                oferta = new Entities_POJO.Oferta
                {
                    IdEmpresa = GetStringValue(row, DB_COL_ID_EMPRESA),
                    IdSolicitud = GetIntValue(row, DB_COL_ID_SOLICITUD),
                    Precio = GetDecimalValue(row, DB_COL_PRECIO),
                    TipoCobro = GetStringValue(row, DB_COL_TIPO_COBRO),
                    Fecha = GetDateValue(row, DB_COL_FECHA),
                    Cancelacion = GetDecimalValue(row, DB_COL_CANCELACION),
                    Estado = GetStringValue(row, DB_COL_ESTADO),
                    Moneda = GetStringValue(row, DB_COL_MONEDA)
                };
            }
            

            return oferta;
        }

        public BaseEntity BuildObjectAverage(Dictionary<string, object> row)
        {
            var customer = new Entities_POJO.Oferta
            {
                Promedio = GetDecimalValue(row, DB_COL_PROMEDIO),
            };

            return customer;
        }
    }
}
