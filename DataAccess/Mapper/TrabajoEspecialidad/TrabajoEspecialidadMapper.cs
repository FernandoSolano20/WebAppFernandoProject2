using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.TrabajoEspecialidad
{
    public class TrabajoEspecialidadMapper : EntityMapper, IObjectMapper
    {
        //Atributos inherentes de la tabla Trabajo TipoTrabajo
        private const string DB_COL_ID_TRABAJO = "ID_TRABAJO";
        private const string DB_COL_ID_ESPECIALIDAD = "ID_ESPECIALIDAD";

        //Atributos tabla Tipo Trabajo
        private const string DB_COL_NOMBRE_ESPECIALIDAD = "NOMBRE_ESPECIALIDAD";

        //Atributos tabla Solicitud
        private const string DB_COL_TITULO_SOLICITUD = "TITULO_SOLICITUD";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRABAJO_ESPECIALIDAD_INSERT_SP" };
            var trabajoEspecialidad = (Entities_POJO.TrabajoEspecialidad)entity;

            operation.AddIntParam(DB_COL_ID_TRABAJO, trabajoEspecialidad.ID_Trabajo);
            operation.AddIntParam(DB_COL_ID_ESPECIALIDAD, trabajoEspecialidad.ID_Especialidad);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRABAJO_ESPECIALIDAD_DELETE_SP" };
            var trabajoEspecialidad = (Entities_POJO.TrabajoEspecialidad)entity;

            operation.AddIntParam(DB_COL_ID_TRABAJO, trabajoEspecialidad.ID_Trabajo);
            operation.AddIntParam(DB_COL_ID_ESPECIALIDAD, trabajoEspecialidad.ID_Especialidad);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRABAJO_ESPECIALIDAD_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRABAJO_ESPECIALIDAD_SELECT_ID_SP" };
            var trabajoEspecialidad = (Entities_POJO.TrabajoEspecialidad)entity;

            operation.AddIntParam(DB_COL_ID_TRABAJO, trabajoEspecialidad.ID_Trabajo);
            operation.AddIntParam(DB_COL_ID_ESPECIALIDAD, trabajoEspecialidad.ID_Especialidad);

            return operation;
        }

        public SqlOperation GetRetriveIDTrabajoStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRABAJO_ESPECIALIDAD_SELECT_ID_SOLICITUD_SP" };
            var trabajoEspecialidad = (Entities_POJO.TrabajoEspecialidad)entity;

            operation.AddIntParam(DB_COL_ID_TRABAJO, trabajoEspecialidad.ID_Trabajo);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var trabajoEspecialidad = new Entities_POJO.TrabajoEspecialidad();

            if (row.ContainsKey(DB_COL_NOMBRE_ESPECIALIDAD))
            {
                trabajoEspecialidad = new Entities_POJO.TrabajoEspecialidad()
                {
                    ID_Trabajo = GetIntValue(row, DB_COL_ID_TRABAJO),
                    ID_Especialidad = GetIntValue(row, DB_COL_ID_ESPECIALIDAD),
                    NombreEspecialidad = GetStringValue(row, DB_COL_NOMBRE_ESPECIALIDAD),
                    TituloTrabajo = GetStringValue(row, DB_COL_TITULO_SOLICITUD)
                };
            }
            else
            {
                trabajoEspecialidad = new Entities_POJO.TrabajoEspecialidad()
                {
                    ID_Trabajo = GetIntValue(row, DB_COL_ID_TRABAJO),
                    ID_Especialidad = GetIntValue(row, DB_COL_ID_ESPECIALIDAD)
                };
            }

            return trabajoEspecialidad;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var trabajoEspecialidad = BuildObject(element);
                listResults.Add(trabajoEspecialidad);
            }
            return listResults;
        }
    }
}
