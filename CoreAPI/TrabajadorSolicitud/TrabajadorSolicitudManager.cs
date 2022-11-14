using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAPI.AppCode.Helper;
using CoreAPI.User;
using DataAccess.Crud.TrabajoSolicitud;
using Entities_POJO;
using Excepciones;

namespace CoreAPI.TrabajoSolicitud
{
    public class TrabajadorSolicitudManager : BaseManager
    {
        private TrabajodorSolicitudCrudFactory crudFactory;

        public TrabajadorSolicitudManager()
        {
            crudFactory = new TrabajodorSolicitudCrudFactory();
        }

        public void Create(TrabajadorSolicitud entity)
        {
            try
            {
                var c = crudFactory.Retrieve<TrabajadorSolicitud>(entity);

                if (c != null)
                {
                    //Customer already exist
                    throw new BusinessException("202");
                }

                var precio = crudFactory.RetrievePriceWorker<TrabajadorSolicitud>(entity)?.Precio;
                if (precio != null)
                    entity.Precio = (decimal) precio;
                crudFactory.Create(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public TrabajadorSolicitud Avergae(TrabajadorSolicitud entity)
        {
            TrabajadorSolicitud c = null;
            try
            {
                c = crudFactory.RetrieveAverega<TrabajadorSolicitud>(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public TrabajadorSolicitud Lowest(TrabajadorSolicitud entity)
        {
            TrabajadorSolicitud c = null;
            try
            {
                c = crudFactory.RetrieveLowest<TrabajadorSolicitud>(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Delete(TrabajadorSolicitud entity)
        {
            try
            {

                var usuario = crudFactory.Retrieve<TrabajadorSolicitud>(entity);

                if (usuario == null)
                {
                    throw new BusinessException("203");
                }

                crudFactory.Delete(usuario);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<TrabajadorSolicitud> RetrieveTrabajadoresData(TrabajadorSolicitud trabajadorSolicitud)
        {
            var solicitudManager = new SolicitudManager.SolicitudManager();
            var solicitud = new Solicitud()
            {
                ID = trabajadorSolicitud.IdSolicitud
            };
            solicitud = solicitudManager.RetrieveByID(solicitud);

            var usuarioManager = new UsuarioManager();
            var usuario = new Usuario()
            {
                Identificacion = solicitud.ID_Cliente
            };
            usuario = usuarioManager.RetrieveById(usuario);
            var trabajadoresFormato = ConfigurarPrecioPorHora(crudFactory.RetrieveTrabajadoresData<TrabajadorSolicitud>(trabajadorSolicitud), usuario);
            return trabajadoresFormato;
        }

        public void UpdateHorasTrabajadas(TrabajadorSolicitud entity)
        {
            try
            {

                var solicitudTrabajador = crudFactory.Retrieve<TrabajadorSolicitud>(entity);

                if (solicitudTrabajador == null)
                {
                    throw new BusinessException("60");
                }

                crudFactory.UpdateHorasTrabajadas(entity);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void FijarPrecioFinal(TrabajadorSolicitud trabajadorSolicitud)
        {
            try
            {
                var calculoHorasTrabajadas = crudFactory.RetrievePrecioFinal<TrabajadorSolicitud>(trabajadorSolicitud);

                if (calculoHorasTrabajadas != null)
                {
                    var solicitudManager = new SolicitudManager.SolicitudManager();

                    var solicitud = new Solicitud()
                    {
                        ID = calculoHorasTrabajadas.IdSolicitud,
                        PrecioFinal = calculoHorasTrabajadas.PrecioFinal
                    };

                    solicitudManager.UpdatePrecioFinal(solicitud);
                }
                else
                {
                    throw new BusinessException("61");
                }
            }
            catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            
        }

        private List<TrabajadorSolicitud> ConfigurarPrecioPorHora(List<TrabajadorSolicitud> listaSolicitudes, Usuario usuario)
        {
            //Se obtiene el valor de la moneda determinada por el usuario en su configuracion

            foreach(var trabajador in listaSolicitudes)
            {
                decimal valorMoneda = MonedaHelper.ObtenerValorMoneda(usuario.Moneda);

                trabajador.PrecioMonedaUsuario = Math.Round(Convert.ToDecimal(valorMoneda) * trabajador.Precio);
            }
            

            return listaSolicitudes;
        }
    }
}
