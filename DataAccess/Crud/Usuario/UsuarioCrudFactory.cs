﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper.Usuario;
using Entities_POJO;

namespace DataAccess.Crud.Usuario
{
    public class UsuarioCrudFactory : CrudFactory
    {
        UsuarioMapper mapper;

        public UsuarioCrudFactory() : base()
        {
            mapper = new UsuarioMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var customer = (Entities_POJO.Usuario)entity;
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
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
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

        public List<T> RetrieveTrabajdores<T>(BaseEntity entity)
        {
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllTrabajadores(entity));
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

        public List<T> RetrieveByEstado<T>(BaseEntity entity)
        {
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByEstado(entity));
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

        public override void Update(BaseEntity entity)
        {
            var customer = (Entities_POJO.Usuario)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(customer));
        }

        public void UpdateEstado(BaseEntity entity)
        {
            var customer = (Entities_POJO.Usuario)entity;
            dao.ExecuteProcedure(mapper.GetUpdateEstadoStatement(customer));
        }

        public void UpdateIntentos(BaseEntity entity)
        {
            var customer = (Entities_POJO.Usuario)entity;
            dao.ExecuteProcedure(mapper.GetUpdateIntentosStatement(customer));
        }

        public void UpdateCodigo(BaseEntity entity)
        {
            var customer = (Entities_POJO.Usuario)entity;
            dao.ExecuteProcedure(mapper.GetUpdateCodigoStatement(customer));
        }

        public override void Delete(BaseEntity entity)
        {
            var customer = (Entities_POJO.Usuario)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(customer));
        }

        public T RetrieveByEmail<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveEmailStatement(entity));
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
