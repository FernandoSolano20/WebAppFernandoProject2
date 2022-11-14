
function Solicitudes() {

    this.tbEntityId = 'tblSolicitudes';
    this.service = 'Solicitud';

    this.ofertaModalId = 'ofertaModal';

    this.ctrlActions = new ControlActions();
    this.identificadores = ["Titulo"];

    this.RetrieveAll = function () {
        var url = this.service + "/ObtenerSolictudesParaOferentes?id=" + this.ctrlActions.GetLoggedUser().IdentificacionUsuario;
        var customActionColumn = [];

        var actionColumnAceptar = {};
        actionColumnAceptar.data = null;
        actionColumnAceptar.className = "text-center";
        actionColumnAceptar.defaultContent = '<a href="#" data-toggle="modal" data-target="#ofertaModal"><i class="fas fa-user-check"></i></a>';

        customActionColumn.push(actionColumnAceptar);

        this.ctrlActions.FillTable(url, this.tbEntityId, false, "", customActionColumn);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service + "", this.tblTipoTrabajoId, true);
    }

    this.Crear = function () {

        var solicitud = {};

        solicitud = this.ctrlActions.GetSelectedRow(this.tbEntityId);

        //Hace el post al create
        var serviceURL = "Oferta";

        var oferta = {
            IdSolicitud: solicitud.ID,
            IdEmpresa: this.ctrlActions.GetLoggedInforUser().IdEmpresa,
            Precio: solicitud.Presupuesto ? document.getElementById("precio").value : 0,
            TipoCobro: solicitud.Presupuesto ? "PRESUPUESTO" : "HORAS",
            Cancelacion: document.getElementById("cancelacion").value,
            Moneda: this.ctrlActions.GetLoggedInforUser().Moneda
        }

        this.ctrlActions.PostToAPI(serviceURL, oferta, ["IdSolicitud","IdEmpresa"], function () {
            var ctrl = new ControlActions();
            var view = new Solicitudes();

            $('#' + view.ofertaModalId).modal('hide');

            if (ctrl.GetRolesLoggedUser().some(x => x == "Oferente Jurídico")) {
                sessionStorage.IdSolicitud = oferta.IdSolicitud;
                sessionStorage.TipoCobro = oferta.TipoCobro;
                window.location.href = "../OferenteJuridico/AgregarTrabajadores";
            } else {
                var entidad = {
                    IdSolicitud: oferta.IdSolicitud,
                    IdTrabajador: ctrl.GetLoggedInforUser().Identificacion,
                    IdEmpresa: ctrl.GetLoggedInforUser().IdEmpresa
                }

                ctrl.PostToAPI("TrabajadorSolicitud",
                    entidad, "", function () {
                    });
            }
        });
    }

    this.CleanUpdate = function () {
        this.ctrlActions.CleanDataForm("ofertaModal-form");
    }

    this.BindFields = function (data) {
        if (data.Presupuesto <= 0) {
            document.getElementById("precio").parentElement.style.display = "none";
        } else {
            document.getElementById("precio").parentElement.style.display = "";
        }
        this.ctrlActions.BindFields("ofertaModal-form", data);
        document.querySelector("#ofertaModalModal-form p").innerHTML = "";
        if (sessionStorage.EsPremium == "true") {
            var average = this.ctrlActions.GetLanguage() == "es" ? "Promedio" : "Average";
            var low = this.ctrlActions.GetLanguage() == "es" ? "Precio más bajo" : "Lowest price";
            if (data.Presupuesto > 0) {
                this.ctrlActions.GetToApi("/Oferta/GetAverage?idSolicitud=" + data.ID,
                    function (response) {
                        document.querySelector("#ofertaModalModal-form p").innerHTML += average + " " + (response && response.Promedio > 0? response.Promedio : 0) + " USD";
                    });

                this.ctrlActions.GetToApi("/Oferta/GetLow?idSolicitud=" + data.ID,
                    function (response) {
                        document.querySelector("#ofertaModalModal-form p").innerHTML += "<br>" + low + " " + (response ? response.Precio:0) +" USD";
                    });
            } else {
                this.ctrlActions.GetToApi("/TrabajadorSolicitud/GetAverage?idSolicitud=" + data.ID,
                    function (response) {
                        document.querySelector("#ofertaModalModal-form p").innerHTML += average + " " + (response ? response.Promedio : 0)+ " USD";
                    });

                this.ctrlActions.GetToApi("/TrabajadorSolicitud/GetLow?idSolicitud=" + data.ID,
                    function (response) {
                        document.querySelector("#ofertaModalModal-form p").innerHTML += "<br> " + low + " " + (response ? response.Promedio : 0) + " USD";
                    });
            }
            
        }
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var view = new Solicitudes();
    view.RetrieveAll();

});

