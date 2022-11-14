using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Mapper.Reportes;
using Entities_POJO;
using Entities_POJO.Reportes;

namespace DataAccess.Crud.Reportes
{
    public class IngresosDiariosFactory
    {
        private IngresosDiariosMapper mapper;
        private SqlDao dao;

        public IngresosDiariosFactory()
        {
            mapper = new IngresosDiariosMapper();
            dao = SqlDao.GetInstance();
        }

        public T Retrieve<T>(IngresosDiarios ingresosDiarios)
        {
            var resultList = new List<T>();
            var sqlOperation = mapper.GetGananciasDiariasStatement(ingresosDiarios);
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);
            var objectDictionary = new Dictionary<string, object>();

            if (queryResult.Count > 0)
            {
                objectDictionary = queryResult[0];
                var finalObject = mapper.BuildObject(objectDictionary);
                return (T)Convert.ChangeType(finalObject, typeof(T));
            }

            return default(T);
        }
    }
}
