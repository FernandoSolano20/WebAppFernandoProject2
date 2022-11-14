
function vEspecialidad() {

	this.tblEspecialidadId = 'tblEspecialidad';
	this.service = 'Especialidad';
	this.updateStatusAction = 'UpdateStatus';

	this.editFormId = 'editModalForm';
	this.createFormId = 'createModalForm';

	this.editModalId = 'editModal';
	this.createModalId = 'createModal';
	this.deleteModalId = 'deleteModal';
	this.statusModalId = 'statusModal';

	this.ctrlActions = new ControlActions();
	this.identificadores = ["ID", "Nombre"];

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblEspecialidadId, false, this.ctrlActions.ButtonOptions.ModifyDeleteStatus);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblEspecialidadId, true);
	}

	this.Create = function () {
		var especialidadData = {};
		if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
			especialidadData = this.ctrlActions.GetDataForm(this.createFormId);
			//Hace el post al create
			this.ctrlActions.PostToAPI(this.service, especialidadData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var especialidad = new vEspecialidad();

				$('#' + especialidad.createModalId).modal('hide');
				especialidad.CleanInsert();
				ctrl.FillTable(especialidad.service, especialidad.tblEspecialidadId, true);

			});
		}
	}

	this.Update = function () {

		var especialidadData = {};
		if (!this.ctrlActions.ValidateDataForm(this.editFormId)) {

			especialidadData = this.ctrlActions.GetDataForm(this.editFormId);
			//Hace el post al create
			this.ctrlActions.PutToAPI(this.service, especialidadData, this.identificadores, function () {
				var ctrl = new ControlActions();
				var especialidad = new vEspecialidad();

				$('#' + especialidad.editModalId).modal('hide');
				especialidad.CleanUpdate();
				ctrl.FillTable(especialidad.service, especialidad.tblEspecialidadId, true);

			});

		}
	}

	this.Delete = function () {

		var especialidadData = {};
		especialidadData = this.ctrlActions.GetSelectedRow(this.tblEspecialidadId);
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, especialidadData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var especialidad = new vEspecialidad();

			$('#' + especialidad.deleteModalId).modal('hide');
			ctrl.FillTable(especialidad.service, especialidad.tblEspecialidadId, true);

		});

	}

	this.UpdateStatus = function () {

		var especialidadData = {};

		especialidadData = this.ctrlActions.GetSelectedRow(this.tblEspecialidadId);
		//Hace el post al create
		var serviceURL = `${this.service}/${this.updateStatusAction}`;

		this.ctrlActions.PutToAPI(serviceURL, especialidadData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var especialidad = new vEspecialidad();

			$('#' + especialidad.statusModalId).modal('hide');
			ctrl.FillTable(especialidad.service, especialidad.tblEspecialidadId, true);

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

	var especialidad = new vEspecialidad();
	especialidad.RetrieveAll();

});

