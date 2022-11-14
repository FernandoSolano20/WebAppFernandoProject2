using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Especialidad
{
    public class EspecialidadMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        //Atributos inherentes de la tabla Especialidad
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_ESTADO = "ESTADO";

        //Atributos de la tabla Tipo_Trabajo_Trabajador
        private const string DB_ID_ESPECIALIDAD = "ID_ESPECIALIDAD";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_INSERT_SP" };
            var Especialidad = (Entities_POJO.Especialidad)entity;

            operation.AddNVarcharParam(DB_COL_NOMBRE, Especialidad.Nombre);
            operation.AddNVarcharParam(DB_COL_ESTADO, Especialidad.Estado);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_DELETE_SP" };
            var Especialidad = (Entities_POJO.Especialidad)entity;

            operation.AddIntParam(DB_COL_ID, Especialidad.ID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_SELECT_ID_SP" };
            var Especialidad = (Entities_POJO.Especialidad)entity;

            operation.AddIntParam(DB_COL_ID, Especialidad.ID);

            return operation;
        }

        public SqlOperation GetRetriveStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_SELECT_ESTADO_SP" };
            var Especialidad = (Entities_POJO.Especialidad)entity;

            operation.AddNVarcharParam(DB_COL_ESTADO, Especialidad.Estado);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_UPDATE_SP" };
            var Especialidad = (Entities_POJO.Especialidad)entity;

            operation.AddIntParam(DB_COL_ID, Especialidad.ID);
            operation.AddNVarcharParam(DB_COL_NOMBRE, Especialidad.Nombre);

            return operation;
        }

        public SqlOperation GetUpdateStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_UPDATE_STATUS_SP" };
            var Especialidad = (Entities_POJO.Especialidad)entity;

            operation.AddIntParam(DB_COL_ID, Especialidad.ID);
            operation.AddNVarcharParam(DB_COL_ESTADO, Especialidad.Estado);

            return operation;
        }

        //Operaciones para obtener los tipos de trabajo relacionados con trabajadores
        public SqlOperation GetRetriveSelectAllJobTypeWorkerStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_TRABAJADOR_SELECT_ESTADO_SP" };
            var Especialidad = (Entities_POJO.Especialidad)entity;

            operation.AddIntParam(DB_ID_ESPECIALIDAD, Especialidad.ID);
            operation.AddNVarcharParam(DB_COL_ESTADO, Especialidad.Estado);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var Especialidad = new Entities_POJO.Especialidad()
            {
                ID = GetIntValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Estado = GetStringValue(row, DB_COL_ESTADO)
            };

            return Especialidad;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var Especialidad = BuildObject(element);
                listResults.Add(Especialidad);
            }
            return listResults;
        }
    }
}
