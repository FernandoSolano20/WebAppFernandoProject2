using DataAccess.Dao;
using DataAccess.Mapper.TrabajoTipoTrabajo;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud.TrabajoTipoTrabajo
{
    public class TrabajoTipoTrabajoFactory
    {
        private TrabajoTipoTrabajoMapper mapper;
        private SqlDao dao;

        public TrabajoTipoTrabajoFactory()
        {
            mapper = new TrabajoTipoTrabajoMapper();
            dao = SqlDao.GetInstance();
        }

        public void Create(BaseEntity entity)
        {
            var trabajoTipoTrabajo = (Entities_POJO.TrabajoTipoTrabajo)entity;
            var sqlOperation = mapper.GetCreateStatement(trabajoTipoTrabajo);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void Delete(BaseEntity entity)
        {
            var trabajoTipoTrabajo = (Entities_POJO.TrabajoTipoTrabajo)entity;
            var sqlOperation = mapper.GetDeleteStatement(trabajoTipoTrabajo);
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
            var trabajoTipoTrabajo = (Entities_POJO.TrabajoTipoTrabajo)entity;
            var sqlOperation = mapper.GetRetriveStatement(trabajoTipoTrabajo);
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

        public void Update(BaseEntity entity)
        {
            var trabajoTipoTrabajo = (Entities_POJO.TrabajoTipoTrabajo)entity;
            var sqlOperation = mapper.GetUpdateStatement(trabajoTipoTrabajo);
            dao.ExecuteProcedure(sqlOperation);
        }

        public List<T> RetrieveIDTrabajo<T>(BaseEntity baseEntity)
        {
            var trabajoTipoTrabajo = (Entities_POJO.TrabajoTipoTrabajo)baseEntity;
            var resultList = new List<T>();
            var sqlOperation = mapper.GetRetriveIDTrabajoStatement(trabajoTipoTrabajo);
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
