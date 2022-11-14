using DataAccess.Crud.Especialidad;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.EspecialidadManager
{
    public class EspecialidadManager : BaseManager
    {
        private EspecialidadCrudFactory factory;

        public EspecialidadManager()
        {
            factory = new EspecialidadCrudFactory();
        }

        public void Create(Especialidad especialidad)
        {
            try
            {
                especialidad.Estado = Estado.ACT;
                var tempTipoTrabjo = factory.Retrieve<Especialidad>(especialidad);

                if (tempTipoTrabjo != null)
                {
                    throw new BusinessException("37");
                }
                else
                    factory.Create(especialidad);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Especialidad RetrieveByID(Especialidad especialidad)
        {
            Especialidad tempEspecialidad = null;

            try
            {

                tempEspecialidad = factory.Retrieve<Especialidad>(especialidad);

                if (tempEspecialidad == null)
                {
                    throw new BusinessException("38");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempEspecialidad;
        }

        public List<Especialidad> RetrieveActive()
        {
            var especialidad = new Especialidad
            {
                Estado = Estado.ACT
            };
            return factory.RetrieveStatus<Especialidad>(especialidad);
        }

        public List<Especialidad> RetrieveAll()
        {
            return factory.RetrieveAll<Especialidad>();
        }

        public void Update(Especialidad especialidad)
        {
            try
            {
                var tempEspecialidad = factory.Retrieve<Especialidad>(especialidad);

                if (tempEspecialidad == null)
                {
                    throw new BusinessException("38");
                }
                else
                    factory.Update(especialidad);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Especialidad especialidad)
        {
            try
            {
                //Se agrega este valor para obtener los registros en DB que esten activos unicamente
                especialidad.Estado = Estado.ACT;

                bool relacionesTrabajadores = factory.RetrieveJobTypeWorkerPerStatus(especialidad);

                if (relacionesTrabajadores)
                {
                    throw new BusinessException("39");
                }
                else
                {
                    var tempEspecialidad = factory.Retrieve<Especialidad>(especialidad);

                    if (tempEspecialidad == null)
                    {
                        throw new BusinessException("38");
                    }
                    else
                        factory.Delete(especialidad);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void UpdateStatus(Especialidad especialidad)
        {
            try
            {
                if (especialidad.Estado == Estado.ACT)
                    especialidad.Estado = Estado.DES;
                else
                    especialidad.Estado = Estado.ACT;

                var tempEspecialidad = factory.Retrieve<Especialidad>(especialidad);

                if (tempEspecialidad == null)
                {
                    throw new BusinessException("38");
                }
                else
                    factory.UpdateStatus(especialidad);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
