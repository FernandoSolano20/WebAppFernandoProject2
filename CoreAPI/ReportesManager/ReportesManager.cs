using DataAccess.Crud.Reportes;
using DataAccess.Crud.Reportes.IngresoMensualesPlataforma;
using Entities_POJO;
using Entities_POJO.Reportes;
using Entities_POJO.Reportes.IngresosPeriodoPlataforma;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.ReportesManager
{
    public class ReportesManager : BaseManager
    {
        public IngresosDiarios ReporteIngresosDiarios()
        {
            IngresosDiarios reporte = new IngresosDiarios()
            {
                TipoTransaccion =  TipoMovimiento.EntrantePlataforma
            };

            IngresosDiariosFactory factory = new IngresosDiariosFactory();
            try
            {

                reporte = factory.Retrieve<IngresosDiarios>(reporte);

                if (reporte == null)
                {
                    reporte = new IngresosDiarios()
                    {
                        MontoTotal = 0,
                        Fecha = DateTime.Now,
                        TipoTransaccion = TipoMovimiento.EntrantePlataforma
                    };
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return reporte;

        }

        public IngresosMensuales ReporteIngresosMensualesPlataforma(IngresosMensuales ingresosMensuales)
        {
            IngresosMensuales reporte = null;
            IngresosMensualesPlataformaFactory factory = new IngresosMensualesPlataformaFactory();
            try
            {

                reporte = factory.Retrieve<IngresosMensuales>(ingresosMensuales);

                if (reporte == null)
                {
                    throw new BusinessException("35");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return reporte;

        }
    }
}
