using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Solicitud
{
    public class SolicitudMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_TITULO = "TITULO";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";
        private const string DB_COL_DIRECCION = "DIRECCION";
        private const string DB_COL_LATITUD = "LATITUD";
        private const string DB_COL_LONGITUD = "LONGITUD";
        private const string DB_COL_FECHA_INICIO = "FECHA_INICIO";
        private const string DB_COL_FECHA_FIN = "FECHA_FIN";
        private const string DB_COL_CODIGO_QR = "CODIGO_QR";
        private const string DB_COL_CALIFICACION_TRABAJO = "CALIFICACION_TRABAJO";
        private const string DB_COL_COMENTARIO_TRABAJO = "COMENTARIO_TRABAJO";
        private const string DB_COL_CALIFICACION_EMPRESA = "CALIFICACION_EMPRESA";
        private const string DB_COL_COMENTARIO_EMPRESA = "COMENTARIO_EMPRESA";
        private const string DB_COL_CALIFICACION_TRABAJADOR = "CALIFICACION_TRABAJADOR";
        private const string DB_COL_COMENTARIO_TRABAJADOR = "COMENTARIO_TRABAJADOR";
        private const string DB_COL_PRESUPUESTO = "PRESUPUESTO";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_PRECIO_FINAL = "PRECIO_FINAL";
        private const string DB_COL_ID_CLIENTE = "ID_CLIENTE";
        private const string DB_COL_ID_EMPRESA = "ID_EMPRESA";
        private const string DB_COL_ESPECIALIDADES = "ESPECIALIDADES";
        private const string DB_COL_TIPO_TRABAJO = "TIPO_TRABAJO";

        //Columnas de la empresa
        private const string DB_COL_CEDULA_EMPRESA = "CEDULA_EMPRESA";
        private const string DB_COL_NOMBRE_COMERCIAL = "NOMBRE_COMERCIAL";

        //Create statement sin Presupuesto
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_INSERT_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddNVarcharParam(DB_COL_TITULO, solicitud.Titulo);
            operation.AddNVarcharParam(DB_COL_DESCRIPCION, solicitud.Descripcion);
            operation.AddNVarcharParam(DB_COL_PROVINCIA, solicitud.Provincia);
            operation.AddNVarcharParam(DB_COL_CANTON, solicitud.Canton);
            operation.AddNVarcharParam(DB_COL_DISTRITO, solicitud.Distrito);
            operation.AddNVarcharParam(DB_COL_DIRECCION, solicitud.Direccion);
            operation.AddNVarcharParam(DB_COL_LATITUD, solicitud.Latitud);
            operation.AddNVarcharParam(DB_COL_LONGITUD, solicitud.Longitud);
            operation.AddDatetimeParam(DB_COL_FECHA_INICIO, solicitud.FechaInicio);
            operation.AddNVarcharParam(DB_COL_ESTADO, solicitud.Estado);
            operation.AddNVarcharParam(DB_COL_ID_CLIENTE, solicitud.ID_Cliente);

            return operation;
        }

        //Create statement con presupuesto
        public SqlOperation GetCreateConPresupuestoStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_INSERT_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddNVarcharParam(DB_COL_TITULO, solicitud.Titulo);
            operation.AddNVarcharParam(DB_COL_DESCRIPCION, solicitud.Descripcion);
            operation.AddNVarcharParam(DB_COL_PROVINCIA, solicitud.Provincia);
            operation.AddNVarcharParam(DB_COL_CANTON, solicitud.Canton);
            operation.AddNVarcharParam(DB_COL_DISTRITO, solicitud.Distrito);
            operation.AddNVarcharParam(DB_COL_DIRECCION, solicitud.Direccion);
            operation.AddNVarcharParam(DB_COL_LATITUD, solicitud.Latitud);
            operation.AddNVarcharParam(DB_COL_LONGITUD, solicitud.Longitud);
            operation.AddDecimalParam(DB_COL_PRESUPUESTO, solicitud.Presupuesto);
            operation.AddDatetimeParam(DB_COL_FECHA_INICIO, solicitud.FechaInicio);
            operation.AddNVarcharParam(DB_COL_ESTADO, solicitud.Estado);
            operation.AddNVarcharParam(DB_COL_ID_CLIENTE, solicitud.ID_Cliente);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_DELETE_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddIntParam(DB_COL_ID, solicitud.ID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_SELECT_ID_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddIntParam(DB_COL_ID, solicitud.ID);

            return operation;
        }

        public SqlOperation GetRetriveStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_SELECT_STATUS_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddNVarcharParam(DB_COL_ESTADO, solicitud.Estado);

            return operation;
        }

        //SP que retorna TODAS las solicitudes del cliente, incluyendo las desactivadas (NOT IMPLEMENTED YET)
        public SqlOperation GetRetriveIdClienteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_SELECT_ID_USUARIO_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddNVarcharParam(DB_COL_ID_CLIENTE, solicitud.ID_Cliente);

            return operation;
        }

        //SP que retorna TODAS las solicitudes del cliente incluyendo la informacion de la empresa
        public SqlOperation GetRetriveIdSolicitudEmpresaStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_SELECT_ID_EMPRESA_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddIntParam(DB_COL_ID, solicitud.ID);

            return operation;
        }

        //SP que retorna las solicitudes del usuario por estado y id de usuario. Utilizada para mostrar las solicides al usuario en el Front End
        public SqlOperation GetRetriveIdClienteStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_SELECT_ID_USUARIO_ESTADO_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddNVarcharParam(DB_COL_ID_CLIENTE, solicitud.ID_Cliente);
            operation.AddNVarcharParam(DB_COL_ESTADO, solicitud.Estado);

            return operation;
        }

        //SP que retorna las solicitudes del usuario por estado y id de usuario. Utilizada para mostrar las solicides al usuario en el Front End de aquellas que  ya fueron asignadas a una empresa, por lo que trae más información
        public SqlOperation GetRetriveIdClienteStatusEmpresaStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_SELECT_ID_USUARIO_ESTADO_EMPRESA_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddNVarcharParam(DB_COL_ID_CLIENTE, solicitud.ID_Cliente);
            operation.AddNVarcharParam(DB_COL_ESTADO, solicitud.Estado);

            return operation;
        }

        //Update de los valores base de una solicitud
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_UPDATE_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddIntParam(DB_COL_ID, solicitud.ID);
            operation.AddNVarcharParam(DB_COL_TITULO, solicitud.Titulo);
            operation.AddNVarcharParam(DB_COL_DESCRIPCION, solicitud.Descripcion);
            operation.AddNVarcharParam(DB_COL_PROVINCIA, solicitud.Provincia);
            operation.AddNVarcharParam(DB_COL_CANTON, solicitud.Canton);
            operation.AddNVarcharParam(DB_COL_DISTRITO, solicitud.Distrito);
            operation.AddNVarcharParam(DB_COL_DIRECCION, solicitud.Direccion);
            operation.AddNVarcharParam(DB_COL_LATITUD, solicitud.Latitud);
            operation.AddNVarcharParam(DB_COL_LONGITUD, solicitud.Longitud);
            operation.AddDatetimeParam(DB_COL_FECHA_INICIO, solicitud.FechaInicio);
            operation.AddDecimalParam(DB_COL_PRESUPUESTO, solicitud.Presupuesto);

            return operation;
        }

        public SqlOperation GetUpdateValoresPropuestaStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_UPDATE_VALORES_PROPUESTA_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddIntParam(DB_COL_ID, solicitud.ID);
            operation.AddNVarcharParam(DB_COL_CODIGO_QR, solicitud.CodigoQR);
            operation.AddNVarcharParam(DB_COL_ESTADO, solicitud.Estado);
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, solicitud.ID_Empresa);


            return operation;
        }

        public SqlOperation GetUpdateStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_UPDATE_ESTADO_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddIntParam(DB_COL_ID, solicitud.ID);
            operation.AddNVarcharParam(DB_COL_ESTADO, solicitud.Estado);

            return operation;
        }

        public SqlOperation GetRetrieveSolicitudOferente(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_RETRIVE_MATCH_SOLICTUD_OFERENTE_SP" };
            var usuario = (Entities_POJO.Usuario)entity;

            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, usuario.IdEmpresa);

            return operation;
        }

        public SqlOperation GetUpdatePrecioFinalStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_UPDATE_PRECIO_FINAL_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddIntParam(DB_COL_ID, solicitud.ID);
            operation.AddDecimalParam(DB_COL_PRECIO_FINAL, solicitud.PrecioFinal);

            return operation;
        }

        public SqlOperation GetCalificacionStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_UPDATE_CALIFICACION_SP" };
            var solicitud = (Entities_POJO.Solicitud)entity;

            operation.AddIntParam(DB_COL_ID, solicitud.ID);
            operation.AddNVarcharParam(DB_COL_COMENTARIO_TRABAJO, solicitud.ComentarioTrabajo);
            operation.AddNVarcharParam(DB_COL_COMENTARIO_EMPRESA, solicitud.ComentarioEmpresa);
            operation.AddNVarcharParam(DB_COL_COMENTARIO_TRABAJADOR, solicitud.ComentarioTrabajador);
            operation.AddIntParam(DB_COL_CALIFICACION_TRABAJO, solicitud.CalificacionTrabajo);
            operation.AddIntParam(DB_COL_CALIFICACION_EMPRESA, solicitud.CalificacionEmpresa);
            operation.AddIntParam(DB_COL_CALIFICACION_TRABAJADOR, solicitud.CalificacionTrabajador);
            operation.AddNVarcharParam(DB_COL_ESTADO, solicitud.Estado);

            return operation;
        }

        public SqlOperation GetRetrieveSolicitudCliente(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_RETRIVE_CLIENTE_SP" };
            var usuario = (Entities_POJO.Solicitud)entity;

            operation.AddNVarcharParam(DB_COL_ID_CLIENTE, usuario.ID_Cliente);

            return operation;
        }

        public SqlOperation GetRetrieveMisSolicitudOferentes(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_SOLICITUD_RETRIVE_OFERENTE_SP" };
            var usuario = (Entities_POJO.Solicitud)entity;

            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, usuario.ID_Empresa);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var solicitud = new Entities_POJO.Solicitud();
            if (row.ContainsKey(DB_COL_CEDULA_EMPRESA))
            {
                solicitud = new Entities_POJO.Solicitud()
                {
                    ID = GetIntValue(row, DB_COL_ID),
                    Titulo = GetStringValue(row, DB_COL_TITULO),
                    Descripcion = GetStringValue(row, DB_COL_DESCRIPCION),
                    Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                    Canton = GetStringValue(row, DB_COL_CANTON),
                    Distrito = GetStringValue(row, DB_COL_DISTRITO),
                    Direccion = GetStringValue(row, DB_COL_DIRECCION),
                    Latitud = GetStringValue(row, DB_COL_LATITUD),
                    Longitud = GetStringValue(row, DB_COL_LONGITUD),
                    FechaInicio = GetDateValue(row, DB_COL_FECHA_INICIO),
                    FechaFin = GetDateValue(row, DB_COL_FECHA_FIN),
                    CodigoQR = GetStringValue(row, DB_COL_CODIGO_QR),
                    CalificacionTrabajo = GetIntValue(row, DB_COL_CALIFICACION_TRABAJO),
                    ComentarioTrabajo = GetStringValue(row, DB_COL_COMENTARIO_TRABAJO),
                    CalificacionEmpresa = GetIntValue(row, DB_COL_CALIFICACION_EMPRESA),
                    ComentarioEmpresa = GetStringValue(row, DB_COL_COMENTARIO_EMPRESA),
                    ComentarioTrabajador = GetStringValue(row, DB_COL_COMENTARIO_TRABAJADOR),
                    CalificacionTrabajador = GetIntValue(row, DB_COL_CALIFICACION_TRABAJADOR),
                    Presupuesto = GetDecimalValue(row, DB_COL_PRESUPUESTO),
                    Estado = GetStringValue(row, DB_COL_ESTADO),
                    PrecioFinal = GetDecimalValue(row, DB_COL_PRECIO_FINAL),
                    ID_Cliente = GetStringValue(row, DB_COL_ID_CLIENTE),
                    CedulaEmpresa = GetStringValue(row, DB_COL_CEDULA_EMPRESA),
                    NombreComercial = GetStringValue(row, DB_COL_NOMBRE_COMERCIAL)
                };
            }
            else if (row.ContainsKey(DB_COL_ESPECIALIDADES))
            {
                solicitud = new Entities_POJO.Solicitud()
                {
                    ID = GetIntValue(row, DB_COL_ID),
                    Titulo = GetStringValue(row, DB_COL_TITULO),
                    Descripcion = GetStringValue(row, DB_COL_DESCRIPCION),
                    Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                    Canton = GetStringValue(row, DB_COL_CANTON),
                    Distrito = GetStringValue(row, DB_COL_DISTRITO),
                    Direccion = GetStringValue(row, DB_COL_DIRECCION),
                    Latitud = GetStringValue(row, DB_COL_LATITUD),
                    Longitud = GetStringValue(row, DB_COL_LONGITUD),
                    FechaInicio = GetDateValue(row, DB_COL_FECHA_INICIO),
                    FechaFin = GetDateValue(row, DB_COL_FECHA_FIN),
                    CodigoQR = GetStringValue(row, DB_COL_CODIGO_QR),
                    CalificacionTrabajo = GetIntValue(row, DB_COL_CALIFICACION_TRABAJO),
                    ComentarioTrabajo = GetStringValue(row, DB_COL_COMENTARIO_TRABAJO),
                    CalificacionEmpresa = GetIntValue(row, DB_COL_CALIFICACION_EMPRESA),
                    ComentarioEmpresa = GetStringValue(row, DB_COL_COMENTARIO_EMPRESA),
                    ComentarioTrabajador = GetStringValue(row, DB_COL_COMENTARIO_TRABAJADOR),
                    CalificacionTrabajador = GetIntValue(row, DB_COL_CALIFICACION_TRABAJADOR),
                    Presupuesto = GetDecimalValue(row, DB_COL_PRESUPUESTO),
                    Estado = GetStringValue(row, DB_COL_ESTADO),
                    PrecioFinal = GetDecimalValue(row, DB_COL_PRECIO_FINAL),
                    ID_Cliente = GetStringValue(row, DB_COL_ID_CLIENTE),
                    ID_Empresa = GetStringValue(row, DB_COL_ID_EMPRESA),
                    Especialidades = GetStringValue(row, DB_COL_ESPECIALIDADES),
                    TipoTrabajos = GetStringValue(row, DB_COL_TIPO_TRABAJO),
                };
            }
            else 
            {
                solicitud = new Entities_POJO.Solicitud()
                {
                    ID = GetIntValue(row, DB_COL_ID),
                    Titulo = GetStringValue(row, DB_COL_TITULO),
                    Descripcion = GetStringValue(row, DB_COL_DESCRIPCION),
                    Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                    Canton = GetStringValue(row, DB_COL_CANTON),
                    Distrito = GetStringValue(row, DB_COL_DISTRITO),
                    Direccion = GetStringValue(row, DB_COL_DIRECCION),
                    Latitud = GetStringValue(row, DB_COL_LATITUD),
                    Longitud = GetStringValue(row, DB_COL_LONGITUD),
                    FechaInicio = GetDateValue(row, DB_COL_FECHA_INICIO),
                    FechaFin = GetDateValue(row, DB_COL_FECHA_FIN),
                    CodigoQR = GetStringValue(row, DB_COL_CODIGO_QR),
                    CalificacionTrabajo = GetIntValue(row, DB_COL_CALIFICACION_TRABAJO),
                    ComentarioTrabajo = GetStringValue(row, DB_COL_COMENTARIO_TRABAJO),
                    CalificacionEmpresa = GetIntValue(row, DB_COL_CALIFICACION_EMPRESA),
                    ComentarioEmpresa = GetStringValue(row, DB_COL_COMENTARIO_EMPRESA),
                    ComentarioTrabajador = GetStringValue(row, DB_COL_COMENTARIO_TRABAJADOR),
                    CalificacionTrabajador = GetIntValue(row, DB_COL_CALIFICACION_TRABAJADOR),
                    Presupuesto = GetDecimalValue(row, DB_COL_PRESUPUESTO),
                    Estado = GetStringValue(row, DB_COL_ESTADO),
                    PrecioFinal = GetDecimalValue(row, DB_COL_PRECIO_FINAL),
                    ID_Cliente = GetStringValue(row, DB_COL_ID_CLIENTE),
                    ID_Empresa = GetStringValue(row, DB_COL_ID_EMPRESA)
                };
            }

            return solicitud;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var solicitud = BuildObject(element);
                listResults.Add(solicitud);
            }
            return listResults;
        }
    }
}
