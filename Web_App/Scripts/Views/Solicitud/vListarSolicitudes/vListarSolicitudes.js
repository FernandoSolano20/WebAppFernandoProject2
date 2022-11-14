
function vListarSolicitudes() {

	this.tblSolicitudActivoId = 'tblSolicitudesActivas';
	this.tblSolicitudCompletoId = 'tblSolicitudesCompletas';
	this.tblSolicitudPendienteAdjudicarId = 'tblSolicitudesPendientesAdjudicar';
	this.tblSolicitudPendienteCalificarId = 'tblSolicitudesPendientesCalificar';
	this.tblSolicitudPorIniciar = 'tblSolicitudesPorIniciar';

	this.service = 'Solicitud';
	this.listarActivo = 'ActivoPorUsuario';
	this.listarPendienteAdjudicar = 'PendienteAdjudicarPorUsuario';
	this.listarPendienteCalificar = 'PendienteCalificarPorUsuario';
	this.listarCompleto = 'CompletoPorUsuario';
	this.listarPorIniciar = 'PorIniciarPorUsuario';

	this.updateStatusAction = 'UpdateStatus';

/* MODALES */

	//Modales solicitudes pendientes de adjudicar
	this.CancelarPendienteAdjudicarModalId = 'deleteModal';
	this.EstadoPendienteAdjudicarModalId = 'statusModal';

	//Modales solicitudes activas
	this.CancelarActivoModalId = 'CancelarActivoModal';


	this.ctrlActions = new ControlActions();
	this.identificadores = ["ID", "Titulo"];

	this.RetrieveData = function (service, route, params, idTabla, buttonsOptions) {
		this.ctrlActions.FillTablePerID(service, route, params, idTabla, false, buttonsOptions);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblSolicitudId, true);
	}

	this.DeletePendienteAdjudicar = function () {

		var solicitudData = {};
		solicitudData = this.ctrlActions.GetSelectedRow(this.tblSolicitudPendienteAdjudicarId);
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, solicitudData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var solicitud = new vListarSolicitudes();

			$('#' + solicitud.CancelarPendienteAdjudicarModalId).modal('hide');
			ctrl.FillTable(solicitud.service, solicitud.tblSolicitudPendienteAdjudicarId, true);

		});
	}

	this.UpdateStatusPendienteAdjudicar = function () {

		var solicitudData = {};

		solicitudData = this.ctrlActions.GetSelectedRow(this.tblSolicitudPendienteAdjudicarId);
		//Hace el post al create
		var serviceURL = `${this.service}/${this.updateStatusAction}`;

		this.ctrlActions.PutToAPI(serviceURL, solicitudData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var solicitud = new vListarSolicitudes();

			$('#' + solicitud.EstadoPendienteAdjudicarModalId).modal('hide');
			ctrl.FillTable(solicitud.service, solicitud.tblSolicitudPendienteAdjudicarId, true);

		});
	}

	this.CleanInsert = function () {
		this.ctrlActions.CleanDataForm(this.createFormId);
	}

	this.CleanUpdate = function () {
		this.ctrlActions.CleanDataForm(this.editFormId);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields(this.CancelarPendienteAdjudicarModalId, data);
		this.ctrlActions.BindFields(this.CancelarActivoModalId, data);
	}

}

//ON DOCUMENT READY
$(document).ready(function () {

	var solicitud = new vListarSolicitudes();
	var params = solicitud.ctrlActions.GetLoggedUser();

	$('#btnGenerarSolicitud').on('click', function () {
		window.location.href = '/Solicitud/vGenerarSolicitud';
	});

	//Solicitudes pendientes adjudicar
	solicitud.RetrieveData(solicitud.service, solicitud.listarPendienteAdjudicar, params, solicitud.tblSolicitudPendienteAdjudicarId, solicitud.ctrlActions.ButtonOptions.OffersModifyDeleteStatus);

	//Solicitudes por iniciar
	solicitud.RetrieveData(solicitud.service, solicitud.listarPorIniciar, params, solicitud.tblSolicitudPorIniciar, solicitud.ctrlActions.ButtonOptions.StartJobRequest);

	//Solicitudes activas
	solicitud.RetrieveData(solicitud.service, solicitud.listarActivo, params, solicitud.tblSolicitudActivoId, solicitud.ctrlActions.ButtonOptions.EndJobRequest);

	//Solicitudes pendientes calificar
	solicitud.RetrieveData(solicitud.service, solicitud.listarPendienteCalificar, params, solicitud.tblSolicitudPendienteCalificarId, solicitud.ctrlActions.ButtonOptions.RateJobRequest);

	//Solicitudes completas
	solicitud.RetrieveData(solicitud.service, solicitud.listarCompleto, params, solicitud.tblSolicitudCompletoId);

});

//Funciones utilizadas para redirigir a los usuarios a las diferentes vistas dependiendo de el icono utilizado
function editFunction() {
	window.location.href = 'vEditarSolicitud';
}

function viewFunction() {
	window.location.href = '/Oferta/vVisualizarOfertas';
}

function startFunction() {
	window.location.href = '/Solicitud/vIniciarTrabajo';
}

function endFunction() {
	window.location.href = '/Solicitud/vFinalizarTrabajoDetalles';
}

function rateFunction() {
	window.location.href = '/Solicitud/vCalificarTrabajo';
}


