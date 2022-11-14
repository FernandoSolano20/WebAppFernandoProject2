
function OferentesPendientes() {

    this.tbEntityId = 'tblOferente';
    this.service = 'Usuario';
    this.aceptarAction = 'Aceptar';

    this.aceptarModalId = 'aceptarModal';
    this.rechazarModalId = 'rechazarModal';

    this.ctrlActions = new ControlActions();
    this.identificadores = ["Identificacion", "Nombre"];

    this.RetrieveAll = function () {
        var url = this.service + "/OferentesPendientes";
        var customActionColumn = [];

        var actionColumnAceptar = {};
        actionColumnAceptar.data = null;
        actionColumnAceptar.className = "text-center";
        actionColumnAceptar.defaultContent = '<a href="#" data-toggle="modal" data-target="#aceptarModal"><i class="fas fa-user-check"></i></a>';

        customActionColumn.push(actionColumnAceptar);

        var actionColumnRechazar = {};
        actionColumnRechazar.data = null;
        actionColumnRechazar.className = "text-center";
        actionColumnRechazar.defaultContent = '<a href="#" data-toggle="modal" data-target="#rechazarModal"><i class="fas fa-user-times"></i></a>';

        customActionColumn.push(actionColumnRechazar);

        this.ctrlActions.FillTable(url, this.tbEntityId, false, "", customActionColumn);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service + "", this.tblTipoTrabajoId, true);
    }

    this.Rechazar = function () {

        var usuario = {};
        usuario = this.ctrlActions.GetSelectedRow(this.tbEntityId);
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, usuario, this.identificadores, function () {
            var ctrl = new ControlActions();
            var view = new OferentesPendientes();

            $('#' + view.rechazarModalId).modal('hide');
            var url = view.service + "/OferentesPendientes";
            ctrl.FillTable(url, view.tbEntityId, true);

        });

    }

    this.Aceptar = function () {

        var usuario = {};

        usuario = this.ctrlActions.GetSelectedRow(this.tbEntityId);
        usuario.Estado = "DESYNOPAGO";
        //Hace el post al create
        var serviceURL = `${this.service}/${this.aceptarAction}`;

        this.ctrlActions.PutToAPI(serviceURL, usuario, this.identificadores, function () {
            var ctrl = new ControlActions();
            var view = new OferentesPendientes();

            var url = "Membresia/MembresiaRegular";
            var membresaiRegular = {
                Tipo: "ESTANDAR",
                Moneda: usuario.Moneda,
                Costo: document.getElementById("normal").value,
                ID_Empresa: usuario.IdEmpresa
            }

            var identificador = ["Tipo", "Costo"];

            ctrl.PostToAPI(url, membresaiRegular, identificador,
                function (response) {
                });

            var membresiaPremium = {
                Tipo: "PREMIUM",
                Moneda: usuario.Moneda,
                Costo: document.getElementById("premium").value,
                ID_Empresa: usuario.IdEmpresa
            }
            ctrl.PostToAPI(url, membresiaPremium, identificador,
                function (response) {
                });

            var fi = {
                Tipo: "FI",
                Moneda: usuario.Moneda,
                Costo: document.getElementById("fi").value,
                ID_Empresa: usuario.IdEmpresa
            }
            ctrl.PostToAPI(url, fi, identificador,
                function (response) {
                });


            $('#' + view.aceptarModalId).modal('hide');


            var url = view.service + "/OferentesPendientes";
            ctrl.FillTable(url, view.tbEntityId, true);

        });
    }

    this.CleanUpdate = function () {
        this.ctrlActions.CleanDataForm("aceptarModal-form");
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('rechazarModal', data);
        var btnSave = document.getElementById("btnSave");
        btnSave.setAttribute("data-moneda", data.Moneda);
        var text = document.querySelector("#aceptarModal-form p").innerText.split(":")[0];
        document.querySelector("#aceptarModal-form p").innerText = text + ": USD";
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var view = new OferentesPendientes();
    view.RetrieveAll();

});

