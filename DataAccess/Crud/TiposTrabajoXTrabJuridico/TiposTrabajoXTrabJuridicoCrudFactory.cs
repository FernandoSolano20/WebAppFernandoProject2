using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper.TiposTrabajoXTrabJuridico;
using Entities_POJO;

namespace DataAccess.Crud.TiposTrabajoXTrabJuridico
{
    public class TiposTrabajoXTrabJuridicoCrudFactory : CrudFactory
    {
        private TiposTrabajoXTrabJuridicoMapper mapper;
        private SqlDao dao;

        public TiposTrabajoXTrabJuridicoCrudFactory()
        {
            mapper = new TiposTrabajoXTrabJuridicoMapper();
            dao = SqlDao.GetInstance();
        }


        //Create
        public override void Create(BaseEntity entity)
        {
            var tiposTrabajoTrabajador = (Entities_POJO.TipoTrabajoTrabajador)entity;
            var sqlOperation = mapper.GetCreateStatement(tiposTrabajoTrabajador);
            dao.ExecuteProcedure(sqlOperation);
        }
        

        //Get all
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


        //Get by Id_Trabajador
        public override T Retrieve<T>(BaseEntity entity)
        {
            var tiposTrabajoTrabajador = (Entities_POJO.TipoTrabajoTrabajador)entity;
            var sqlOperation = mapper.GetRetriveStatement(tiposTrabajoTrabajador);
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


        //Get by Estado                                             
        public List<T> RetrieveStatus<T>(BaseEntity entity)
        {
            var tiposTrabajoTrabajador = (Entities_POJO.TipoTrabajoTrabajador)entity;
            var sqlOperation = mapper.GetRetriveStatusStatement(tiposTrabajoTrabajador);
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


        //Get trabajos disponibles para trabajador
        public List<T> RetrieveJobsAvailable<T>(BaseEntity entity)
        {
            var tiposTrabajoTrabajador = (Entities_POJO.TipoTrabajoTrabajador)entity;
            var sqlOperation = mapper.GetRetrieveJobsAvailableStatement(tiposTrabajoTrabajador);
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


        //Update: no aplica para este CU (Tipos de trabajo por trabajador jurídico)
        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }


        //Update Estado
        public void UpdateStatus(BaseEntity entity)
        {
            var tiposTrabajoTrabajador = (Entities_POJO.TipoTrabajoTrabajador)entity;
            var sqlOperation = mapper.GetUpdateStatusStatement(tiposTrabajoTrabajador);
            dao.ExecuteProcedure(sqlOperation);
        }


        //Delete
        public override void Delete(BaseEntity entity)
        {
            var tiposTrabajoTrabajador = (Entities_POJO.TipoTrabajoTrabajador)entity;
            var sqlOperation = mapper.GetDeleteStatement(tiposTrabajoTrabajador);
            dao.ExecuteProcedure(sqlOperation);
        }

        
    }
}
