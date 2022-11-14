using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper.TrabajosXProvJuridico;
using Entities_POJO;

namespace DataAccess.Crud.TrabajosXProvJuridico
{
    public class TrabajosXProvJuridicoCrudFactory : CrudFactory
    {
        private TrabajosXProvJuridicoMapper mapper;
        private SqlDao dao;

        public TrabajosXProvJuridicoCrudFactory()
        {
            mapper = new TrabajosXProvJuridicoMapper();
            dao = SqlDao.GetInstance();
        }


        //Create
        public override void Create(BaseEntity entity)
        {
            var trabajosProvJuridico = (Entities_POJO.TipoTrabajoTrabajador)entity;
            var sqlOperation = mapper.GetCreateStatement(trabajosProvJuridico);
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
       public List <T> RetrieveTrabajador<T>(BaseEntity entity)
        {
            var trabajosProvJuridico = (Entities_POJO.TipoTrabajoTrabajador)entity;
            var sqlOperation = mapper.GetRetrieveTrabajadorStatement(trabajosProvJuridico);
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
        

        //Get by Estado                                             
        public List<T> RetrieveStatus<T>(BaseEntity entity)
        {
            var trabajosProvJuridico = (Entities_POJO.TipoTrabajoTrabajador)entity;
            var sqlOperation = mapper.GetRetriveStatusStatement(trabajosProvJuridico);
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
            var trabajosProvJuridico = (Entities_POJO.TipoTrabajoTrabajador)entity;
            var sqlOperation = mapper.GetUpdateStatusStatement(trabajosProvJuridico);
            dao.ExecuteProcedure(sqlOperation);
        }


        //Delete
        public override void Delete(BaseEntity entity)
        {
            var trabajosProvJuridico = (Entities_POJO.TipoTrabajoTrabajador)entity;
            var sqlOperation = mapper.GetDeleteStatement(trabajosProvJuridico);
            dao.ExecuteProcedure(sqlOperation);
        }

        //Este no aplica
        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
