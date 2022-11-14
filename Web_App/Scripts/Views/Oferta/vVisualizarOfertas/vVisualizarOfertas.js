
function vVisualizarOfertas() {

	this.tblOfertaId = 'tblOfertas';
	this.service = 'Oferta';
	this.GetIdAction = 'ObtenerPorSolicitud';

	this.ctrlActions = new ControlActions();
	this.identificadores = ["IdSolicitud"];

	this.RetrievePerID = function () {
		var solicitud = { ID_Solicitud: this.ctrlActions.GetSolicitud()} ;

		this.ctrlActions.FillTablePerID(this.service, this.GetIdAction, solicitud, this.tblOfertaId, false, this.ctrlActions.ButtonOptions.Expand);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblOfertaId, true);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields(this.editModalId, data);
		this.ctrlActions.BindFields(this.deleteModalId, data);
		this.ctrlActions.BindFields(this.statusModalId, data);
	}

	this.setIdSolicitudPendiente = function () {
		var solicitudData = sessionStorage.getItem('tblSolicitudesPendientesAdjudicar' + '_selected');
		if (Boolean(solicitudData)) {
			var id = JSON.parse(solicitudData).ID;
			sessionStorage.setItem('idSolicitud', id);
		}
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var ofertas = new vVisualizarOfertas();
	ofertas.setIdSolicitudPendiente();
	ofertas.RetrievePerID();

});

function expandFunction() {
	window.location.href = '/Oferta/vDetallesOferta';
}

