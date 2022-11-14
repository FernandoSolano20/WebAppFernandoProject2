
function Agregar() {

    this.tblUsuarioId = 'tblUsuario';
    this.service = 'Usuario';

    this.ctrlActions = new ControlActions();
    this.identificadores = ["Identificacion", "Nombre"];

    this.RetrieveAll = function () {
        var customActionColumn = [];

        var actionColumnAceptar = {};
        actionColumnAceptar.data = null;
        actionColumnAceptar.className = "text-center";
        actionColumnAceptar.defaultContent = '<a href="#" data-toggle="modal" data-target="#agregarModal"><i class="fas fa-user-check"></i></a>';

        customActionColumn.push(actionColumnAceptar);

        var actionColumnRechazar = {};
        actionColumnRechazar.data = null;
        actionColumnRechazar.className = "text-center";
        actionColumnRechazar.defaultContent = '<a href="#" data-toggle="modal" data-target="#eliminarModal"><i class="fas fa-user-times"></i></a>';

        customActionColumn.push(actionColumnRechazar);


        this.ctrlActions.FillTable(this.service + "/Trabajadores?idEmpresa=" + this.ctrlActions.GetLoggedInforUser().IdEmpresa, this.tblUsuarioId, false, "", customActionColumn);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service + "/Trabajadores?idEmpresa=" + this.ctrlActions.GetLoggedInforUser().IdEmpresa, this.tblUsuarioId, true);
    }

    this.Create = function () {
        var user = {};
        user = this.ctrlActions.GetSelectedRow(this.tblUsuarioId);

        var entidad = {
            IdSolicitud: Number(sessionStorage.IdSolicitud),
            IdTrabajador: user.Identificacion,
            IdEmpresa: this.ctrlActions.GetLoggedInforUser().IdEmpresa
        }

        this.ctrlActions.PostToAPI("TrabajadorSolicitud",
            entidad, "", function () {
            });
    }

    this.Delete = function () {

        var user = {};
        user = this.ctrlActions.GetSelectedRow(this.tblUsuarioId);

        var entidad = {
            IdSolicitud: Number(sessionStorage.IdSolicitud),
            IdTrabajador: user.Identificacion
        }

        this.ctrlActions.DeleteToAPI("TrabajadorSolicitud",
            entidad, "", function () {
            });

    }

    this.BindFields = function (data) {
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var listar = new Agregar();
    listar.RetrieveAll();

});

