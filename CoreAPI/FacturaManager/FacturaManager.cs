using DataAccess.Crud.Factura;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Factura
{
    public class FacturaManager : BaseManager
    {
        private FacturaCrudFactory factory;

        public FacturaManager()
        {
            factory = new FacturaCrudFactory();
        }

        public void Create(Entities_POJO.Factura factura)
        {
            try
            {
                var tempFactura = factory.Retrieve<Entities_POJO.Factura>(factura);

                if (tempFactura != null)
                {
                    throw new BusinessException("35");
                }
                else
                    factory.Create(factura);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public object CreateWithReturnValue(Entities_POJO.Factura factura)
        {
            try
            {
                var tempFactura = factory.Retrieve<Entities_POJO.Factura>(factura);

                if (tempFactura != null)
                {
                    throw new BusinessException("35");
                }
                else
                    return factory.CreateWithReturnValue(factura);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return factura;
        }


        public Entities_POJO.Factura RetrieveByID(Entities_POJO.Factura factura)
        {
            Entities_POJO.Factura tempFactura = null;

            try
            {

                tempFactura = factory.Retrieve<Entities_POJO.Factura>(factura);

                if (tempFactura == null)
                {
                    throw new BusinessException("36");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempFactura;
        }

        public List<Entities_POJO.Factura> RetrieveAll()
        {
            return factory.RetrieveAll<Entities_POJO.Factura>();
        }

        public void Update(Entities_POJO.Factura factura)
        {
            try
            {
                var tempFactura = factory.Retrieve<Entities_POJO.Factura>(factura);

                if (tempFactura == null)
                {
                    throw new BusinessException("36");
                }
                else
                    factory.Update(factura);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Entities_POJO.Factura factura)
        {
            try
            {

                var tempFactura = factory.Retrieve<Entities_POJO.Factura>(factura);

                if (tempFactura == null)
                {
                    throw new BusinessException("36");
                }
                else
                    factory.Delete(factura);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
