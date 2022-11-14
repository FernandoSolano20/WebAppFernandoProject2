using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper.Oferta;
using Entities_POJO;

namespace DataAccess.Crud.Oferta
{
    public class OfertaCrudFactory : CrudFactory
    {
        OfertaMapper mapper;

        public OfertaCrudFactory() : base()
        {
            mapper = new OfertaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var customer = (Entities_POJO.Oferta)entity;
            var sqlOperation = mapper.GetCreateStatement(customer);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public List<T> RetrieveByEmpresa<T>(BaseEntity entity)
        {
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByEmpresaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCustomers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCustomers;
        }

        public T RetrieveAverage<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAverageStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObjectAverage(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public T RetrieveLowest<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveLowestOfferStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override void Update(BaseEntity entity)
        {
            var customer = (Entities_POJO.Oferta)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(customer));
        }

        public override void Delete(BaseEntity entity)
        {
            var customer = (Entities_POJO.Oferta)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(customer));
        }

        public void UpdateStatus(BaseEntity entity)
        {
            var customer = (Entities_POJO.Oferta)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatusStatement(customer));
        }

        //Se obtienen las ofertas por id de solicitud
        public List<T> RetrieveBySolicitudId<T>(BaseEntity entity)
        {
            var listOffers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllPerSolicitudId(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    listOffers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listOffers;
        }

        //Se obtiene la oferta con la informacion de la empresa por id de solicitud y empresa
        public T RetrieveConEmpresa<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveConEmpresaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
    }
}
