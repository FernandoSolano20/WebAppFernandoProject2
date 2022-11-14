function vTiposTrabajoXTrabJuridico() {

	this.tblTiposTrabajoXTrabJuridicoId = 'tblTiposTrabajoXTrabJuridico';
	this.service = 'TiposTrabajoXTrabJuridico';
	this.updateStatusAction = 'UpdateStatus';

	this.editFormId = 'editModalForm';
	this.createFormId = 'createModalForm';

	this.editModalId = 'editModal';
	this.createModalId = 'createModal';
	this.deleteModalId = 'deleteModal';
	this.statusModalId = 'statusModal';

	this.ctrlActions = new ControlActions();
	this.identificadores = ["Id_TipoTrabajo", "Precio_Hora"];

	//Traer toda la información
	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblTiposTrabajoXTrabJuridicoId,
			false, this.ctrlActions.ButtonOptions.ModifyDeleteStatus);
	}

	//Recargar la tabla
	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblTiposTrabajoXTrabJuridicoId, true);
	}

	//Create
	this.Create = function () {
		var TiposTrabajoXTrabJuridicoData = {};
		if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
			TiposTrabajoXTrabJuridicoData = this.ctrlActions.GetDataForm(this.createFormId);
			//Hace el post al API
			this.ctrlActions.PostToAPI(this.service, TiposTrabajoXTrabJuridicoData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var c = new vTiposTrabajoXTrabJuridico();

				$('#' + c.createModalId).modal('hide');
				c.CleanInsert();
				ctrl.FillTable(c.service, c.tblTiposTrabajoXTrabJuridicoId, true);
			});
		}
	}

	//Update
	this.Update = function () {

		var TiposTrabajoXTrabJuridicoData = {};
		if (!this.ctrlActions.ValidateDataForm(this.editFormId)) {

			TiposTrabajoXTrabJuridicoData = this.ctrlActions.GetDataForm(this.editFormId);
			//Hace el put al API
			this.ctrlActions.PutToAPI(this.service, TiposTrabajoXTrabJuridicoData, this.identificadores, function () {
				var ctrl = new ControlActions();
				var c = new vTiposTrabajoXTrabJuridico();

				$('#' + c.editModalId).modal('hide');
				c.CleanUpdate();
				ctrl.FillTable(c.service, c.tblTiposTrabajoXTrabJuridicoId, true);
			});
		}
	}

	//Delete
	this.Delete = function () {

		var TiposTrabajoXTrabJuridicoData = {};
		TiposTrabajoXTrabJuridicoData = this.ctrlActions.GetSelectedRow(this.tblTiposTrabajoXTrabJuridicoId);
		//Hace el delete al API
		this.ctrlActions.DeleteToAPI(this.service, TiposTrabajoXTrabJuridicoData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var c = new vTiposTrabajoXTrabJuridico();

			$('#' + c.deleteModalId).modal('hide');
			ctrl.FillTable(c.service, c.tblTiposTrabajoXTrabJuridicoId, true);
		});
	}

	//UpdateStatus
	this.UpdateStatus = function () {

		var TiposTrabajoXTrabJuridicoData = {};

		TiposTrabajoXTrabJuridicoData = this.ctrlActions.GetSelectedRow(this.tblTiposTrabajoXTrabJuridicoId);

		var serviceURL = `${this.service}/${this.updateStatusAction}`;

		this.ctrlActions.PutToAPI(serviceURL, TiposTrabajoXTrabJuridicoData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var c = new vTiposTrabajoXTrabJuridico();

			$('#' + c.statusModalId).modal('hide');
			ctrl.FillTable(c.service, c.tblTiposTrabajoXTrabJuridicoId, true);
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

	var c = new vTiposTrabajoXTrabJuridico();
	c.RetrieveAll();

});
