using DataAccess.Crud.Detalle;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Detalle
{
    public class DetalleManager : BaseManager
    {
        private DetalleCrudFactory factory;

        public DetalleManager()
        {
            factory = new DetalleCrudFactory();
        }

        public void Create(Entities_POJO.Detalle detalle)
        {
            try
            {
                var tempTipoTrabjo = factory.Retrieve<Entities_POJO.Detalle>(detalle);

                if (tempTipoTrabjo != null)
                {
                    throw new BusinessException("37");
                }
                else
                    factory.Create(detalle);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        public Entities_POJO.Detalle RetrieveByID(Entities_POJO.Detalle detalle)
        {
            Entities_POJO.Detalle tempDetalle = null;

            try
            {

                tempDetalle = factory.Retrieve<Entities_POJO.Detalle>(detalle);

                if (tempDetalle == null)
                {
                    throw new BusinessException("38");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempDetalle;
        }

        public List<Entities_POJO.Detalle> RetrieveAll()
        {
            return factory.RetrieveAll<Entities_POJO.Detalle>();
        }

        public void Update(Entities_POJO.Detalle detalle)
        {
            try
            {
                var tempDetalle = factory.Retrieve<Entities_POJO.Detalle>(detalle);

                if (tempDetalle == null)
                {
                    throw new BusinessException("38");
                }
                else
                    factory.Update(detalle);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Entities_POJO.Detalle detalle)
        {
            try
            {

                var tempDetalle = factory.Retrieve<Entities_POJO.Detalle>(detalle);

                if (tempDetalle == null)
                {
                    throw new BusinessException("38");
                }
                else
                    factory.Delete(detalle);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
