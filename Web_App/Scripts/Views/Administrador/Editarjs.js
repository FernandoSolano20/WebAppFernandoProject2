function EditarAdministrador() {

    this.service = 'Usuario';
    this.ctrlActions = new ControlActions();
    this.createFormId = "form-administrador";

    this.Create = function () {
        var entidad = {};
        entidad = this.ctrlActions.GetDataForm(this.createFormId);

        entidad.Longitud = "" + markers[0].position.lng();
        entidad.Latitud = "" + markers[0].position.lat();
        entidad.Identificacion = sessionStorage.getItem("Id");
        this.ctrlActions.PutToAPI(this.service,
            entidad, "Identificacion,Nombre", function () {
                var crtl = new ControlActions();
                crtl.GetToApi("Usuario/GetById?id=" + sessionStorage.getItem("Id") + "",
                    function(response) {
                        sessionStorage.setItem("Usuario", JSON.stringify(response)); 
                    });
            });
    }
}

//ON DOCUMENT READY
$(document).ready(function () {
    var ctrl = new ControlActions();
    var usuario = ctrl.GetLoggedInforUser();
    ctrl.BindFields("form-administrador", usuario);
    $("[for]").addClass("active");
    function initOferenteMap(timeToLoad) {
        setTimeout(function () {
            timeToLoad--;
            if (typeof google !== "undefined") {
                initMap(document.querySelector("#main #map"),
                    document.getElementById("borrar-marker"),
                    "Oferente");
                var usuario = ctrl.GetLoggedInforUser();
                addMarkerToMap({ lat: parseFloat(usuario.Latitud), lng: parseFloat(usuario.Longitud) })
            } else {
                initOferenteMap(timeToLoad);
            }
        }, 100);
    }

    initOferenteMap(100);

    
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
        max: new Date()
    });
});

