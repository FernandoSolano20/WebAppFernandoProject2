function vEditarSolicitud() {

    this.service = 'Solicitud';
    this.retrieveSolicitudId = "SolicitudID";
    this.ctrlActions = new ControlActions();
    this.editFormId = "form-solicitud";



    this.RetrieveData = function () {
        var params = { id: this.ctrlActions.GetSolicitud() };
        this.ctrlActions.GetToApiId(this.service, this.retrieveSolicitudId, params, function (data) {
            var editarSolicitud = new vEditarSolicitud();
            editarSolicitud.ctrlActions.BindFields("form-solicitud", data);
            editarSolicitud.initMapa(100, data);
        });
    }


    this.UpdateSolicitud = function () {
        var entidad = {};
        entidad = this.ctrlActions.GetDataForm(this.editFormId);
        var presupuestoMarcado = document.querySelector('#checkPresupuesto').checked;
        if (!presupuestoMarcado)
            entidad.Presupuesto = 0;

        if (Boolean(markers[0].marker)) {

            entidad.Longitud = "" + markers[0].marker.position.lng();
            entidad.Latitud = "" + markers[0].marker.position.lat();
            entidad.ID = this.ctrlActions.GetSolicitud();

            this.ctrlActions.PutToAPI(this.service, entidad, "ID", function () {
                window.location.href = "vGenerarSolicitudAdicionales";

            });
        }
        else if (Boolean(markers[0])) {
            entidad.Longitud = "" + markers[0].position.lng();
            entidad.Latitud = "" + markers[0].position.lat();
            entidad.ID = this.ctrlActions.GetSolicitud();

            this.ctrlActions.PutToAPI(this.service, entidad, "ID", function () {
                window.location.href = "vGenerarSolicitudAdicionales";

            });
        }
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

    this.setIdSolicitudPendiente = function () {
        var solicitudData = sessionStorage.getItem('tblSolicitudesPendientesAdjudicar' + '_selected');
        if (Boolean(solicitudData)) {
            var id = JSON.parse(solicitudData).ID;
            sessionStorage.setItem('idSolicitud', id);
        }
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var editarSolicitud = new vEditarSolicitud();
    var ctrl = editarSolicitud.ctrlActions;

    editarSolicitud.setIdSolicitudPendiente();

    editarSolicitud.RetrieveData();

    $("[for]").addClass("active");

    $('#checkPresupuesto').change(function (e) {
        e.preventDefault();
        if (this.checked) {
            $(':input:eq(' + ($(':input').index(this) + 1) + ')').focus();
            $("#txtPresupuesto").removeClass("disabled");
        }
        else {
            $("#txtPresupuesto").addClass("disabled");
            $("#txtPresupuesto").val("");
        }
    });

    //Permite mostrar la moneda del usuario en el campo del Presupuesto. Requiere que el usuario este loggeado
    function actualizarMonedaUsuario() {

        if (Boolean(editarSolicitud.ctrlActions.GetLoggedInforUser().Moneda)) {
            var monedaUsuario = editarSolicitud.ctrlActions.GetLoggedInforUser().Moneda;
            $("#monedaUsuario").text(" " + monedaUsuario);
        }
    }

    var provincia = document.getElementById("drp-provincia");
    var canton = document.querySelector("[data-container-drp-canton]");
    var distrito = document.querySelector("[data-container-drp-distrito]");
    selectsLocalizacion(provincia, canton, distrito);

    $('#main .mdb-select.validate').materialSelect({
        validate: true,
        labels: {
            validFeedback: 'Correct choice',
            invalidFeedback: 'Wrong choice'
        }
    });

    $('#main .datepicker').pickadate({
        format: 'mm-dd-yyyy',
        min: moment().add('days', 1).format('L')
    });

    actualizarMonedaUsuario();


});



