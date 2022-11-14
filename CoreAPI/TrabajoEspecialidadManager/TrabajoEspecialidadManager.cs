using DataAccess.Crud.TrabajoEspecialidad;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.TrabajoEspecialidadManager
{
    public class TrabajoEspecialidadManager: BaseManager
    {
        private TrabajoEspecialidadFactory factory;

        public TrabajoEspecialidadManager()
        {
            factory = new TrabajoEspecialidadFactory();
        }

        public void Create(TrabajoEspecialidad trabajoEspecialidad)
        {
            try
            {
                var tempTipoTrabjo = factory.Retrieve<TrabajoEspecialidad>(trabajoEspecialidad);

                if (tempTipoTrabjo != null)
                {
                    throw new BusinessException("45");
                }
                else
                    factory.Create(trabajoEspecialidad);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public TrabajoEspecialidad RetrieveByID(TrabajoEspecialidad trabajoEspecialidad)
        {
            TrabajoEspecialidad tempTrabajoEspecialidad = null;

            try
            {

                tempTrabajoEspecialidad = factory.Retrieve<TrabajoEspecialidad>(trabajoEspecialidad);

                if (tempTrabajoEspecialidad == null)
                {
                    throw new BusinessException("46");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempTrabajoEspecialidad;
        }

        public List<TrabajoEspecialidad> RetrieveAll()
        {
            return factory.RetrieveAll<TrabajoEspecialidad>();
        }

        public void Delete(TrabajoEspecialidad trabajoEspecialidad)
        {
            try
            {

                var tempTrabajoEspecialidad = factory.Retrieve<TrabajoEspecialidad>(trabajoEspecialidad);

                if (tempTrabajoEspecialidad == null)
                {
                    throw new BusinessException("46");
                }
                else
                    factory.Delete(trabajoEspecialidad);
            }

            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        //Obtiene las especialidades por el id del trabajo
        public List<TrabajoEspecialidad> RetrieveIDTrabajo(TrabajoEspecialidad trabajoEspecialidad)
        {
            return factory.RetrieveIDTrabajo<TrabajoEspecialidad>(trabajoEspecialidad);
        }
    }
}
