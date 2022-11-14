using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper.TrabajoSolicitud
{
    public class TrabajodorSolicitudMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_TRABAJADOR = "ID_TRABAJADOR";
        private const string DB_COL_ID_SOLICITUD = "ID_SOLICITUD";
        private const string DB_COL_PRECIO = "PRECIO";
        private const string DB_COL_ID_EMPRESA = "ID_EMPRESA";
        private const string DB_COL_PROMEDIO = "PROMEDIO";
        private const string DB_COL_HORAS_TRABAJADAS = "HORAS_TRABAJADAS";


        //Datos del trabajador
        private const string DB_COL_USUARIO_IDENTIFICACION = "IDENTIFICACION";
        private const string DB_COL_USUARIO_NOMBRE = "NOMBRE";
        private const string DB_COL_USUARIO_PRIMER_APELLIDO = "PRIMER_APELLIDO";
        private const string DB_COL_USUARIO_SEGUNDO_APELLIDO = "SEGUNDO_APELLIDO";


        //Precio final de la solicitud obtenido con la suma de la multiplicacion de las horas trabajadas y el precio de cada trabajador
        private const string DB_COL_PRECIO_FINAL = "PRECIO_TOTAL";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_TRABAJADOR_SOLICITUD_CREATE_SP" };

            var c = (TrabajadorSolicitud)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);
            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, c.IdTrabajador);
            operation.AddDecimalParam(DB_COL_PRECIO, c.Precio);
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_TRABAJADOR_SOLICITUD_RETRIVE_ID_SP" };

            var c = (Entities_POJO.TrabajadorSolicitud)entity;
            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, c.IdTrabajador);
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);

            return operation;
        }

        public SqlOperation GetAverageRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_SOLICITUD_AVERAGE_SP" };

            var c = (Entities_POJO.TrabajadorSolicitud)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);

            return operation;
        }

        public SqlOperation GetLowestRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_SOLICITUD_LOWEST_SP" };
            var c = (Entities_POJO.TrabajadorSolicitud)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);

            return operation;
        }

        public SqlOperation GetPriceRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_SOLICITUD_RETRIVE_ID_TRABAJADOR_SP" };

            var c = (Entities_POJO.TrabajadorSolicitud)entity;
            operation.AddNVarcharParam("IDENTIFICACION", c.IdTrabajador);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }


        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_TRABAJADOR_SOLICITUD_DELETE_SP" };

            var c = (TrabajadorSolicitud)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);
            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, c.IdTrabajador);

            return operation;
        }

        public SqlOperation GetRetriveTrabajadoresDataStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_TRABAJADOR_SOLICITUD_RETRIEVE_TRABAJADORES_SP" };

            var c = (Entities_POJO.TrabajadorSolicitud)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);

            return operation;
        }

        public SqlOperation GetUpdateHorasStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_TRABAJADOR_SOLICITUD_UPDATE_HORAS_TRABAJADAS_SP" };

            var solicitudTrabajador = (TrabajadorSolicitud)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, solicitudTrabajador.IdSolicitud);
            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, solicitudTrabajador.IdTrabajador);
            operation.AddIntParam(DB_COL_HORAS_TRABAJADAS, solicitudTrabajador.HorasTrabajadas);

            return operation;
        }

        public SqlOperation GetPrecioFinal(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_TRABAJADOR_SOLICITUD_PRECIO_FINAL_SP" };

            var solicitudTrabajador = (TrabajadorSolicitud)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, solicitudTrabajador.IdSolicitud);
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, solicitudTrabajador.IdEmpresa);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var user = BuildObject(row);
                lstResults.Add(user);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            TrabajadorSolicitud customer = null;
            if (row.ContainsKey("PRECIO_HORA"))
            {
                customer = new Entities_POJO.TrabajadorSolicitud
                {
                    Precio = GetDecimalValue(row, "PRECIO_HORA"),
                };
            }
            else if(row.ContainsKey(DB_COL_USUARIO_NOMBRE) && row.ContainsKey(DB_COL_USUARIO_PRIMER_APELLIDO) && row.ContainsKey(DB_COL_USUARIO_SEGUNDO_APELLIDO))
            {
                customer = new Entities_POJO.TrabajadorSolicitud
                {
                    IdSolicitud = GetIntValue(row, DB_COL_ID_SOLICITUD),
                    IdTrabajador = GetStringValue(row, DB_COL_USUARIO_IDENTIFICACION),
                    Precio = GetDecimalValue(row, DB_COL_PRECIO),
                    IdEmpresa = GetStringValue(row, DB_COL_ID_EMPRESA),
                    NombreUsuario = GetStringValue(row, DB_COL_USUARIO_NOMBRE),
                    PrimerApellidoUsuario = GetStringValue(row, DB_COL_USUARIO_PRIMER_APELLIDO),
                    SegundoApellidoUsuario = GetStringValue(row, DB_COL_USUARIO_SEGUNDO_APELLIDO)
                };
            }
            else if(row.ContainsKey(DB_COL_PROMEDIO))
            {
                customer = new Entities_POJO.TrabajadorSolicitud
                {
                    Promedio = GetDecimalValue(row, DB_COL_PROMEDIO),
                };
            }
            else if (row.ContainsKey(DB_COL_PRECIO_FINAL))
            {
                customer = new Entities_POJO.TrabajadorSolicitud
                {
                    IdSolicitud = GetIntValue(row, DB_COL_ID_SOLICITUD),
                    IdEmpresa = GetStringValue(row, DB_COL_ID_EMPRESA),
                    PrecioFinal = GetDecimalValue(row, DB_COL_PRECIO_FINAL)
                };
            }
            else
            {
                customer = new Entities_POJO.TrabajadorSolicitud
                {
                    IdSolicitud = GetIntValue(row, DB_COL_ID_SOLICITUD),
                    Precio = GetDecimalValue(row, DB_COL_PRECIO),
                    IdEmpresa = GetStringValue(row, DB_COL_ID_EMPRESA),
                };
            }
            
            return customer;
        }
    }
}
