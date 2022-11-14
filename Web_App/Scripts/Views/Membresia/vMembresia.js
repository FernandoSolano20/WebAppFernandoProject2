
function vMembresia() {

	this.service = 'Membresia';

	//Obtener las membresias por tipo
	this.updateStatusAction = 'UpdateDate';
	this.UpdatePremiumAction = 'UpdatePremiumDate';

	//Actualizar fechas de las membresias por tipo
	this.getCurrentStandardMembershipAction = 'MembresiaEstandarActual';
	this.getCurrentPremiumMembershipAction = 'MembresiaPremiumActual';

	//Etiquetas span html para mostrar el valor de la membresia
	this.txtCostoMembresiaEstandar = 'txtCostoEstandar';
	this.txtMonedaMembresiaEstandar = 'txtMonedaEstandar';

	//Botones html para mostrar los modales necesarios para pagar la membresia
	this.btnMostrarModalMembresiaEstandar = 'btnAdquirirEstandar';
	this.btnMostrarModalMembresiaPremium = 'btnAdquirirPremium';

	//Modales membresia Estandar
	this.membresiaEstandarModalId = 'membresiaEstandarModal';
	this.membresiaEstandarAmpliarModalId = 'membresiaEstandarAmpliarModal';

	//Modales membresia Premium
	this.membresiaPremiumModalId = 'membresiaPremiumModal';
	this.membresiaPremiumAmpliarModalId = 'membresiaPremiumAmpliarModal';

	this.identificadores = ['ID'];

	this.TipoMembresia = {
		ESTANDAR: "ESTANDAR",
		PREMIUM: "PREMIUM"
	}

	this.ctrlActions = new ControlActions();

	this.RetrieveMembership = function () {
		var user = this.ctrlActions.GetLoggedUser();
		let membresia = new vMembresia();

		//Se hace la consulta  para obtener el valor de la membresia estandar de la base de datos
		this.ctrlActions.GetToApiId(this.service, this.getCurrentStandardMembershipAction, user, function (membresiaData) {

			membresia.ConfigurarInformacionModal(membresiaData, membresia.btnMostrarModalMembresiaEstandar, membresia.membresiaEstandarModalId, membresia.membresiaEstandarAmpliarModalId);

			membresia.ConfigurarBotonPago(membresiaData, membresia.TipoMembresia.ESTANDAR);
		});

		//Se hace la consulta para obtener los valores de la base de datos de la membresia premium
		this.ctrlActions.GetToApiId(this.service, this.getCurrentPremiumMembershipAction, user, function (membresiaData) {
			
			membresia.ConfigurarInformacionModal(membresiaData, membresia.btnMostrarModalMembresiaPremium, membresia.membresiaPremiumModalId, membresia.membresiaPremiumAmpliarModalId);

			membresia.ConfigurarBotonPago(membresiaData, membresia.TipoMembresia.PREMIUM);
		});
	}

	this.Create = function () {
		var membresiaData = {};
		if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
			membresiaData = this.ctrlActions.GetDataForm(this.createFormId);
			//Hace el post al create
			this.ctrlActions.PostToAPI(this.service, membresiaData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var membresia = new vMembresia();

				$('#' + membresia.createModalId).modal('hide');
				membresia.CleanInsert();
				ctrl.FillTable(membresia.service, membresia.tblMembresiaId, true);

			});
		}
	}

	this.UpdateEstandar = function () {

		var membresiaData = {};

		membresiaData = { ID_Representante: this.ctrlActions.GetLoggedUser().IdentificacionUsuario }
		var service = `${this.service}/${this.updateStatusAction}`;
		//Hace el post al create
		this.ctrlActions.PutToAPI(service, membresiaData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var membresia = new vMembresia();

			$('#' + membresia.membresiaEstandarModalId).modal('hide');
			$('#' + membresia.membresiaEstandarAmpliarModalId).modal('hide');
		});

	}

	this.UpdatePremium= function () {

		var membresiaData = {};

		membresiaData = { ID_Representante: this.ctrlActions.GetLoggedUser().IdentificacionUsuario }
		var service = `${this.service}/${this.UpdatePremiumAction}`;
		//Hace el post al create
		this.ctrlActions.PutToAPI(service, membresiaData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var membresia = new vMembresia();

			$('#' + membresia.membresiaPremiumModalId).modal('hide');
			$('#' + membresia.membresiaPremiumAmpliarModalId).modal('hide');
		});

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields(this.editModalId, data);
		this.ctrlActions.BindFields(this.deleteModalId, data);
		this.ctrlActions.BindFields(this.statusModalId, data);
	}

	this.ConfigurarInformacionModal = function (membresiaData, botonCompra, modalAdquirir, modalAmpliar) {

		let membresia = new vMembresia();
			/*Si la membresia está vigente (no ha expirado a fecha de hoy) se muestra el modal de Ampliar membresia
			Si aun está vigente se muestra de forma predeterminada el Modal de Adquirir Membresia
			Este valor predeterminado se agrega desde el HTML con el data-target del boton utilizado para abrir el modal*/
			if (membresia.MembresiaVigente(membresiaData)) {

				$('#' + botonCompra).attr('data-target', '#' + modalAmpliar);
			}

			if (Boolean(membresiaData.Moneda) && Boolean(membresiaData.CostoTotal)) {

				//Agregamos los valores de la membresia a los diferentes modales mostrados en la vista
				membresia.ctrlActions.BindFields(modalAdquirir, membresiaData);
				membresia.ctrlActions.BindFields(modalAmpliar, membresiaData);
			}
	}

	this.ConfigurarBotonPago = function (membresiaData, tipoMembresia) {

		if (Boolean(membresiaData.CostoTotal)) {

			var costo = membresiaData.CostoTotal;

			var paypalService = new PayPalService();
			var membresia = new vMembresia();

			if (tipoMembresia === membresia.TipoMembresia.ESTANDAR)
				paypalService.pagoMembresiaEstandar(membresia, costo);
			else
				paypalService.pagoMembresiaPremium(membresia, costo);
		}

	}

	this.MembresiaVigente = function (data) {
		if (Boolean(data.Fecha)) {
			return new Date(data.Fecha).valueOf() > new Date().valueOf();
		}
		return false;
	}
}
//ON DOCUMENT READY
$(document).ready(function () {

	var membresia = new vMembresia();
	membresia.RetrieveMembership();

});

