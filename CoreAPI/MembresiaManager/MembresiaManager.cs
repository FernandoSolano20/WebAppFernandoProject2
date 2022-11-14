using DataAccess.Crud.Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAPI.AppCode.Helper;
using Entities_POJO;
using Excepciones;
using CoreAPI.Transaccion;
using CoreAPI.Factura;
using CoreAPI.Detalle;
using CoreAPI.User;

namespace CoreAPI.MembresiaManager
{
    public class MembresiaManager : BaseManager
    {
        private MembresiaCrudFactory factory;

        public MembresiaManager()
        {
            factory = new MembresiaCrudFactory();
        }

        public void Create(Membresia membresia)
        {
            try
            {
                membresia.Estado = Estado.ACT;
                membresia.Fecha = DateTime.Now;
                //var tempMembresia = factory.Retrieve<Membresia>(membresia);

                //if (tempMembresia != null)
                //{
                //    throw new BusinessException("30");
                //}
                //else
                    factory.Create(membresia);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Membresia RetrieveByID(Membresia membresia)
        {
            Membresia tempMembresia = null;

            try
            {

                tempMembresia = factory.Retrieve<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempMembresia;
        }

        public Membresia RetrieveCurrentStandardMembership(Membresia membresia)
        {
            Membresia tempMembresia = new Membresia();
            membresia.Tipo = TipoMembresia.Estandar;

            try
            {
                tempMembresia = factory.RetrieveCurrentMembershipPerType<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }
                else
                {
                    membresia = ConfigurarMembresia(tempMembresia);
                    return membresia;
                }


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempMembresia;
        }

        public Membresia RetrieveCurrentPremiumMembership(Membresia membresia)
        {
            Membresia tempMembresia = new Membresia();
            membresia.Tipo = TipoMembresia.Premium;

            try
            {
                tempMembresia = factory.RetrieveCurrentMembershipPerType<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }
                else
                {
                    membresia = ConfigurarMembresia(tempMembresia);
                    return membresia;
                }


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempMembresia;
        }

        public bool IsPremium(Membresia entity)
        {
            Membresia membresiaPremium = new Membresia();
            Membresia membresiaEstandar = new Membresia();
            var response = false;
            try
            {
                entity.Tipo = TipoMembresia.Premium;
                membresiaPremium = factory.RetrieveCurrentMembershipPerType<Membresia>(entity);

                entity.Tipo = TipoMembresia.Estandar;
                membresiaEstandar = factory.RetrieveCurrentMembershipPerType<Membresia>(entity);

                if (membresiaPremium == null)
                {
                    response = false;
                }
                else if(membresiaEstandar == null)
                {
                    response = true;
                }
                else if(membresiaEstandar.Fecha > membresiaPremium.Fecha)
                {
                    response = false;
                }
                else if(membresiaEstandar.Fecha < membresiaPremium.Fecha)
                {
                    response = true;
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return response;
        }

        public List<Membresia> RetrieveAll()
        {
            return factory.RetrieveAll<Membresia>();
        }

        public void Update(Membresia membresia)
        {
            try
            {
                var tempMembresia = factory.Retrieve<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }
                else
                    factory.Update(membresia);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }



        public Membresia UpdateStandardDate(Membresia membresia)
        {
            Membresia tempMembresia = new Membresia();
            membresia.Tipo = TipoMembresia.Estandar;

            try
            {

                tempMembresia = factory.RetrieveCurrentMembershipPerType<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }
                else
                {
                    
                    membresia = ConfigurarMembresia(tempMembresia);

                    //Si la membresia está vencida, a partir de la fecha de hoy estará vigente un año
                    //Si no, añadirá un año más a la fecha de vencimiento.
                    if (tempMembresia.Fecha < DateTime.Now)
                        membresia.Fecha = DateTime.Now.AddYears(1);
                    else
                        membresia.Fecha = tempMembresia.Fecha.AddYears(1);

                    membresia.Estado = Estado.ACT;

                    factory.UpdateDate(membresia);

                    var ID_Transaccion = IngresarTransaccionMembresia(membresia);
                    var ID_Factura = IngresarFactura(membresia, Convert.ToInt32(ID_Transaccion));
                    var detalle = IngresarDetalle(membresia, Convert.ToInt32(ID_Factura));
                    var usuarioMng = new UsuarioManager();
                    var usuario = new Usuario()
                    {
                        Identificacion = membresia.ID_Representante,
                        Estado = Estado.ACT
                    };
                    usuarioMng.CambiarEstado(usuario);

                    //Correo
                    var factura = new Entities_POJO.Factura();
                    factura.ID = (int)ID_Factura;
                    factura.Fecha = DateTime.Now;

                    var detalles = new List<Entities_POJO.Detalle>();
                    detalles.Add(detalle);

                    usuario = usuarioMng.RetrieveById(usuario);

                    var pdfFactura = PdfHelper.Invoice(usuario,factura,detalles);
                    var bytesPdf = PdfHelper.PdfSharpConvert(pdfFactura);
                    EmailHelper.Execute(usuario.Email, usuario.Nombre + " " + usuario.PrimerApellido, "Pago membresía Plataforma",
                        EmailHelper.EnvioDeFactura(usuario), bytesPdf, "factura.pdf").Wait();

                    //Se retorna la membresia para mostrar la fecha actualizada
                    return membresia;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            //Se retorna la membresia para mostrar la fecha actualizada
            return membresia;
        }


        public Membresia UpdatePremiumDate(Membresia membresia)
        {
            Membresia tempMembresia = new Membresia();
            membresia.Tipo = TipoMembresia.Premium;
            try
            {

                tempMembresia = factory.RetrieveCurrentMembershipPerType<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }
                else
                {

                    membresia = ConfigurarMembresia(tempMembresia);

                    //Si la membresia está vencida, a partir de la fecha de hoy estará vigente un año
                    //Si no, añadirá un año más a la fecha de vencimiento.
                    if (tempMembresia.Fecha < DateTime.Now)
                        membresia.Fecha = DateTime.Now.AddYears(1);
                    else
                        membresia.Fecha = tempMembresia.Fecha.AddYears(1);

                    membresia.Estado = Estado.ACT;

                    factory.UpdateDate(membresia);

                    var ID_Transaccion = IngresarTransaccionMembresia(membresia);
                    var ID_Factura = IngresarFactura(membresia, Convert.ToInt32(ID_Transaccion));
                    var detalle = IngresarDetalle(membresia, Convert.ToInt32(ID_Factura));
                    var usuarioMng = new UsuarioManager();
                    var usuario = new Usuario()
                    {
                        Identificacion = membresia.ID_Representante,
                        Estado = Estado.ACT
                    };
                    usuarioMng.CambiarEstado(usuario);

                    //Correo
                    var factura = new Entities_POJO.Factura();
                    factura.ID = (int)ID_Factura;
                    factura.Fecha = DateTime.Now;

                    var detalles = new List<Entities_POJO.Detalle>();
                    detalles.Add(detalle);

                    usuario = usuarioMng.RetrieveById(usuario);

                    var pdfFactura = PdfHelper.Invoice(usuario, factura, detalles);
                    var bytesPdf = PdfHelper.PdfSharpConvert(pdfFactura);
                    EmailHelper.Execute(usuario.Email, usuario.Nombre + " " + usuario.PrimerApellido, "Acceso Plataforma",
                        EmailHelper.EnvioDeFactura(usuario), bytesPdf, "factura.pdf").Wait();

                    //Se retorna la membresia para mostrar la fecha actualizada
                    return membresia;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            //Se retorna la membresia para mostrar la fecha actualizada
            return membresia;
        }

        public void Delete(Membresia membresia)
        {
            try
            {
                var tempMembresia = factory.Retrieve<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }
                else
                    factory.Delete(membresia);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        private Membresia ConfigurarMembresia(Membresia membresia)
        {
            //Se obtiene el valor de la moneda determinada por el usuario en su configuracion
            decimal valorMoneda = ObtenerValorMoneda(membresia.Moneda);
            //Se obtiene el valor del IVA desde la base de datos
            var configuracionIVA = ObtenerValorIVA();

            //Se calcula el costo neto de la membresia con la moneda del usuario
            membresia.CostoNeto = Convert.ToDecimal(valorMoneda) * Convert.ToDecimal(membresia.Costo);

            //Se calcula el costo de los impuestos en la moneda del usuario
            membresia.Impuestos = Convert.ToDecimal(valorMoneda) * (Convert.ToDecimal(membresia.Costo) * Convert.ToDecimal(configuracionIVA.Valor));

            //Se obtiene el costo total de la membresia, se obtiene de la suma de los impuestos y el costo neto de la membresia
            membresia.CostoTotal = Convert.ToInt32(membresia.CostoNeto + membresia.Impuestos);

            return membresia;
        }

        /*Permite obtener el valor decimal de la moneda definida por el usuario en su cuenta*/
        private decimal ObtenerValorMoneda(string monedaUsuario)
        {
            var monedaManager = new MonedaManager.MonedaManager();
            Moneda monedas = monedaManager.ObtenerMonedaValor();
            return Convert.ToDecimal(monedas.GetType().GetProperty(monedaUsuario).GetValue(monedas, null));
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

        private object IngresarTransaccionMembresia(Membresia membresia)
        {
            TransaccionManager transaccionManager = new TransaccionManager();

            Entities_POJO.Transaccion transaccion = new Entities_POJO.Transaccion()
            {
                Monto = membresia.Costo,
                Movimiento = TipoMovimiento.EntrantePlataforma,
                Fecha = DateTime.Now,
                ID_Usuario = membresia.ID_Representante,
                ID_Membresia = membresia.ID
            };

            /*Se retorna el valor proveniente del Stored Procedure. 
             * Para este caso, el ID de la transaccion registrada*/

            return transaccionManager.CreateTransaccionMembresia(transaccion);
        }

        private object IngresarFactura(Membresia membresia, int ID_Transaccion)
        {
            FacturaManager facturaManager = new FacturaManager();

            Entities_POJO.Factura factura = new Entities_POJO.Factura()
            {
                ID_Transaccion = ID_Transaccion,
                Fecha = DateTime.Now,
                ID_Proveedor = membresia.ID_Representante
            };

            /*Se retorna el valor proveniente del Stored Procedure. 
             * Para este caso, el ID de la factura registrada*/

            return facturaManager.CreateWithReturnValue(factura);
        }

        private Entities_POJO.Detalle IngresarDetalle(Membresia membresia, int ID_Factura)
        {
            DetalleManager detalleManager = new DetalleManager();
            Entities_POJO.Detalle detalle = new Entities_POJO.Detalle();
            if (membresia.Tipo == TipoMembresia.Estandar)
            {
                detalle = new Entities_POJO.Detalle()
                {
                    Nombre = DetalleOpciones.NombreMembresiaPRO,
                    Precio = membresia.CostoTotal,
                    Cantidad = 1,
                    ID_Factura = ID_Factura,
                    Descripcion = DetalleOpciones.DescripcionMembresiaPRO
                };
            }
            else
            {
                detalle = new Entities_POJO.Detalle()
                {
                    Nombre = DetalleOpciones.NombreMembresiaPREM,
                    Precio = membresia.CostoTotal,
                    Cantidad = 1,
                    ID_Factura = ID_Factura,
                    Descripcion = DetalleOpciones.DescripcionMembresiaPREM
                };
            }

            

            detalleManager.Create(detalle);
            return detalle;
        }
    }


}
