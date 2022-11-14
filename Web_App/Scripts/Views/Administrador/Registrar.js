function RegistrarAdministrador() {

    this.service = 'Usuario';
    this.ctrlActions = new ControlActions();
    this.createFormId = "form-administrador";

    this.Create = function () {
        var entidad = {};
        entidad = this.ctrlActions.GetDataForm(this.createFormId);

        entidad.Longitud = "" + markers[0].marker.position.lng();
        entidad.Latitud = "" + markers[0].marker.position.lat();

        this.ctrlActions.PostToAPI(this.service + "/Administrador",
            entidad, "Identificacion,Nombre", function () {
                window.location.href = "/Home/Login";
            });
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    function initOferenteMap(timeToLoad) {
        setTimeout(function () {
            timeToLoad--;
            if (typeof google !== "undefined") {
                initMap(document.querySelector("#main #map"),
                    document.getElementById("borrar-marker"),
                    "Oferente");
            } else {
                initOferenteMap(timeToLoad);
            }
        }, 100);
    }

    initOferenteMap(100);

    var identificaciones = document.querySelectorAll("input[name='identificacion']");
    identificaciones.forEach(ele => {
        ele.addEventListener("click", function () {
            if (this.type === "radio") {
                var inputId = document.getElementById("id");
                inputId.name = "id" + this.id;
                inputId.removeAttribute("disabled");
                var labelId = document.querySelector("label[for='id']");
                labelId.innerText = this.value;
                labelId.className = labelId.className.replace("disabled", "");
            }
        });
    });


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

