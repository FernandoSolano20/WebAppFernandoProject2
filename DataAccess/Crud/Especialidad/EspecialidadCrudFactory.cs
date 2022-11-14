using DataAccess.Dao;
using DataAccess.Mapper.Especialidad;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud.Especialidad
{
    public class EspecialidadCrudFactory : CrudFactory
    {
        private EspecialidadMapper mapper;

        public EspecialidadCrudFactory()
        {
            mapper = new EspecialidadMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var especialidad = (Entities_POJO.Especialidad)entity;
            var sqlOperation = mapper.GetCreateStatement(especialidad);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var especialidad = (Entities_POJO.Especialidad)entity;
            var sqlOperation = mapper.GetDeleteStatement(especialidad);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var especialidad = (Entities_POJO.Especialidad)entity;
            var sqlOperation = mapper.GetRetriveStatement(especialidad);
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

        //Agregar a la interfaz ISQLStatement
        public List<T> RetrieveStatus<T>(BaseEntity entity)
        {
            var especialidad = (Entities_POJO.Especialidad)entity;
            var sqlOperation = mapper.GetRetriveStatusStatement(especialidad);
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);
            var resultList = new List<T>();

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

        public override List<T> RetrieveAll<T>()
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

        //Metodo que busca en la tabla TBL_ESPECIALIDAD_TRABAJADOR si existe algun registro relacionado con un tipo de trabajo especifico. Esto para validar que al borrar o desactivar un registro, este no afecte ninguna otra parte de la aplicacion
        public bool RetrieveJobTypeWorkerPerStatus(BaseEntity entity)
        {
            var exist = false;
            var especialidad = (Entities_POJO.Especialidad)entity;
            var sqlOperation = mapper.GetRetriveSelectAllJobTypeWorkerStatement(especialidad);
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);


            if (queryResult.Count > 0)
            {
                exist = true;
            }
            return exist;
        }

        public override void Update(BaseEntity entity)
        {
            var especialidad = (Entities_POJO.Especialidad)entity;
            var sqlOperation = mapper.GetUpdateStatement(especialidad);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void UpdateStatus(BaseEntity entity)
        {
            var especialidad = (Entities_POJO.Especialidad)entity;
            var sqlOperation = mapper.GetUpdateStatusStatement(especialidad);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
