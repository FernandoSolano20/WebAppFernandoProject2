using CoreAPI.TrabajoTrabajoTipoTrabajoManager;
using CoreAPI.User;
using DataAccess.Crud.Solicitud;
using Entities_POJO;
using Excepciones;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAPI.User;
using System.Drawing;
using CoreAPI.AppCode.Helper;
using CoreAPI.Detalle;
using CoreAPI.Transaccion;
using CoreAPI.Factura;

namespace CoreAPI.SolicitudManager
{
    public class SolicitudManager : BaseManager
    {
        private SolicitudCrudFactory factory;

        public SolicitudManager()
        {
            factory = new SolicitudCrudFactory();
        }

        public object Create(Solicitud solicitud)
        {
            try
            {
                solicitud.Estado = Estado.INCOMPLETO;
                var tempTipoTrabjo = factory.Retrieve<Solicitud>(solicitud);

                if (tempTipoTrabjo != null)
                {
                    throw new BusinessException("42");
                }
                else
                {
                    if (solicitud.Presupuesto == 0)
                        return factory.CreateSolicitud(solicitud);
                    else
                    {

                        //Si el usuario ingresa presupuesto, este valor se debe convertir a dólares para ser almacenada en DB
                        var usuarioManager = new UsuarioManager();

                        //Se obtiene la información del usuario relacionado con la solicitud
                        var usuario = new Usuario() { Identificacion = solicitud.ID_Cliente };
                        usuario = usuarioManager.RetrieveById(usuario);

                        //Se configura el presupuesto de la solicitud obteniendo el valor de la moneda del usuario y se modifica a dolares
                        solicitud = ConfigurarValorSolicitud(solicitud, usuario);

                        //Se registra la solicitud con ese nuevo valor
                        return factory.CreateConPresupuesto(solicitud);
                    }

                }


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return solicitud;
        }

