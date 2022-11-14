
function vGenerarSolicitudAdicionales() {

	this.tblEspecialidadId = 'tblEspecialidad';
	this.tblTipoTrabajoId = 'tblTipoTrabajo';
	this.tblFotografiaId = 'tblFotografia';

	this.service = 'Solicitud';
	this.serviceTipoTrabajo = 'TrabajoTipoTrabajo';
	this.serviceEspecialidad = 'TrabajoEspecialidad';
	this.serviceDocumento = 'Documento';

	//Acciones POST de tipos de trabajo, especialidades y fotografias
	this.PostFotografiaAction = "FotoInicialTrabajo";

	//Acciones GET de tipos de trabajo, especialidades y fotografias
	this.TipoTrabajoAction = "TiposTrabajoPorTrabajo";
	this.EspecialidadAction = "EspecialidadesPorTrabajo";
	this.FotografiaAction = "ObtenerFotosIniciales";
	this.UpdateSolicitudAction = "UpdateStatusPendiente";

	this.EspecialidadModalId = 'EspecialidadModal';
	this.TipoTrabajoModalId = 'TipoTrabajoModal';
	this.FotografiaModalId = 'FotografiaModal';

	//Modales eliminacion
	this.EspecialidadEliminarModalId = 'deleteModalFirst';
	this.TipoTrabajoEliminarModalId = 'deleteModalSecond';
	this.FotografiaEliminarModalId = 'deleteModalThird';


	this.ctrlActions = new ControlActions();
	this.identificadores = ["ID"];

	this.RetrieveData = function (service, route, params, idTabla, deleteType) {
		this.ctrlActions.FillTablePerID(service, route, params, idTabla, false, deleteType);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblTipoTrabajoId, true);
	}

	this.CreateEspecialidad = function () {
		var especialidadData = {};
		especialidadData = this.ctrlActions.GetDataForm(this.EspecialidadModalId);

		if (Boolean(especialidadData.ID_Especialidad)) {
			especialidadData.ID_Trabajo = sessionStorage.getItem('idSolicitud');
			//Hace el post al create
			this.ctrlActions.PostToAPI(this.serviceEspecialidad, especialidadData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var generarSolicitud = new vGenerarSolicitudAdicionales();

				ctrl.FillTable(generarSolicitud.serviceEspecialidad, generarSolicitud.tblEspecialidadId, true);
				generarSolicitud.CleanSelect();
			});
		}
	}

	this.CreateTipoTrabajo = function () {
		var tipoTrabajoData = {};
		tipoTrabajoData = this.ctrlActions.GetDataForm(this.TipoTrabajoModalId);

		if (Boolean(tipoTrabajoData.ID_Tipo_Trabajo)) {
			tipoTrabajoData.ID_Trabajo = sessionStorage.getItem('idSolicitud');
			//Hace el post al create
			this.ctrlActions.PostToAPI(this.serviceTipoTrabajo, tipoTrabajoData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var generarSolicitud = new vGenerarSolicitudAdicionales();

				ctrl.FillTable(generarSolicitud.serviceTipoTrabajo, generarSolicitud.tblTipoTrabajoId, true);
				generarSolicitud.CleanSelect();
			});
		}
	}

	this.CreateFotografia = function () {
		var fotografiaData = {};
		fotografiaData = this.ctrlActions.GetDataForm(this.FotografiaModalId);

		if (!this.ctrlActions.ValidateDataForm(this.FotografiaModalId)) {
			fotografiaData.ID_Propietario = sessionStorage.getItem('idSolicitud');
			//Hace el post al create
			this.ctrlActions.PostToAPI(this.serviceDocumento + "/" + this.PostFotografiaAction, fotografiaData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var generarSolicitud = new vGenerarSolicitudAdicionales();

				generarSolicitud.CleanInsert();
				ctrl.FillTable(generarSolicitud.serviceDocumento, generarSolicitud.tblFotografiaId, true);
				$('#' + generarSolicitud.FotografiaModalId).modal('hide');
			});
		}
	}

	this.DeleteEspecialidad = function () {

		var especialidadData = {};
		especialidadData = this.ctrlActions.GetSelectedRow(this.tblEspecialidadId);
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.serviceEspecialidad, especialidadData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var generarSolicitud = new vGenerarSolicitudAdicionales();

			$('#' + generarSolicitud.FirstDelete).modal('hide');
			ctrl.FillTable(generarSolicitud.serviceEspecialidad, generarSolicitud.tblEspecialidadId, true);

		});
	}

	this.DeleteTipoTrabajo = function () {

		var tipoTrabajoData = {};
		tipoTrabajoData = this.ctrlActions.GetSelectedRow(this.tblTipoTrabajoId);
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.serviceTipoTrabajo, tipoTrabajoData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var generarSolicitud = new vGenerarSolicitudAdicionales();

			$('#' + generarSolicitud.SecondDelete).modal('hide');
			ctrl.FillTable(generarSolicitud.serviceTipoTrabajo, generarSolicitud.tblTipoTrabajoId, true);

		});
	}

	this.DeleteFotografia = function () {

		var fotografiaData = {};
		fotografiaData = this.ctrlActions.GetSelectedRow(this.tblFotografiaId);
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.serviceDocumento, fotografiaData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var generarSolicitud = new vGenerarSolicitudAdicionales();

			$('#' + generarSolicitud.ThirdDelete).modal('hide');
			ctrl.FillTable(generarSolicitud.serviceFotografia, generarSolicitud.tblFotografiaId, true);

		});
	}

	this.UpdateSolicitud = function () {

		var solicitudData = {};
		solicitudData.ID = sessionStorage.getItem('idSolicitud');
		if (Boolean(solicitudData.ID)) {
			var service = this.service + "/" + this.UpdateSolicitudAction;
			//Hace el PUT al create
			this.ctrlActions.PutToAPI(service, solicitudData, this.identificadores, function () {

				$('#modalSolicitudCompletada').modal('toggle');
			});

		}
	}

	this.CleanInsert = function () {
		this.ctrlActions.CleanDataForm(this.FotografiaModalId);
	}

	this.CleanSelect = function () {
		$('.mdb-select').val($('.mdb-select').find("option[selected]").val());
	}


	this.BindFields = function (data) {
		this.ctrlActions.BindFields(this.EspecialidadEliminarModalId, data);
		this.ctrlActions.BindFields(this.TipoTrabajoEliminarModalId, data);
		this.ctrlActions.BindFields(this.FotografiaEliminarModalId, data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	//Se inicializa el prototype
	var funcionSolicitud = new vGenerarSolicitudAdicionales();

	//Se obtiene el id de la solicitud generado en la vista de Generar Solicitud cuando se envia el form
	var idTrabajo = { ID_Trabajo: sessionStorage.getItem('idSolicitud') };

	//Se inicializan los selects para mostrar su contenido
	$('.mdb-select.validate').materialSelect({
		validate: true,
		labels: {
			validFeedback: 'Correct choice',
			invalidFeedback: 'Wrong choice'
		}
	});

	//Se agregan los action listeners a los botones de cada modal
	$('#btnEspecialidadAgregar').on('click', function () {
		funcionSolicitud.CreateEspecialidad();
		$('#' + funcionSolicitud.EspecialidadModalId).modal('hide');
	});

	$('#btnTipoTrabajoAgregar').on('click', function () {
		funcionSolicitud.CreateTipoTrabajo();
		$('#' + funcionSolicitud.TipoTrabajoModalId).modal('hide');
	});

	$('#btnTipoTrabajoCancelar,#btnEspecialidadCancelar').on('click', function () {
		funcionSolicitud.CleanSelect();
	});

	$('#btnEnviarSolicitud').on('click', function () {
		funcionSolicitud.UpdateSolicitud();
		
	});


	//Obtener informacion de Especialidades
	funcionSolicitud.RetrieveData(funcionSolicitud.serviceEspecialidad, funcionSolicitud.EspecialidadAction, idTrabajo, funcionSolicitud.tblEspecialidadId, funcionSolicitud.ctrlActions.ButtonOptions.FirstDelete);


	//Obtener informacion Tipos de trabajo

	funcionSolicitud.RetrieveData(funcionSolicitud.serviceTipoTrabajo, funcionSolicitud.TipoTrabajoAction, idTrabajo, funcionSolicitud.tblTipoTrabajoId, funcionSolicitud.ctrlActions.ButtonOptions.SecondDelete);


	//Obtener informacion de fotografias
	var identificador = { Identificador: sessionStorage.getItem('idSolicitud') };

	funcionSolicitud.RetrieveData(funcionSolicitud.serviceDocumento, funcionSolicitud.FotografiaAction, identificador, funcionSolicitud.tblFotografiaId, funcionSolicitud.ctrlActions.ButtonOptions.ThirdDelete);
});
//dos puntos tres

