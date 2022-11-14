function vEspecialidadTrabajador() {

	this.tblEspecialidadTrabajadorId = 'tblEspecialidadTrabajador';
	this.service = 'EspecialidadTrabajador';
	this.updateStatusAction = 'UpdateStatus';

	this.editFormId = 'editModalForm';
	this.createFormId = 'createModalForm';

	this.editModalId = 'editModal';
	this.createModalId = 'createModal';
	this.deleteModalId = 'deleteModal';
	this.statusModalId = 'statusModal';

	this.ctrlActions = new ControlActions();
	this.identificadores = ["Titulo"];

	//Traer toda la información
	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblEspecialidadTrabajadorId, false, this.ctrlActions.ButtonOptions.ModifyDeleteStatus);
	}

	//Recargar la tabla
	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblEspecialidadTrabajadorId, true);
	}

	//Create
	this.Create = function () {
		var especialidadTrabajadorData = {};
		if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
			especialidadTrabajadorData = this.ctrlActions.GetDataForm(this.createFormId);
			//Hace el post al API
			this.ctrlActions.PostToAPI(this.service, especialidadTrabajadorData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var especialidadTrabajador = new vEspecialidadTrabajador();

				$('#' + especialidadTrabajador.createModalId).modal('hide');
				especialidadTrabajador.CleanInsert();
				ctrl.FillTable(especialidadTrabajador.service, especialidadTrabajador.tblEspecialidadTrabajadorId, true);
			});
		}
	}

	//Update
	this.Update = function () {

		var especialidadTrabajadorData = {};
		if (!this.ctrlActions.ValidateDataForm(this.editFormId)) {

			especialidadTrabajadorData = this.ctrlActions.GetDataForm(this.editFormId);
			//Hace el put al API
			this.ctrlActions.PutToAPI(this.service, especialidadTrabajadorData, this.identificadores, function () {
				var ctrl = new ControlActions();
				var especialidadTrabajador = new vEspecialidadTrabajador();

				$('#' + especialidadTrabajador.editModalId).modal('hide');
				especialidadTrabajador.CleanUpdate();
				ctrl.FillTable(especialidadTrabajador.service, especialidadTrabajador.tblEspecialidadTrabajadorId, true);
			});
		}
	}

	//Delete
	this.Delete = function () {

		var especialidadTrabajadorData = {};
		especialidadTrabajadorData = this.ctrlActions.GetSelectedRow(this.tblEspecialidadTrabajadorId);
		//Hace el delete al API
		this.ctrlActions.DeleteToAPI(this.service, especialidadTrabajadorData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var especialidadTrabajador = new vEspecialidadTrabajador();

			$('#' + especialidadTrabajador.deleteModalId).modal('hide');
			ctrl.FillTable(especialidadTrabajador.service, especialidadTrabajador.tblEspecialidadTrabajadorId, true);
		});
	}

	//UpdateStatus
	this.UpdateStatus = function () {

		var especialidadTrabajadorData = {};

		especialidadTrabajadorData = this.ctrlActions.GetSelectedRow(this.tblEspecialidadTrabajadorId);

		var serviceURL = `${this.service}/${this.updateStatusAction}`;

		this.ctrlActions.PutToAPI(serviceURL, especialidadTrabajadorData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var especialidadTrabajador = new vEspecialidadTrabajador();

			$('#' + especialidadTrabajador.statusModalId).modal('hide');
			ctrl.FillTable(especialidadTrabajador.service, especialidadTrabajador.tblEspecialidadTrabajadorId, true);
		});
	}


	this.CleanInsert = function () {
		this.ctrlActions.CleanDataForm(this.createFormId);
	}

	this.CleanUpdate = function () {
		this.ctrlActions.CleanDataForm(this.editFormId);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('editModal', data);
		this.ctrlActions.BindFields('deleteModal', data);
		this.ctrlActions.BindFields('statusModal', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var especialidadTrabajador = new vEspecialidadTrabajador();
	especialidadTrabajador.RetrieveAll();

});