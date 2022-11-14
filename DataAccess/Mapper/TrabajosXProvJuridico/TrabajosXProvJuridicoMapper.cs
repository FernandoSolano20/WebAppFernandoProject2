using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper.TrabajosXProvJuridico
{
    public class TrabajosXProvJuridicoMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        
        private const string DB_COL_ID_TIPO_TRABAJO = "ID_TIPO_TRABAJO";
        private const string DB_COL_ID_TRABAJADOR = "ID_TRABAJADOR";     //***//
        private const string DB_COL_PRECIO_HORA = "PRECIO_HORA";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_NOMBRE = "NOMBRE_TRABAJADOR";
        private const string DB_COL_APELLIDOS = "APELLIDOS_TRABAJADOR";
        private const string DB_COL_TIPO_TRABAJO = "TIPO_TRABAJO";


        //--Insert en TBL_TIPO_TRABAJO_TRABAJADOR
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_INSERT_SP" };
            var trabajosProvJuridico = (Entities_POJO.TipoTrabajoTrabajador)entity;

            operation.AddIntParam(DB_COL_ID_TIPO_TRABAJO, trabajosProvJuridico.Id_TipoTrabajo);
            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, trabajosProvJuridico.Id_Trabajador);
            operation.AddDecimalParam(DB_COL_PRECIO_HORA, trabajosProvJuridico.Precio_Hora);
            operation.AddDatetimeParam(DB_COL_FECHA, trabajosProvJuridico.Fecha);
            operation.AddNVarcharParam(DB_COL_ESTADO, trabajosProvJuridico.Estado);

            return operation;
        }



        //--Select todos los campos en TBL_TIPO_TRABAJO_TRABAJADOR
        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_SELECT_ALL_SP" };

            return operation;
        }


        //--Select por ID_TRABAJADOR en TBL_TIPO_TRABAJO_TRABAJADOR
        public SqlOperation GetRetrieveTrabajadorStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_SELECT_ID_TRABAJADOR_SP" };
            var trabajosProvJuridico = (Entities_POJO.TipoTrabajoTrabajador)entity;

            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, trabajosProvJuridico.Id_Trabajador);

            return operation;
        }
        

        //--Select por Estado en TBL_TIPO_TRABAJO_TRABAJADOR
        public SqlOperation GetRetriveStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_SELECT_ESTADO_SP" };
            var trabajosProvJuridico = (Entities_POJO.TipoTrabajoTrabajador)entity;

            operation.AddNVarcharParam(DB_COL_ESTADO, trabajosProvJuridico.Estado);

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
            var trabajosProvJuridico = (Entities_POJO.TipoTrabajoTrabajador)entity;

            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, trabajosProvJuridico.Id_Trabajador);
            operation.AddNVarcharParam(DB_COL_ESTADO, trabajosProvJuridico.Estado);

            return operation;
        }


        //--Delete en TBL_TIPO_TRABAJO_TRABAJADOR
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_DELETE_SP" };
            var trabajosProvJuridico = (Entities_POJO.TipoTrabajoTrabajador)entity;

            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, trabajosProvJuridico.Id_Trabajador);

            return operation;
        }

        //Este no aplica
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        //-----------------------------------------Constructor de Objetos-------------------------------------------------//

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var trabajosProvJuridico = new Entities_POJO.TipoTrabajoTrabajador()
            {
                Id_TipoTrabajo = GetIntValue(row, DB_COL_ID_TIPO_TRABAJO),
                Id_Trabajador = GetStringValue(row, DB_COL_ID_TRABAJADOR),
                Precio_Hora = GetDecimalValue(row, DB_COL_PRECIO_HORA),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                nombreTrabajador = GetStringValue(row, DB_COL_NOMBRE),
                apellidosTrabajador = GetStringValue(row, DB_COL_APELLIDOS),
                tipoTrabajo = GetStringValue(row, DB_COL_TIPO_TRABAJO)
                
            };

            return trabajosProvJuridico;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var trabajosProvJuridico = BuildObject(element);
                listResults.Add(trabajosProvJuridico);
            }
            return listResults;
        }

        
    }
}
