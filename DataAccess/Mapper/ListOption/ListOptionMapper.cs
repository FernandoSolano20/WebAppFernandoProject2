using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;
using POJO_Entities.Entities;

namespace DataAccess.Mapper.ListOption
{
    public class ListOptionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_LIST_ID = "LIST_ID";
        private const string DB_LIST_VALUE = "LIST_VALUE";
        private const string DB_LIST_DESC = "LIST_DESCRIPCION";

        //Columnas de tipos de trabajo y especialidades
        private const string DB_LIST_ESTADO = "ESTADO"; 


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var option = BuildObject(row);
                lstResults.Add(option);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var listOption = new OptionList();

            if (row[DB_LIST_ID].Equals("LST_TIPO_TRABAJO")|| row[DB_LIST_ID].Equals("LST_ESPECIALIDAD"))
            {
                listOption = new OptionList
                {
                    ListId = GetStringValue(row, DB_LIST_ID),
                    Value = Convert.ToString(GetIntValue(row, DB_LIST_VALUE)),
                    Description = GetStringValue(row, DB_LIST_DESC)
                };
            }
            else
            {
                listOption = new OptionList
                {
                    ListId = GetStringValue(row, DB_LIST_ID),
                    Value = GetStringValue(row, DB_LIST_VALUE),
                    Description = GetStringValue(row, DB_LIST_DESC)
                };
            }

            return listOption;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "TBL_LIST_OPTION_RETRIVE_ALL_LIST_OPTION_SP" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveTiposTrabajoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_RETRIEVE_AS_LIST_OPTION" };

            var optionList = (OptionList)entity;
            operation.AddNVarcharParam(DB_LIST_ID, optionList.ListId);
            operation.AddNVarcharParam(DB_LIST_ESTADO, optionList.Value);

            return operation;
        }

        public SqlOperation GetRetriveEspecialidadesStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_ESPECIALIDAD_RETRIEVE_AS_LIST_OPTION" };

            var optionList = (OptionList)entity;
            operation.AddNVarcharParam(DB_LIST_ID, optionList.ListId);
            operation.AddNVarcharParam(DB_LIST_ESTADO, optionList.Value);
            
            return operation;
        }

    }
}