        public Solicitud RetrieveByID(Solicitud solicitud)
        {
            Solicitud tempSolicitud = null;

            try
            {

                tempSolicitud = factory.Retrieve<Solicitud>(solicitud);

                if (tempSolicitud == null)
                {
                    throw new BusinessException("41");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempSolicitud;
        }

        public List<Solicitud> RetrieveActive()
        {
            var solicitud = new Solicitud
            {
                Estado = Estado.ACT
            };
            return factory.RetrieveStatus<Solicitud>(solicitud);
        }

        public List<Solicitud> RetrieveAll()
        {
            return factory.RetrieveAll<Solicitud>();
        }

        public List<Solicitud> RetrieveIdClienteActivo(Solicitud solicitud)
        {
            //Va a obtener todas las solicitudes activas
            solicitud.Estado = Estado.ACT;
            return factory.RetrieveIdClienteStatusEmpresa<Solicitud>(solicitud);
        }

        public List<Solicitud> RetrieveIdClientePendienteAdjudicar(Solicitud solicitud)
        {
            //Va a obtener todas las solicitudes pendientes de adjudicar por el usuario
            solicitud.Estado = Estado.PENDIENTE_ADJUDICAR;
            var pendientesAdjudicar = factory.RetrieveIdClienteStatus<Solicitud>(solicitud);

            //Todas las solicitudes pendientes de adjudicar que fueron desactivadas por el usuario
            solicitud.Estado = Estado.PENDIENTE_ADJUDICAR_DESACTIVADA;
            var pendientesAdjudicarDes = factory.RetrieveIdClienteStatus<Solicitud>(solicitud);

            //Se adjuntan ambas solicitudes
            pendientesAdjudicar.AddRange(pendientesAdjudicarDes);

            //Se retorna un lista que contiene ambos tipos de solicitudes
            return pendientesAdjudicar;
        }

        public List<Solicitud> RetrieveIdClientePendienteCalificar(Solicitud solicitud)
        {
            //Va a obtener todas las solicitudes completas y pendientes de calificar
            solicitud.Estado = Estado.PENDIENTE_CALIFICAR;
            return factory.RetrieveIdClienteStatusEmpresa<Solicitud>(solicitud);
        }

        public Solicitud RetrieveISolicitudEmpresa(Solicitud solicitud)
        {
            //Va a obtener una solicitud por su id incluyendo la informacion de la empresa
            return factory.RetrieveSolicitudEmpresa<Solicitud>(solicitud);
        }

        public List<Solicitud> RetrieveIdClienteCompleto(Solicitud solicitud)
        {
            //Va a obtener todas las solicitudes completas
            solicitud.Estado = Estado.COMPLETO;
            return factory.RetrieveIdClienteStatusEmpresa<Solicitud>(solicitud);
        }

        public List<Solicitud> RetrieveIdClientePorIniciar(Solicitud solicitud)
        {
            //Va a obtener todas las solicitudes completas
            solicitud.Estado = Estado.POR_INICIAR;
            return factory.RetrieveIdClienteStatusEmpresa<Solicitud>(solicitud);
        }

        public void Update(Solicitud solicitud)
        {
            try
            {
                var tempSolicitud = factory.Retrieve<Solicitud>(solicitud);

                if (tempSolicitud == null)
                {
                    throw new BusinessException("41");
                }
                else
                    factory.Update(solicitud);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Solicitud solicitud)
        {
            try
            {
                var tempSolicitud = factory.Retrieve<Solicitud>(solicitud);

                if (tempSolicitud == null)
                {
                    throw new BusinessException("41");
                }
                else if (tempSolicitud.Estado.Equals(Estado.ACT))
                {
                    //IMPLEMENTAR EL PROCESO DE CANCELACION DE UNA SOLICITUD ACTIVA

                    throw new BusinessException("49");
                }
                else if (tempSolicitud.Estado.Equals(Estado.PENDIENTE_ADJUDICAR) || tempSolicitud.Estado.Equals(Estado.PENDIENTE_ADJUDICAR_DESACTIVADA))
                {
                    factory.Delete(solicitud);
                }
                else
                    throw new BusinessException("49");

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void UpdateStatus(Solicitud solicitud)
        {
            try
            {

                var tempSolicitud = factory.Retrieve<Solicitud>(solicitud);

                if (tempSolicitud == null)
                {
                    throw new BusinessException("41");
                }
                else
                {
                    if (tempSolicitud.Estado == Estado.PENDIENTE_ADJUDICAR)
                        solicitud.Estado = Estado.PENDIENTE_ADJUDICAR_DESACTIVADA;

                    else if (tempSolicitud.Estado.Equals(Estado.PENDIENTE_ADJUDICAR_DESACTIVADA))
                        solicitud.Estado = Estado.PENDIENTE_ADJUDICAR;

                    factory.UpdateStatus(solicitud);
                }


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        //Metodo utilizado para definir como completada del lado del usuario la solicitud
        public void UpdateStatusPendiente(Solicitud solicitud)
        {
            //Manager de trabajo tipo trabajo
            var ttpManager = new TrabajoTipoTrabajoManager();
            //Manager de trabajo especialidad
            var tespManager = new TrabajoEspecialidadManager.TrabajoEspecialidadManager();

            try
            {
                //Se verifica que la solicitud exista
                var tempSolicitud = factory.Retrieve<Solicitud>(solicitud);

                //Se verifica que existan tipos de trabajo asociados a la solicitud
                var trabajoTP = new TrabajoTipoTrabajo() { ID_Trabajo = solicitud.ID };
                var trabajosTiposTrabajo = ttpManager.RetrieveIDTrabajo(trabajoTP);

                //Se verifica que existan especialidades asociados a la solicitud
                var trabajoESP = new TrabajoEspecialidad() { ID_Trabajo = solicitud.ID };
                var trabajosEspecialidades = tespManager.RetrieveIDTrabajo(trabajoESP);

                if (tempSolicitud == null)
                {
                    throw new BusinessException("41");
                }
                else if (trabajosTiposTrabajo.Count == 0)
                {
                    throw new BusinessException("48");
                }

                else if (trabajosEspecialidades.Count == 0)
                {
                    throw new BusinessException("47");
                }

                else
                {
                    solicitud.Estado = Estado.PENDIENTE_ADJUDICAR;
                    factory.UpdateStatus(solicitud);
                }


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void AceptarOferta(Solicitud solicitud)
        {
            try
            {
                var tempSolicitud = factory.Retrieve<Solicitud>(solicitud);

                if (tempSolicitud == null)
                {
                    throw new BusinessException("41");
                }

                else
                {
                    //Se obtiene la informacion del usuario propietario de la solicitud
                    var managerUsuario = new UsuarioManager();
                    var usuario = new Usuario() { Identificacion = tempSolicitud.ID_Cliente };
                    usuario = managerUsuario.RetrieveById(usuario);

                    //Se obtiene la informacion de la empresa que realizo la oferta de trabajo
                    var managerEmpresa = new EmpresaManager.EmpresaManager();
                    var empresa = new Empresa() { Cedula = solicitud.ID_Empresa };
                    empresa = managerEmpresa.RetrieveById(empresa);

                    //Se obtiene la informacion del representante de la empresa para enviarle el correo electronico correspondiente
                    var representanteEmpresa = new Usuario() { Identificacion = empresa.IdRepresentante };
                    representanteEmpresa = managerUsuario.RetrieveById(representanteEmpresa);

                    if (usuario != null && empresa != null && representanteEmpresa != null)
                    {
                        solicitud.Estado = Estado.POR_INICIAR;
                        solicitud.CodigoQR = QRHelper.GenerarCodigoQRBase64(solicitud);
                        factory.UpdateValoresPropuesta(solicitud);

                        byte[] codigoQRBytes = QRHelper.GenerarCodigoQRByteArray(solicitud);
                        EmailHelper.Execute(representanteEmpresa.Email, usuario.Nombre + " " + usuario.PrimerApellido, "Oferta de trabajo aceptada por " + usuario.Nombre + " " + usuario.PrimerApellido,
                        EmailHelper.OfertaAceptada(usuario), codigoQRBytes, "CodigoQR.png").Wait();
                    }
                    else
                    {
                        throw new BusinessException("105");
                    }
                }


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        //Metodo utilizado para tanto iniciar o finalizar una solicitud
        public void AccionSolicitud(Solicitud solicitud)
        {
            try
            {
                if (solicitud.ID == solicitud.ID_QR)
                {
                    var tempSolicitud = factory.Retrieve<Solicitud>(solicitud);


                    if (tempSolicitud == null)
                    {
                        throw new BusinessException("41");
                    }
                    //Se valida si lo que se requiere es pasar la solicitud a estado activo, dado a que el usuario aceptó una solicitud
                    else if (tempSolicitud.Estado.Equals(Estado.POR_INICIAR))
                    {
                        solicitud.Estado = Estado.ACT;
                        factory.UpdateStatus(solicitud);
                    }

                }
                else
                    throw new BusinessException("50");


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        private decimal ObtenerValorMoneda(string monedaUsuario)
        {
            var monedaManager = new MonedaManager.MonedaManager();
            Moneda monedas = monedaManager.ObtenerMonedaValor();
            return Convert.ToDecimal(monedas.GetType().GetProperty(monedaUsuario).GetValue(monedas, null));
        }

        private Solicitud ConfigurarValorSolicitud(Solicitud solicitud, Usuario usuario)
        {
            //Se obtiene el valor de la moneda determinada por el usuario en su configuracion
            decimal valorMoneda = ObtenerValorMoneda(usuario.Moneda);

            //Se calcula el costo neto de la membresia con la moneda del usuario
            solicitud.Presupuesto = decimal.Round(Convert.ToDecimal(solicitud.Presupuesto) / Convert.ToDecimal(valorMoneda), 2);

            return solicitud;
        }

        public List<Solicitud> GetOferentesSolictudMatching(Usuario usuario)
        {
            List<Solicitud> solicitudes = null;
            try
            {
                var managerUsuario = new UsuarioManager();
                var user = managerUsuario.RetrieveById(usuario);
                if (user == null)
                {
                    throw new BusinessException("102");
                }

                solicitudes = factory.RetrieveSolicitudOferente<Solicitud>(user);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return solicitudes;
        }

        public void UpdatePrecioFinal(Solicitud solicitud)
        {
            try
            {

                var tempSolicitud = factory.Retrieve<Solicitud>(solicitud);

                if (tempSolicitud == null)
                {
                    throw new BusinessException("41");
                }
                else
                {
                    //En caso de que se haya definido un presupuesto por el usuario, entonces se cambia el valor final por el precio fijado por el proveedor en la oferta de trabajo

                    if (tempSolicitud.Presupuesto > 0)
                    {
                        var ofertaManager = new OfertaManager.OfertaManager();
                        var oferta = new Oferta()
                        {
                            IdSolicitud = tempSolicitud.ID,
                            IdEmpresa = tempSolicitud.ID_Empresa
                        };

                        oferta = ofertaManager.RetrieveConEmpresa(oferta);
                        if (oferta != null)
                        {
                            solicitud.PrecioFinal = oferta.Precio;
                        }
                        else
                        {
                            throw new BusinessException("61");
                        }
                    }

                    factory.UpdatePrecioFinal(solicitud);
                }


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Solicitud RetrieveByIDPrecioCompleto(Solicitud solicitud)
        {
            Solicitud tempSolicitud = null;

            try
            {
                tempSolicitud = factory.Retrieve<Solicitud>(solicitud);

                if (tempSolicitud != null)
                {

                    var usuarioManager = new UsuarioManager();
                    var usuario = new Usuario()
                    {
                        Identificacion = tempSolicitud.ID_Cliente
                    };
                    usuario = usuarioManager.RetrieveById(usuario);

                    if (usuario != null)
                    {
                        tempSolicitud = ConfigurarSolicitud(tempSolicitud, usuario);
                        return tempSolicitud;
                    }
                    else
                    {
                        throw new BusinessException("108");
                    }

                }
                else
                {
                    throw new BusinessException("41");
                }


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempSolicitud;
        }

        public void PagarSolicitud(Solicitud solicitud)
        {
            try
            {
                var tempSolicitud = factory.Retrieve<Solicitud>(solicitud);


                if (tempSolicitud == null)
                {
                    throw new BusinessException("41");
                }
                //Se valida si lo que se requiere es pasar la solicitud a estado activo, dado a que el usuario aceptó una solicitud
                solicitud.Estado = Estado.PENDIENTE_CALIFICAR;
                factory.UpdateStatus(solicitud);

                var usuarioMng = new UsuarioManager();
                var usuario = new Usuario()
                {
                    Identificacion = tempSolicitud.ID_Cliente
                };
                usuario = usuarioMng.RetrieveById(usuario);

                tempSolicitud = ConfigurarSolicitud(tempSolicitud, usuario);


                var ID_Transaccion = IngresarTransaccionSolicitud(tempSolicitud);
                var ID_Factura = IngresarFactura(tempSolicitud, Convert.ToInt32(ID_Transaccion));
                var detalle = IngresarDetalle(tempSolicitud, Convert.ToInt32(ID_Factura));
                
                //Correo
                var factura = new Entities_POJO.Factura();
                factura.ID = (int)ID_Factura;
                factura.Fecha = DateTime.Now;

                var detalles = new List<Entities_POJO.Detalle>();
                detalles.Add(detalle);

                

                var pdfFactura = PdfHelper.Invoice(usuario, factura, detalles);
                var bytesPdf = PdfHelper.PdfSharpConvert(pdfFactura);
                EmailHelper.Execute(usuario.Email, usuario.Nombre + " " + usuario.PrimerApellido, "Pago solicitud de trabajo",
                    EmailHelper.EnvioDeFactura(usuario), bytesPdf, "factura.pdf").Wait();
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Solicitud RetrieveByIDConFormatoPrecio(Solicitud solicitud)
        {
            Solicitud tempSolicitud = null;

            try
            {
                tempSolicitud = factory.Retrieve<Solicitud>(solicitud);

                if (tempSolicitud != null)
                {

                    var usuarioManager = new UsuarioManager();
                    var usuario = new Usuario()
                    {
                        Identificacion = tempSolicitud.ID_Cliente
                    };
                    usuario = usuarioManager.RetrieveById(usuario);

                    if (usuario != null)
                    {
                        tempSolicitud = ConfigurarPrecioOriginal(tempSolicitud, usuario);
                        return tempSolicitud;
                    }
                    else
                    {
                        throw new BusinessException("108");
                    }

                }
                else
                {
                    throw new BusinessException("41");
                }


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempSolicitud;
        }

        private Solicitud ConfigurarSolicitud(Solicitud solicitud, Usuario usuario)
        {
            //Se obtiene el valor de la moneda determinada por el usuario en su configuracion
            decimal valorMoneda = MonedaHelper.ObtenerValorMoneda(usuario.Moneda);
            //Se obtiene el valor del IVA desde la base de datos
            var configuracionIVA = ObtenerValorIVA();

            //Se calcula el costo neto de la solicitud con la moneda del usuario
            solicitud.CostoNeto = Convert.ToDecimal(valorMoneda) * Convert.ToDecimal(solicitud.PrecioFinal);

            //Se calcula el costo de los impuestos en la moneda del usuario
            solicitud.Impuestos = Convert.ToDecimal(valorMoneda) * (Convert.ToDecimal(solicitud.PrecioFinal) * Convert.ToDecimal(configuracionIVA.Valor));

            //Se obtiene el costo total de la solicitud, se obtiene de la suma de los impuestos y el costo neto de la solicitud
            solicitud.CostoTotal = Convert.ToInt32(solicitud.CostoNeto + solicitud.Impuestos);

            return solicitud;
        }

        private Solicitud ConfigurarPrecioOriginal(Solicitud solicitud, Usuario usuario)
        {
            //Se obtiene el valor de la moneda determinada por el usuario en su configuracion
            decimal valorMoneda = MonedaHelper.ObtenerValorMoneda(usuario.Moneda);

            solicitud.CostoNeto = Math.Round(Convert.ToDecimal(valorMoneda) * solicitud.Presupuesto);

            return solicitud;
        }

        /*Permite obtener el valor del Parametro IVA desde la tabla de configuraciones*/
        private Configuracion ObtenerValorIVA()
        {
            var configuracionManager = new ConfiguracionManager.ConfiguracionManager();
            var configuracion = new Configuracion()
            {
                Parametro = "IVA"
            };
            configuracion = configuracionManager.RetrieveByParameter(configuracion);
            return configuracion;
        }

        private object IngresarTransaccionSolicitud(Solicitud solicitud)
        {
            TransaccionManager transaccionManager = new TransaccionManager();

            Entities_POJO.Transaccion transaccion = new Entities_POJO.Transaccion()
            {
                Monto = solicitud.PrecioFinal,
                Movimiento = TipoMovimiento.EntranteProveedor,
                Fecha = DateTime.Now,
                ID_Usuario = solicitud.ID_Cliente,
                ID_Trabajo = solicitud.ID
            };

            /*Se retorna el valor proveniente del Stored Procedure. 
             * Para este caso, el ID de la transaccion registrada*/

            return transaccionManager.CreateTransaccionTrabajo(transaccion);
        }

        private object IngresarFactura(Solicitud solicitud, int ID_Transaccion)
        {
            FacturaManager facturaManager = new FacturaManager();

            Entities_POJO.Factura factura = new Entities_POJO.Factura()
            {
                ID_Transaccion = ID_Transaccion,
                Fecha = DateTime.Now,
                ID_Proveedor = solicitud.ID_Cliente
            };

            /*Se retorna el valor proveniente del Stored Procedure. 
             * Para este caso, el ID de la factura registrada*/

            return facturaManager.CreateWithReturnValue(factura);
        }

        private Entities_POJO.Detalle IngresarDetalle(Solicitud solicitud, int ID_Factura)
        {
            DetalleManager detalleManager = new DetalleManager();
            Entities_POJO.Detalle detalle = new Entities_POJO.Detalle();

            detalle = new Entities_POJO.Detalle()
            {
                Nombre = DetalleOpciones.NombreTrabajo,
                Precio = solicitud.CostoTotal,
                Cantidad = 1,
                ID_Factura = ID_Factura,
                Descripcion = DetalleOpciones.DescripcionTrabajo
            };

            detalleManager.Create(detalle);
            return detalle;
        }

        public void UpdateCalificacion(Solicitud solicitud)
        {
            try
            {
                var tempSolicitud = factory.Retrieve<Solicitud>(solicitud);

                if (tempSolicitud == null)
                {
                    throw new BusinessException("41");
                }
                else
                {
                    solicitud.Estado = Estado.COMPLETO;
                    factory.UpdateCalificacion(solicitud);
                }
                    

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Solicitud> GetClienteSolicitudes(Solicitud entity)
        {
            List<Solicitud> solicitudes = null;
            try
            {
                solicitudes = factory.RetrieveSolicitudCliente<Solicitud>(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return solicitudes;
        }

        public List<Solicitud> GetOferenteSolicitudes(Solicitud entity)
        {
            List<Solicitud> solicitudes = null;
            try
            {
                solicitudes = factory.RetrieveSolicitudDeLosOferentes<Solicitud>(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return solicitudes;
        }
    }
}
