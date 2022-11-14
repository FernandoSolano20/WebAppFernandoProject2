using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities_POJO;

namespace Web_App.Models
{
    public class SolicitudCalendar
    {
        public string title { get; set; }
        public string start { get; set; }
        //public string end { get; set; }
        //public string url { get; set; }
        public string color { get; set; }

        public IList<SolicitudCalendar> ConvertToSolicitudCalendar(IList<Solicitud> solicitud)
        {
            var results = new List<SolicitudCalendar>();

            foreach (var solicitud1 in solicitud)
            {
                var color = "#7E2525";

                if (solicitud1.Estado == Estado.PENDIENTE_ADJUDICAR || solicitud1.Estado == Estado.PENDIENTE_ADJUDICAR_DESACTIVADA)
                {
                    color = "#4F7E25";
                }
                else if (solicitud1.Estado == Estado.POR_INICIAR)
                {
                    color = "#7B7E25";
                }
                else if (solicitud1.Estado == Estado.ACT)
                {
                    color = "#25627E";
                }
                else if (solicitud1.Estado == Estado.PENDIENTE_CALIFICAR)
                {
                    color = "#66257E";
                }

                results.Add(new SolicitudCalendar()
                {
                    title = solicitud1.Titulo,
                    start = solicitud1.FechaInicio.ToString("yyyy-MM-dd"),
                    color = color
                });
            }

            return results;
        }
    }
}