function vTrabajosXProvJuridico() {

	this.tblTrabajosXProvJuridicoId = 'tblTrabajosXProvJuridico';	//--> Nombre de la tabla en el cshtml.
	this.service = 'TrabajosXProvJuridico';							//--> Nombre del Controller.
	//this.PostTipoTrabajoRoute = 'TipoTrabajoProvJuridico';			//--> Nombre final de la ruta que seguirá al hacer Post.
	this.updateStatusAction = 'UpdateStatus';						//--> Nombre final de la ruta que seguirá al hacer UpdateStatus.
	this.getPerIDAction = 'ObtenerPorUsuario';						//--> Nombre final de la ruta que seguirá al hacer Get by Usuario.

	this.createFormId = 'createModalForm';
	this.editFormId = 'editModalForm';

	this.createModalId = 'createModal';
	this.editModalId = 'editModal';
	this.deleteModalId = 'deleteModal';
	this.statusModalId = 'statusModal';

	this.ctrlActions = new ControlActions();
	this.identificadores = ["Id_TipoTrabajo", "Precio_Hora"];		//Etiquetas más representativas para la bitacora.



	//Traer la información del usuario loggeado --> "Get by Id_Trabajador" en el Controller
	 this.RetrievePerID = function () {
		var usuario = this.ctrlActions.GetLoggedUser();

		this.ctrlActions.FillTablePerID(
			this.service,
			this.getPerIDAction,
			usuario,
			this.tblTrabajosXProvJuridicoId,
			false,
			this.ctrlActions.ButtonOptions.ModifyDeleteStatus);
	}
	

	//Recargar la tabla --> "Get all" en el Controller
	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblTrabajosXProvJuridicoId, true);
	}

	//Create --> "Post" en el Controller
	this.Create = function () {
		var trabajosProvJuridicoData = {};
		if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
			trabajosProvJuridicoData = this.ctrlActions.GetDataForm(this.createFormId);

			//Se añade el usuario
			trabajosProvJuridicoData['Id_Trabajador'] = this.ctrlActions.GetLoggedUser().IdentificacionUsuario;
			
			//var service = this.service + "/" + this.PostTipoTrabajoRoute;	//--> Dirección completa de Url para Post en Controller

			//Hace el post al API
			this.ctrlActions.PostToAPI(this.service, trabajosProvJuridicoData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var local = new vTrabajosXProvJuridico();

				$('#' + local.createModalId).modal('hide');
				local.CleanInsert();
				ctrl.FillTable(local.service, local.tblTrabajosXProvJuridicoId, true);
			});
		}
	}

	//Update --> "Put" en el Controller (No aplica, se dejó solo para referencia)
	/*
	this.Update = function () {

		var trabajosProvJuridicoData = {};
		if (!this.ctrlActions.ValidateDataForm(this.editFormId)) {

			trabajosProvJuridicoData = this.ctrlActions.GetDataForm(this.editFormId);

			//Se añade el propietario del documento
			trabajosProvJuridicoData['Id_Trabajador'] = this.ctrlActions.GetLoggedUser().IdentificacionUsuario;

			//Hace el put al API
			this.ctrlActions.PutToAPI(this.service, trabajosProvJuridicoData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var local = new vTrabajosXProvJuridico();

				$('#' + local.editModalId).modal('hide');
				local.CleanUpdate();
				ctrl.FillTable(local.service, local.tblTrabajosXProvJuridicoId, true);
			});
		}
	}
	*/

	//Delete --> "Delete" en el Controller
	this.Delete = function () {

		var trabajosProvJuridicoData = {};
		trabajosProvJuridicoData = this.ctrlActions.GetSelectedRow(this.tblTrabajosXProvJuridicoId);

		//Hace el delete al API
		this.ctrlActions.DeleteToAPI(this.service, trabajosProvJuridicoData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var local = new vTrabajosXProvJuridico();

			$('#' + local.deleteModalId).modal('hide');
			ctrl.FillTable(local.service, local.tblTrabajosXProvJuridicoId, true);
		});
	}

	//UpdateStatus --> "UpdateStatus" en el Controller

	this.UpdateStatus = function () {

		var trabajosProvJuridicoData = {};

		trabajosProvJuridicoData = this.ctrlActions.GetSelectedRow(this.tblTrabajosXProvJuridicoId);

		var serviceURL = `${this.service}/${this.updateStatusAction}`;

		this.ctrlActions.PutToAPI(serviceURL, trabajosProvJuridicoData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var local = new vTrabajosXProvJuridico();

			$('#' + local.statusModalId).modal('hide');
			ctrl.FillTable(local.service, local.tblTrabajosXProvJuridicoId, true);
		});
	}


	this.CleanInsert = function () {
		this.ctrlActions.CleanDataForm(this.createFormId);
	}

	this.CleanUpdate = function () {
		this.ctrlActions.CleanDataForm(this.editFormId);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields(this.editModalId, data);
		this.ctrlActions.BindFields(this.deleteModalId, data);
		this.ctrlActions.BindFields(this.statusModalId, data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var local = new vTrabajosXProvJuridico();
	local.RetrievePerID();

});
