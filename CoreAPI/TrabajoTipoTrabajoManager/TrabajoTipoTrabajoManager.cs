using DataAccess.Crud.TrabajoTipoTrabajo;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.TrabajoTrabajoTipoTrabajoManager
{
    public class TrabajoTipoTrabajoManager : BaseManager
    {
        private TrabajoTipoTrabajoFactory factory;

        public TrabajoTipoTrabajoManager()
        {
            factory = new TrabajoTipoTrabajoFactory();
        }

        public void Create(TrabajoTipoTrabajo trabajoTipoTrabajo)
        {
            try
            {
                var tempTipoTrabjo = factory.Retrieve<TrabajoTipoTrabajo>(trabajoTipoTrabajo);

                if (tempTipoTrabjo != null)
                {
                    throw new BusinessException("43");
                }
                else
                    factory.Create(trabajoTipoTrabajo);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public TrabajoTipoTrabajo RetrieveByID(TrabajoTipoTrabajo trabajoTipoTrabajo)
        {
            TrabajoTipoTrabajo tempTrabajoTipoTrabajo = null;

            try
            {

                tempTrabajoTipoTrabajo = factory.Retrieve<TrabajoTipoTrabajo>(trabajoTipoTrabajo);

                if (tempTrabajoTipoTrabajo == null)
                {
                    throw new BusinessException("44");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempTrabajoTipoTrabajo;
        }

        public List<TrabajoTipoTrabajo> RetrieveAll()
        {
            return factory.RetrieveAll<TrabajoTipoTrabajo>();
        }

        public void Update(TrabajoTipoTrabajo trabajoTipoTrabajo)
        {
            try
            {
                var tempTrabajoTipoTrabajo = factory.Retrieve<TrabajoTipoTrabajo>(trabajoTipoTrabajo);

                if (tempTrabajoTipoTrabajo == null)
                {
                    throw new BusinessException("44");
                }
                else
                    factory.Update(trabajoTipoTrabajo);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(TrabajoTipoTrabajo trabajoTipoTrabajo)
        {
            try
            {

                var tempTrabajoTipoTrabajo = factory.Retrieve<TrabajoTipoTrabajo>(trabajoTipoTrabajo);

                if (tempTrabajoTipoTrabajo == null)
                {
                    throw new BusinessException("44");
                }
                else
                    factory.Delete(trabajoTipoTrabajo);
            }

            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        //Obtiene los tipos de trabajo por el id del trabajo
        public List<TrabajoTipoTrabajo> RetrieveIDTrabajo(TrabajoTipoTrabajo trabajoTipoTrabajo)
        {
            return factory.RetrieveIDTrabajo<TrabajoTipoTrabajo>(trabajoTipoTrabajo);
        }
    }
}
