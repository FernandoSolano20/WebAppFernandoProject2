using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.TrabajoTipoTrabajo
{
    public class TrabajoTipoTrabajoMapper : EntityMapper, IObjectMapper
    {
        //Atributos inherentes de la tabla Trabajo TipoTrabajo
        private const string DB_COL_ID_TRABAJO = "ID_TRABAJO";
        private const string DB_COL_ID_TIPO_TRABAJO = "ID_TIPO_TRABAJO";
        private const string DB_COL_PRECIO = "PRECIO";
        private const string DB_COL_HORAS_TRABAJADAS = "HORAS_TRABAJADAS";
        private const string DB_COL_CANCELACION = "CANCELACION";

        //Atributos tabla Tipo Trabajo
        private const string DB_COL_NOMBRE_TIPO_TRABAJO = "NOMBRE_TIPO_TRABAJO";

        //Atributos tabla Solicitud
        private const string DB_COL_TITULO_SOLICITUD = "TITULO_SOLICITUD";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRABAJO_TIPO_TRABAJO_INSERT_SP" };
            var trabajoTipoTrabajo = (Entities_POJO.TrabajoTipoTrabajo)entity;

            operation.AddIntParam(DB_COL_ID_TRABAJO, trabajoTipoTrabajo.ID_Trabajo);
            operation.AddIntParam(DB_COL_ID_TIPO_TRABAJO, trabajoTipoTrabajo.ID_Tipo_Trabajo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRABAJO_TIPO_TRABAJO_DELETE_SP" };
            var trabajoTipoTrabajo = (Entities_POJO.TrabajoTipoTrabajo)entity;

            operation.AddIntParam(DB_COL_ID_TRABAJO, trabajoTipoTrabajo.ID_Trabajo);
            operation.AddIntParam(DB_COL_ID_TIPO_TRABAJO, trabajoTipoTrabajo.ID_Tipo_Trabajo);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRABAJO_TIPO_TRABAJO_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRABAJO_TIPO_TRABAJO_SELECT_ID_SP" };
            var trabajoTipoTrabajo = (Entities_POJO.TrabajoTipoTrabajo)entity;

            operation.AddIntParam(DB_COL_ID_TRABAJO, trabajoTipoTrabajo.ID_Trabajo);
            operation.AddIntParam(DB_COL_ID_TIPO_TRABAJO, trabajoTipoTrabajo.ID_Tipo_Trabajo);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRABAJO_TIPO_TRABAJO_UPDATE_SP" };
            var trabajoTipoTrabajo = (Entities_POJO.TrabajoTipoTrabajo)entity;

            operation.AddIntParam(DB_COL_ID_TRABAJO, trabajoTipoTrabajo.ID_Trabajo);
            operation.AddIntParam(DB_COL_ID_TIPO_TRABAJO, trabajoTipoTrabajo.ID_Tipo_Trabajo);
            operation.AddDecimalParam(DB_COL_PRECIO, trabajoTipoTrabajo.Precio);
            operation.AddIntParam(DB_COL_HORAS_TRABAJADAS, trabajoTipoTrabajo.Horas_Trabajadas);
            operation.AddDecimalParam(DB_COL_CANCELACION, trabajoTipoTrabajo.Cancelacion);

            return operation;
        }

        public SqlOperation GetRetriveIDTrabajoStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRABAJO_TIPO_TRABAJO_SELECT_ID_SOLICITUD_SP" };
            var trabajoTipoTrabajo = (Entities_POJO.TrabajoTipoTrabajo)entity;

            operation.AddIntParam(DB_COL_ID_TRABAJO, trabajoTipoTrabajo.ID_Trabajo);

            return operation;
        }


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var trabajoTipoTrabajo = new Entities_POJO.TrabajoTipoTrabajo();
            if (row.ContainsKey(DB_COL_NOMBRE_TIPO_TRABAJO))
            {
                trabajoTipoTrabajo = new Entities_POJO.TrabajoTipoTrabajo()
                {
                    ID_Trabajo = GetIntValue(row, DB_COL_ID_TRABAJO),
                    ID_Tipo_Trabajo = GetIntValue(row, DB_COL_ID_TIPO_TRABAJO),
                    Precio = GetDecimalValue(row, DB_COL_PRECIO),
                    Horas_Trabajadas = GetIntValue(row, DB_COL_HORAS_TRABAJADAS),
                    Cancelacion = GetDecimalValue(row, DB_COL_CANCELACION),
                    NombreTipoTrabajo = GetStringValue(row, DB_COL_NOMBRE_TIPO_TRABAJO),
                    TituloTrabajo = GetStringValue(row, DB_COL_TITULO_SOLICITUD)
                };
            }
            else
            {
                trabajoTipoTrabajo = new Entities_POJO.TrabajoTipoTrabajo()
                {
                    ID_Trabajo = GetIntValue(row, DB_COL_ID_TRABAJO),
                    ID_Tipo_Trabajo = GetIntValue(row, DB_COL_ID_TIPO_TRABAJO),
                    Precio = GetDecimalValue(row, DB_COL_PRECIO),
                    Horas_Trabajadas = GetIntValue(row, DB_COL_HORAS_TRABAJADAS),
                    Cancelacion = GetDecimalValue(row, DB_COL_CANCELACION)
                };
            }
            
            return trabajoTipoTrabajo;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var trabajoTipoTrabajo = BuildObject(element);
                listResults.Add(trabajoTipoTrabajo);
            }
            return listResults;
        }
    }
}
