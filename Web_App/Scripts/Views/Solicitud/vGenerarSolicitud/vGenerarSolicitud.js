function vGenerarSolicitud() {

    this.service = 'Solicitud';
    this.ctrlActions = new ControlActions();
    this.createFormId = "form-solicitud";
    this.formSolicitud = "main";
    this.empresa = "form-empresa";
    this.identificadores = "Titulo";

    this.usuario = this.ctrlActions.GetLoggedInforUser();

    this.Create = function () {
        var entidad = {};
        entidad = this.ctrlActions.GetDataForm(this.formSolicitud);
        entidad.Longitud = "" + markers[0].marker.position.lng();
        entidad.Latitud = "" + markers[0].marker.position.lat();
        entidad.ID_Cliente = this.ctrlActions.GetLoggedUser().IdentificacionUsuario;

        this.ctrlActions.PostToAPI(this.service, entidad, this.identificadores, function (response) {
            sessionStorage.setItem("idSolicitud", response.Data);
            window.location.href = "vGenerarSolicitudAdicionales";
        });
    }

    this.CreateFormEmpresa = function () {
        this.ctrlActions.GetToServer("Empresa/Registrar", function (response) {
            $("#form-empresa").append(response);
        });
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var registrar = new vGenerarSolicitud();

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
        
        if (Boolean(registrar.ctrlActions.GetLoggedInforUser().Moneda)) {
            var monedaUsuario = registrar.ctrlActions.GetLoggedInforUser().Moneda;
            $("#monedaUsuario").text(" " + monedaUsuario);
        }     
    }
    

    function iniciarMapaSolicitud(timeToLoad) {
        setTimeout(function () {
            timeToLoad--;
            if (typeof google !== "undefined") {
                initMap(document.querySelector("#main #map"),
                    document.getElementById("borrar-marker"),
                    "Solicitud");
            } else {
                iniciarMapaSolicitud(timeToLoad);
            }
        }, 100);
    }

    iniciarMapaSolicitud(100);
    


    var provincia = document.getElementById("drp-provincia");
    var canton = document.querySelector("[data-container-drp-canton]");
    var distrito = document.querySelector("[data-container-drp-distrito]");
    selectsLocalizacion(provincia, canton, distrito);

    $('.mdb-select.validate').materialSelect({
        validate: true,
        labels: {
            validFeedback: 'Correct choice',
            invalidFeedback: 'Wrong choice'
        }
    });

    $('.datepicker').pickadate({
        format: 'mm-dd-yyyy',
        min: moment().add('days', 1).format('L')
    });

    actualizarMonedaUsuario();
});

