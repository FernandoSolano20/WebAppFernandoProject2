
function vAgregarFotografias() {

	this.tblFotografiaId = 'tblFotografia';
	this.service = 'Documento';
	this.PostDocumentRoute = 'FotoFinalTrabajo';
	this.getPerIDAction = 'ObtenerFotosFinales';

	this.createFormId = 'createModalForm';
	this.editFormId = 'editModalForm';

	this.createModalId = 'createModal';
	this.deleteModalId = 'deleteModalFirst';

	this.ctrlActions = new ControlActions();
	this.identificadores = ["ID"];

	this.RetrievePerID = function () {
		var solicitud = { Identificador: this.ctrlActions.GetSolicitud()};

		this.ctrlActions.FillTablePerID(this.service, this.getPerIDAction, solicitud, this.tblFotografiaId, false, this.ctrlActions.ButtonOptions.FirstDelete);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblFotografiaId, true);
	}

	this.CreatePhoto = function () {
		var fotografiaData = {};
		if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
			fotografiaData = this.ctrlActions.GetDataForm(this.createFormId);
			//Se añade el propietario del fotografia (en este caso, es la solicitud de trabajo)
			fotografiaData['ID_Propietario'] = this.ctrlActions.GetSolicitud();
			//Se redirige al action de fotografia
			var service = this.service + "/" + this.PostDocumentRoute;
			this.ctrlActions.PostToAPI(service, fotografiaData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var fotografia = new vAgregarFotografias();

				$('#' + fotografia.createModalId).modal('hide');
				fotografia.CleanInsert();
				ctrl.FillTable(fotografia.service, fotografia.tblFotografiaId, true);

			});
		}
	}

	this.DeletePhoto = function () {

		var fotografiaData = {};
		fotografiaData = this.ctrlActions.GetSelectedRow(this.tblFotografiaId);
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, fotografiaData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var fotografia = new vAgregarFotografias();

			$('#' + fotografia.deleteModalId).modal('hide');
			ctrl.FillTable(fotografia.service, fotografia.tblFotografiaId, true);

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

	var fotografia = new vAgregarFotografias();
	fotografia.RetrievePerID();

	$('#btnContinuar').on('click', function () {
		window.location.href = '/Solicitud/vHorasTrabajadas';
	});

});

