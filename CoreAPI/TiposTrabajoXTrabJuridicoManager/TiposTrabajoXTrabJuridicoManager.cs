using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud.TiposTrabajoXTrabJuridico;
using Entities_POJO;
using Excepciones;

namespace CoreAPI
{
    public class TiposTrabajoXTrabJuridicoManager : BaseManager
    {
        private TiposTrabajoXTrabJuridicoCrudFactory factory;

        public TiposTrabajoXTrabJuridicoManager()
        {
            factory = new TiposTrabajoXTrabJuridicoCrudFactory();
        }


        //Create - Post
        public void Create(TipoTrabajoTrabajador tipoTrabajoTrabajador)
        {
            try
            {
                tipoTrabajoTrabajador.Estado = Estado.ACT;
                var tempTipoTrabajoTrabajador = factory.Retrieve<TipoTrabajoTrabajador>(tipoTrabajoTrabajador);

                if (tempTipoTrabajoTrabajador != null)
                {
                    throw new BusinessException("27");
                }
                else
                    factory.Create(tipoTrabajoTrabajador);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        //RetrieveAll - Get All
        public List<TipoTrabajoTrabajador> RetrieveAll()
        {
            return factory.RetrieveAll<TipoTrabajoTrabajador>();
        }


        //RetrieveById_Trabajador - Get by
        public TipoTrabajoTrabajador RetrieveById_Trabajador(TipoTrabajoTrabajador tipoTrabajoTrabajador)
        {
            TipoTrabajoTrabajador tempTipoTrabajoTrabajador = null;

            try
            {
                tempTipoTrabajoTrabajador = factory.Retrieve<TipoTrabajoTrabajador>(tipoTrabajoTrabajador);

                if (tempTipoTrabajoTrabajador == null)
                {
                    throw new BusinessException("28");
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempTipoTrabajoTrabajador;
        }


        //Retrieve Estado 
        public List<TipoTrabajoTrabajador> RetrieveActive()
        {
            var tipoTrabajoTrabajador = new TipoTrabajoTrabajador
            {
                Estado = Estado.ACT
            };
            return factory.RetrieveStatus<TipoTrabajoTrabajador>(tipoTrabajoTrabajador);
        }


        //RetrieveJobsAvailable
        public List<TipoTrabajoTrabajador> RetrieveJobsAvailable()
        {
            var tipoTrabajoTrabajador = new TipoTrabajoTrabajador();

            return factory.RetrieveJobsAvailable<TipoTrabajoTrabajador>(tipoTrabajoTrabajador);
        }


        //Update Estado (solo upd Estado, NO upd general)
        public void UpdateStatus(TipoTrabajoTrabajador tipoTrabajoTrabajador)
        {
            try
            {
                if (tipoTrabajoTrabajador.Estado == Estado.ACT)
                {
                    tipoTrabajoTrabajador.Estado = Estado.DES;
                }
                else
                {
                    tipoTrabajoTrabajador.Estado = Estado.ACT;
                }

                var temptipoTrabajoTrabajador = factory.Retrieve<TipoTrabajoTrabajador>(tipoTrabajoTrabajador);

                if (temptipoTrabajoTrabajador == null)
                {
                    throw new BusinessException("28");
                }
                else
                    factory.UpdateStatus(tipoTrabajoTrabajador);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        //Delete
        public void Delete(TipoTrabajoTrabajador tipoTrabajoTrabajador)
        {
            try
            {
                var temptipoTrabajoTrabajador = factory.Retrieve<TipoTrabajoTrabajador>(tipoTrabajoTrabajador);

                if (temptipoTrabajoTrabajador == null)
                {
                    throw new BusinessException("28");
                }
                else
                    factory.Delete(tipoTrabajoTrabajador);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

    }
}
