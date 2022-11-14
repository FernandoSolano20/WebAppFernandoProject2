using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper.TiposTrabajoXTrabJuridico
{
    public class TiposTrabajoXTrabJuridicoMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        //Columnas de TBL_TIPO_TRABAJO_TRABAJADOR
        private const string DB_COL_ID_TIPO_TRABAJO = "ID_TIPO_TRABAJO";
        private const string DB_COL_ID_TRABAJADOR = "ID_TRABAJADOR";     //***//
        private const string DB_COL_PRECIO_HORA = "PRECIO_HORA";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_ESTADO = "ESTADO";



        //--Select todos los campos en TBL_TIPO_TRABAJO_TRABAJADOR
        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_SELECT_ALL_SP" };

            return operation;
        }


        //--Select por ID_TRABAJADOR en TBL_TIPO_TRABAJO_TRABAJADOR
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_SELECT_ID_TRABAJADOR_SP" };
            var tipoTrabajoTrabajdor = (Entities_POJO.TipoTrabajoTrabajador)entity;

            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, tipoTrabajoTrabajdor.Id_Trabajador);

            return operation;
        }


        //--Select por Estado en TBL_TIPO_TRABAJO_TRABAJADOR
        public SqlOperation GetRetriveStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_SELECT_ESTADO_SP" };
            var tipoTrabajoTrabajdor = (Entities_POJO.TipoTrabajoTrabajador)entity;

            operation.AddNVarcharParam(DB_COL_ESTADO, tipoTrabajoTrabajdor.Estado);

            return operation;
        }


        //--(Select también): SP para mostrar del trabajador X: Id, nombre, apellidos, tipos de trabajo, precio x hora y estado.
        public SqlOperation GetRetrieveJobsAvailableStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_TRABAJOS_DISPONIBLES_SP" };

            return operation;
        }

        
        //--Insert en TBL_TIPO_TRABAJO_TRABAJADOR
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_INSERT_SP" };
            var tipoTrabajoTrabajador = (Entities_POJO.TipoTrabajoTrabajador)entity;   

            operation.AddIntParam(DB_COL_ID_TIPO_TRABAJO, tipoTrabajoTrabajador.Id_TipoTrabajo);
            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, tipoTrabajoTrabajador.Id_Trabajador);
            operation.AddDecimalParam(DB_COL_PRECIO_HORA, tipoTrabajoTrabajador.Precio_Hora);
            operation.AddDatetimeParam(DB_COL_FECHA, tipoTrabajoTrabajador.Fecha);
            operation.AddNVarcharParam(DB_COL_ESTADO, tipoTrabajoTrabajador.Estado);
            

            return operation;
        }


        //Update No se usa para este CU. (Solo Update Estado).
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }


        //--Update Estado en TBL_TIPO_TRABAJO_TRABAJADOR
        public SqlOperation GetUpdateStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_UPDATE_STATUS_SP" };
            var tipoTrabajoTrabajdor = (Entities_POJO.TipoTrabajoTrabajador)entity;

            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, tipoTrabajoTrabajdor.Id_Trabajador);
            operation.AddNVarcharParam(DB_COL_ESTADO, tipoTrabajoTrabajdor.Estado);

            return operation;
        }


        //--Delete en TBL_TIPO_TRABAJO_TRABAJADOR
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_DELETE_SP" };
            var tipoTrabajoTrabajador = (Entities_POJO.TipoTrabajoTrabajador)entity;

            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, tipoTrabajoTrabajador.Id_Trabajador);

            return operation;
        }



        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var tipoTrabajoTrabajador = new Entities_POJO.TipoTrabajoTrabajador()
            {
                Id_TipoTrabajo = GetIntValue(row, DB_COL_ID_TIPO_TRABAJO),
                Id_Trabajador = GetStringValue(row, DB_COL_ID_TRABAJADOR),
                Precio_Hora = GetDecimalValue(row, DB_COL_PRECIO_HORA),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                Estado = GetStringValue(row, DB_COL_ESTADO)
                
            };

            return tipoTrabajoTrabajador;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var tipoTrabajoTrabajador = BuildObject(element);
                listResults.Add(tipoTrabajoTrabajador);
            }
            return listResults;
        }

        
    }
}
