using DataAccess.Dao;
using DataAccess.Mapper.Solicitud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud.Solicitud
{
    public class SolicitudCrudFactory : CrudFactory
    {
        private SolicitudMapper mapper;

        public SolicitudCrudFactory()
        {
            mapper = new SolicitudMapper();
            dao = SqlDao.GetInstance();
        }

        //Metodo utilizado para ingresar una nueva solicitud de trabajo sin retornar ningun valor || NO SP
        public override void Create(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetCreateStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        //Metodo utilizado para ingresar una nueva solicitud de trabajo sin retornar ningun valor || NO SP
        public object CreateSolicitud(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetCreateStatement(solicitud);
            return dao.ExecuteProcedure(sqlOperation);
        }

        public object CreateConPresupuesto(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetCreateConPresupuestoStatement(solicitud);
            return dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetDeleteStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetRetriveStatement(solicitud);
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

        public T RetrieveSolicitudEmpresa<T>(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetRetriveIdSolicitudEmpresaStatement(solicitud);
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

        public List<T> RetrieveStatus<T>(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetRetriveStatusStatement(solicitud);
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

        public List<T> RetrieveIdClienteStatus<T>(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetRetriveIdClienteStatusStatement(solicitud);
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

        public List<T> RetrieveIdClienteStatusEmpresa<T>(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetRetriveIdClienteStatusEmpresaStatement(solicitud);
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

        public override void Update(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetUpdateStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void UpdateStatus(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetUpdateStatusStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void UpdateValoresPropuesta(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetUpdateValoresPropuestaStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public List<T> RetrieveSolicitudOferente<T>(BaseEntity entity)
        {
            var resultList = new List<T>();
            var sqlOperation = mapper.GetRetrieveSolicitudOferente(entity);
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

        public void UpdatePrecioFinal(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetUpdatePrecioFinalStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void UpdateCalificacion(BaseEntity entity)
        {
            var solicitud = (Entities_POJO.Solicitud)entity;
            var sqlOperation = mapper.GetCalificacionStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public List<T> RetrieveSolicitudCliente<T>(BaseEntity entity)
        {
            var resultList = new List<T>();
            var sqlOperation = mapper.GetRetrieveSolicitudCliente(entity);
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

        public List<T> RetrieveSolicitudDeLosOferentes<T>(BaseEntity entity)
        {
            var resultList = new List<T>();
            var sqlOperation = mapper.GetRetrieveMisSolicitudOferentes(entity);
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
