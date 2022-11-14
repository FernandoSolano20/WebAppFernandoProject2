using DataAccess.Dao;
using DataAccess.Mapper.TrabajoEspecialidad;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud.TrabajoEspecialidad
{
    public class TrabajoEspecialidadFactory
    {
        private TrabajoEspecialidadMapper mapper;
        private SqlDao dao;

        public TrabajoEspecialidadFactory()
        {
            mapper = new TrabajoEspecialidadMapper();
            dao = SqlDao.GetInstance();
        }

        public void Create(BaseEntity entity)
        {
            var trabajoEspecialidad = (Entities_POJO.TrabajoEspecialidad)entity;
            var sqlOperation = mapper.GetCreateStatement(trabajoEspecialidad);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void Delete(BaseEntity entity)
        {
            var trabajoEspecialidad = (Entities_POJO.TrabajoEspecialidad)entity;
            var sqlOperation = mapper.GetDeleteStatement(trabajoEspecialidad);
            dao.ExecuteProcedure(sqlOperation);
        }

        public List<T> RetrieveAll<T>()
        {
            var resultList = new List<T>();
            var sqlOperation = mapper.GetRetriveAllStatement();
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);


            if (queryResult.Count > 0)
            {
                var finalObjects = mapper.BuildObjects(queryResult);

                foreach (var element in finalObjects)
                {
                    resultList.Add((T)Convert.ChangeType(element, typeof(T)));
                }
            }
            return resultList;
        }

        public T Retrieve<T>(BaseEntity entity)
        {
            var trabajoEspecialidad = (Entities_POJO.TrabajoEspecialidad)entity;
            var sqlOperation = mapper.GetRetriveStatement(trabajoEspecialidad);
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

        public List<T> RetrieveIDTrabajo<T>(BaseEntity baseEntity)
        {
            var trabajoEspecialidad = (Entities_POJO.TrabajoEspecialidad)baseEntity;
            var resultList = new List<T>();
            var sqlOperation = mapper.GetRetriveIDTrabajoStatement(trabajoEspecialidad);
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);


            if (queryResult.Count > 0)
            {
                var finalObjects = mapper.BuildObjects(queryResult);

                foreach (var element in finalObjects)
                {
                    resultList.Add((T)Convert.ChangeType(element, typeof(T)));
                }
            }
            return resultList;
        }
    }
}
