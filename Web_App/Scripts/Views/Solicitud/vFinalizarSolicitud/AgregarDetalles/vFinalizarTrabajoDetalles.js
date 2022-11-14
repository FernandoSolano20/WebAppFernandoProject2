
function vFinalizarTrabajoDetalles() {

    this.service = 'Solicitud';

    this.retrieveSolicitudId = "SolicitudConEmpresa";
    this.actionAccionSolicitud = "vFinalizarTrabajoDetalles";

    //InformacionTrabajadores
    this.serviceTrabajadorSolicitud = "TrabajadorSolicitud";
    this.actionInformacionTrabajadores = "InformacionTrabajadores";

    this.ctrlActions = new ControlActions();
    this.divSolicitud = "main";

    this.RetrieveData = function () {
        var params = { ID_Solicitud: this.ctrlActions.GetSolicitud() };
        this.ctrlActions.GetToApiId(this.service, this.retrieveSolicitudId, params, function (data) {
            var finalizarTrabajo = new vFinalizarTrabajoDetalles();
            //Se configura la informacion del API a un formato mas amigable
            data = finalizarTrabajo.formatData(data);
            finalizarTrabajo.ctrlActions.BindFieldsContainer(finalizarTrabajo.divSolicitud, data);
            finalizarTrabajo.initMapa(100, data);

            params.ID_Empresa = finalizarTrabajo.getIdEmpresa();
            finalizarTrabajo.ctrlActions.GetToApiId(finalizarTrabajo.serviceTrabajadorSolicitud, finalizarTrabajo.actionInformacionTrabajadores, params, function (data) {
                finalizarTrabajo.construirListaTrabajadores(data);
            });

            finalizarTrabajo.ctrlActions.GetToApiId(finalizarTrabajo.serviceTrabajadorSolicitud, detallesOferta.actionInformacionTrabajadores, params, function (data) {
                detallesOferta.construirListaTrabajadores(data);
            });

        });
    }

    //Funcion utilizada para activar / finalizar un trabajo
    this.UpdateSolicitud = function (codigoQR) {
        var solicitudData = {};
        solicitudData.ID = this.ctrlActions.GetSolicitud();
        solicitudData.ID_QR = codigoQR;

        this.ctrlActions.PutToAPI(this.service + "/" + this.actionAccionSolicitud, solicitudData, "ID", function () {
            $('#modalAccionSolicitud').modal('toggle');
        });
    }

    this.initMapa = function (timeToLoad, data) {
        setTimeout(function () {
            timeToLoad--;
            if (typeof google !== "undefined") {
                initMap(document.querySelector("#main #map"),
                    document.getElementById("borrar-marker"),
                    "Solicitud");
                addMarkerToMap({ lat: parseFloat(data.Latitud), lng: parseFloat(data.Longitud) })
            } else {
                initMap(timeToLoad);
            }
        }, 100);
    }

    this.formatData = function (data) {
        if (data.Presupuesto != 'undefined') {
            if (data.Presupuesto === -1 || data.Presupuesto === 0)
                data.Presupuesto = "N/A";
        }

        if (Boolean(data.FechaInicio)) {
            var fechaInicio = new Date(data.FechaInicio);
            data.FechaInicio = fechaInicio.toLocaleDateString();
        }
        return data;
    }

    this.setIdSolicitud = function () {
        var solicitudData = sessionStorage.getItem('tblSolicitudesActivas' + '_selected');
        if (Boolean(solicitudData)) {
            var id = JSON.parse(solicitudData).ID;
            sessionStorage.setItem('idSolicitud', id);
        }
    }

    this.getIdEmpresa = function () {
        var ofertaData = sessionStorage.getItem('tblSolicitudesActivas' + '_selected');
        if (Boolean(ofertaData)) {
            var idEmpresa = JSON.parse(ofertaData).CedulaEmpresa;
            return idEmpresa;
        }
    }

    this.construirListaTrabajadores = function (data) {

        //Contenedor que va a contener la lista completa de trabajadores
        const trabajadoresContainer = document.querySelector('#listaTrabajadores');
        if (Boolean(data)) {
            data.forEach(function ({ NombreUsuario, PrimerApellidoUsuario, SegundoApellidoUsuario }, index) {

                //Nombre trabajador
                let pNombreTrabajador = document.createElement('p');
                pNombreTrabajador.innerHTML = `${NombreUsuario} ${PrimerApellidoUsuario} ${SegundoApellidoUsuario}`;

                trabajadoresContainer.appendChild(pNombreTrabajador);
            });
        }
    }

}

$(document).ready(function () {

    var finalizarTrabajo = new vFinalizarTrabajoDetalles();
    finalizarTrabajo.setIdSolicitud();

    finalizarTrabajo.RetrieveData();

    $('#btnContinuar').on('click', function () {
        window.location.href = '/Solicitud/vAgregarFotografias';
    });
});

