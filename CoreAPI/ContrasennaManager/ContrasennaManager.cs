﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAPI.AppCode.Helper;
using CoreAPI.User;
using DataAccess.Crud.Contrasenna;
using Entities_POJO;
using Excepciones;

namespace CoreAPI.ContrasennaManager
{
    public class ContrasennaManager : BaseManager
    {
        private ContrasennaCrudFactory crudFactory;

        public ContrasennaManager()
        {
            crudFactory = new ContrasennaCrudFactory();
        }

        public BaseEntity Create(Contrasenna entity)
        {
            var usuario = new Usuario();
            try
            {
                entity.Password = entity.Password.md5();
                var contrasennas = crudFactory.RetrieveIdUser<Contrasenna>(entity);
                var createPass = true;

                foreach (var contrasenna in contrasennas)
                {
                    if (contrasenna.Password == entity.Password)
                    {
                        createPass = false;
                    }
                }

                if (createPass)
                {
                    entity.Fecha = DateTime.Now;
                    entity.Estado = Estado.ACT;

                    var desactiveContra = GetActiveContrasenna(contrasennas);
                    if (desactiveContra != null)
                    {
                        desactiveContra.Estado = Estado.DES;
                        crudFactory.UpdateEstatus(desactiveContra);
                    }
                    

                    crudFactory.Create(entity);
                    var usuarioManager = new UsuarioManager();
                    usuario = usuarioManager.RetrieveById(new Usuario()
                    {
                        Identificacion = entity.IdUsuario
                    }); 
                    
                    if (usuario.Estado == Estado.NOPAGOYCAMBIARCONTRASENNA)
                    {
                        usuario.Estado = Estado.NOPAGO;
                    }
                    else
                    {
                        usuario.Estado = Estado.ACT;
                    }

                    usuarioManager.CambiarEstado(usuario);
                    var contrasenna = GetActiveContrasenna(contrasennas);
                    if (contrasenna != null)
                    {
                        crudFactory.UpdateEstatus(contrasenna);
                        if (contrasennas.Count == 5)
                        {
                            contrasenna = GetContrasennaMasVieja(contrasennas);
                            crudFactory.Delete(contrasenna);
                        }
                    }
                }
                else
                {
                    throw new BusinessException("113");
                }
                
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return usuario;
        }

        private Contrasenna GetActiveContrasenna(List<Contrasenna> contrasennas)
        {
            foreach (var contrasenna in contrasennas)
            {
                if (contrasenna.Estado == Estado.ACT)
                {
                    return contrasenna;
                }
            }

            return null;
        }

        private Contrasenna GetContrasennaMasVieja(List<Contrasenna> contrasennas)
        {
            Contrasenna pass = contrasennas[0];
            foreach (var contrasenna in contrasennas)
            {
                if (contrasenna.Fecha < pass.Fecha)
                {
                    pass = contrasenna;
                }
            }

            return pass;
        }

        public Contrasenna RetrieveById(Contrasenna entity)
        {
            Contrasenna c = null;
            try
            {
                c = crudFactory.Retrieve<Contrasenna>(entity);
                if (c == null)
                {
                    throw new BusinessException("114");
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public Contrasenna RetrieveByIdUserActive(Contrasenna entity)
        {
            Contrasenna c = null;
            entity.Estado = Estado.ACT;
            c = crudFactory.RetrieveIdUserActive<Contrasenna>(entity);
            return c;
        }
    }
}
