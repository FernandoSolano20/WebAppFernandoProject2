using DataAccess.Dao;
using DataAccess.Mapper.Factura;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud.Factura
{
    public class FacturaCrudFactory : CrudFactory
    {
        private FacturaMapper mapper;

        public FacturaCrudFactory()
        {
            mapper = new FacturaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var factura = (Entities_POJO.Factura)entity;
            var sqlOperation = mapper.GetCreateStatement(factura);
            dao.ExecuteProcedure(sqlOperation);
        }

        public object CreateWithReturnValue(BaseEntity entity)
        {
            var factura = (Entities_POJO.Factura)entity;
            var sqlOperation = mapper.GetCreateStatement(factura);
            return dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var factura = (Entities_POJO.Factura)entity;
            var sqlOperation = mapper.GetDeleteStatement(factura);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var factura = (Entities_POJO.Factura)entity;
            var sqlOperation = mapper.GetRetriveStatement(factura);
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

        public override void Update(BaseEntity entity)
        {
            var factura = (Entities_POJO.Factura)entity;
            var sqlOperation = mapper.GetUpdateStatement(factura);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
