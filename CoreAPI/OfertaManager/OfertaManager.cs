using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAPI.AppCode.Helper;
using CoreAPI.User;
using DataAccess.Crud.Oferta;
using Entities_POJO;
using Excepciones;

namespace CoreAPI.OfertaManager
{
    public class OfertaManager : BaseManager
    {
        private OfertaCrudFactory crudFactory;

        public OfertaManager()
        {
            crudFactory = new OfertaCrudFactory();
        }

        public void Create(Oferta entity)
        {
            try
            {
                var c = crudFactory.Retrieve<Oferta>(entity);

                if (c != null)
                {
                    throw new BusinessException("200");
                }
                entity.Fecha = DateTime.Now;
                entity.Estado = Estado.ACT;
                entity.Precio = entity.Precio / MonedaHelper.ObtenerValorMoneda(entity.Moneda);
                crudFactory.Create(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public IList<Oferta> RetrieveAllByEmpresa(Oferta entity)
        {
            var entities = new List<Oferta>();
            try
            {
                entities = crudFactory.RetrieveByEmpresa<Oferta>(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return entities;
        }

        public Oferta RetrieveAverage(Oferta entity)
        {
            Oferta c = null;
            try
            {
                c = crudFactory.RetrieveAverage<Oferta>(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public Oferta RetrieveLowest(Oferta entity)
        {
            Oferta c = null;
            try
            {
                c = crudFactory.RetrieveLowest<Oferta>(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Oferta entity)
        {
            try
            {

                var usuario = crudFactory.Retrieve<Oferta>(entity);

                if (usuario == null)
                {
                    throw new BusinessException("201");
                }

                crudFactory.Update(entity);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Oferta entity)
        {
            try
            {

                var usuario = crudFactory.Retrieve<Oferta>(entity);

                if (usuario == null)
                {
                    throw new BusinessException("201");
                }

                crudFactory.Delete(usuario);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void UpdateStatus(Oferta oferta)
        {
            try
            {

                var tempOferta = crudFactory.Retrieve<Oferta>(oferta);

                if (tempOferta == null)
                {
                    throw new BusinessException("41");
                }
                else
                {
                    if (tempOferta.Estado == Estado.ACT)
                        oferta.Estado = Estado.DES;

                    crudFactory.UpdateStatus(oferta);
                }


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        //Retorna todas las ofertas relacionadas a una solicitud de trabajo
        public IList<Oferta> RetrieveAllBySolicitudId(Oferta entity)
        {
            entity.Estado = Estado.ACT;
            var entities = new List<Oferta>();
            try
            {
                entities = crudFactory.RetrieveBySolicitudId<Oferta>(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return entities;
        }

        public Oferta RetrieveConEmpresa(Oferta entity)
        {
            var oferta = new Oferta();
            try
            {
                oferta = crudFactory.RetrieveConEmpresa<Oferta>(entity);

                var solicitudManager = new SolicitudManager.SolicitudManager();
                var tempSolicitud = new Solicitud() { ID = oferta.IdSolicitud };
                tempSolicitud = solicitudManager.RetrieveByID(tempSolicitud);

                var usuarioManager = new UsuarioManager();
                var usuario = new Usuario()
                {
                    Identificacion = tempSolicitud.ID_Cliente
                };
                usuario = usuarioManager.RetrieveById(usuario);

                oferta = ConfigurarPrecioOriginal(oferta, usuario);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return oferta;
        }

        private Oferta ConfigurarPrecioOriginal(Oferta oferta, Usuario usuario)
        {
            //Se obtiene el valor de la moneda determinada por el usuario en su configuracion
            decimal valorMoneda = MonedaHelper.ObtenerValorMoneda(usuario.Moneda);

            oferta.PrecioCliente = Math.Round(Convert.ToDecimal(valorMoneda) * oferta.Precio);

            oferta.CancelacionCliente = Math.Round(Convert.ToDecimal(valorMoneda) * oferta.Cancelacion);

            return oferta;
        }
    }
}
