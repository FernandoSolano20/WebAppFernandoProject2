using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.EspecialidadTrabajador
{
    public class EspecialidadTrabajadorMapper : EntityMapper, IObjectMapper, ISqlStaments
    { 
        //Atributos inherentes de la tabla
        private const string DB_COL_ID_ESPECIALIDAD = "ID_ESPECIALIDAD";
        private const string DB_COL_ID_TRABAJADOR = "ID_TRABAJADOR";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_APELLIDOS = "APELLIDOS";
        private const string DB_COL_ESPECIALIDAD = "ESPECIALIDAD";
        private const string DB_COL_ESTADO = "ESTADO";
        //Atributos de la tabla Tipo_Trabajo_Trabajador

       // private const string DB_ID_TIPO_TRABAJO = "ID_TIPO_TRABAJO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_TRABAJADOR_CREATE_SP" };
            var c = (Entities_POJO.EspecialidadTrabajador)entity;
            operation.AddIntParam(DB_COL_ID_ESPECIALIDAD, c.ID_Especialidad);
            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, c.ID_Trabajador);
            operation.AddNVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddNVarcharParam(DB_COL_APELLIDOS, c.Apellidos);
            operation.AddNVarcharParam(DB_COL_ESPECIALIDAD, c.Especialidad);
            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_TRABAJADOR_DELETE_SP" };
            var c = (Entities_POJO.EspecialidadTrabajador)entity;

            operation.AddIntParam(DB_COL_ID_ESPECIALIDAD, c.ID_Especialidad);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_TRABAJADOR_TRABAJOS_DISPONIBLES_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_TRABAJADOR_RETRIEVE_ID_SP" };
            var c = (Entities_POJO.EspecialidadTrabajador)entity;

            operation.AddIntParam(DB_COL_ID_ESPECIALIDAD, c.ID_Especialidad);

            return operation;
        }

        public SqlOperation GetRetriveStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_TRABAJADOR_SELECT_ESTADO_SP" };
            var c = (Entities_POJO.EspecialidadTrabajador)entity;

            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);

            return operation;
        }

        /**public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_UPDATE_SP" };
            var c = (Entities_POJO.EspecialidadTrabajador)entity;

            operation.AddIntParam(DB_COL_ID_ESPECIALIDAD, c.ID_Especialidad);
            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, c.ID_Trabajador);

            return operation;
        }**/

        public SqlOperation GetUpdateStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_TRABAJADOR_UPDATE_STATUS_SP" };
            var c = (Entities_POJO.EspecialidadTrabajador)entity;

            operation.AddIntParam(DB_COL_ID_ESPECIALIDAD, c.ID_Especialidad);
            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var c = new Entities_POJO.EspecialidadTrabajador()
            {
                ID_Especialidad = GetIntValue(row, DB_COL_ID_ESPECIALIDAD),
                ID_Trabajador = GetStringValue(row, DB_COL_ID_TRABAJADOR),
               Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Apellidos = GetStringValue(row, DB_COL_APELLIDOS),
                Especialidad = GetStringValue(row, DB_COL_ESPECIALIDAD),
                Estado = GetStringValue(row, DB_COL_ESTADO)
            };
            return c;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var c = BuildObject(element);
                listResults.Add(c);
            }
            return listResults;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

