using DataAccess.Dao;
using DataAccess.Mapper.Reportes.IngresosMensualesPlataforma;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud.Reportes.IngresoMensualesPlataforma
{
    public class IngresosMensualesPlataformaFactory
    {
        private IngresosMensualesPlataformaMapper mapper;
        private SqlDao dao;

        public IngresosMensualesPlataformaFactory()
        {
            mapper = new IngresosMensualesPlataformaMapper();
            dao = SqlDao.GetInstance();
        }

        public T Retrieve<T>(BaseEntity baseEntity)
        {
            var sqlOperation = mapper.GetGananciasMensualesStatement(baseEntity);
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);


            if (queryResult.Count > 0)
            {
                var result = mapper.BuildObjects(queryResult);
                return (T)Convert.ChangeType(result, typeof(T));

            }
            return default(T);
        }
    }
}
