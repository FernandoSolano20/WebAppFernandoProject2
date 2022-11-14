using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Mapper.Reportes;

namespace DataAccess.Crud.Reportes
{
    public class IngresosDiariosFactory
    {
        private IngresosDiariosMapper mapper;
        private SqlDao dao;

        public IngresosDiariosFactory()
        {
            mapper = new IngresosDiariosMapper();
            dao = SqlDao.GetInstance();
        }
    }
}
