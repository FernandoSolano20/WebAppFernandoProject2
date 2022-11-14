
function vCalificarTrabajo() {

    this.service = 'Solicitud';

    this.actionCalificarSolicitud = "CalificarSolicitud";

    this.ctrlActions = new ControlActions();
    this.divSolicitud = "main";

    this.rateTrabajo = "rateTrabajo";
    this.rateTrabajador = "rateTrabajador";
    this.rateEmpresa = "rateEmpresa";

    //Funcion utilizada para activar / finalizar un trabajo
    this.UpdateSolicitud = function () {
        var solicitudData = {};

        if (!this.ctrlActions.ValidateDataForm(this.divSolicitud)) {
            solicitudData = this.ctrlActions.GetDataForm(this.divSolicitud);
            solicitudData.ID = this.ctrlActions.GetSolicitud();
            solicitudData.CalificacionTrabajo = this.validarCantidadEstrellas(this.rateTrabajo);
            solicitudData.CalificacionTrabajador = this.validarCantidadEstrellas(this.rateTrabajador);
            solicitudData.CalificacionEmpresa = this.validarCantidadEstrellas(this.rateEmpresa);

            this.ctrlActions.PutToAPI(this.service + "/" + this.actionCalificarSolicitud, solicitudData, "ID", function () {
                window.location.href = '/Solicitud/vListarSolicitudes';
            });
        }
    }

    this.setIdSolicitud = function () {
        var solicitudData = sessionStorage.getItem('tblSolicitudesPendientesCalificar' + '_selected');
        if (Boolean(solicitudData)) {
            var id = JSON.parse(solicitudData).ID;
            sessionStorage.setItem('idSolicitud', id);
        }
    }

    this.validarCantidadEstrellas = function (contenedorEstrellas) {
        var estilosEstrellas = ['oneStar', 'twoStars', 'threeStars', 'fourStars', 'fiveStars'];
        var lista = document.querySelectorAll('#' + contenedorEstrellas + ' i');
        var cantidadEstrellas = 0;

        lista.forEach((element, index) => {
            if (lista.item(0).classList.contains(estilosEstrellas[index])) {
                cantidadEstrellas = index + 1;
            }
        });

        return cantidadEstrellas;
    }
}

$(document).ready(function () {

    var calificarTrabajo = new vCalificarTrabajo();
    calificarTrabajo.setIdSolicitud();
    $('#rateTrabajo').mdbRate();
    $('#rateTrabajador').mdbRate();
    $('#rateEmpresa').mdbRate();

    $('#btnGuardar').on('click', function () {
        calificarTrabajo.UpdateSolicitud();
    });

});