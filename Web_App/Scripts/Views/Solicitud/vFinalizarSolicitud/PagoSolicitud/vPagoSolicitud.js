
function vPagoSolicitud() {

    this.service = 'Solicitud';

    this.retrieveSolicitudId = "SolicitudPrecioCompleto";
    this.actionAccionSolicitud = "vPagoSolicitud";

    //InformacionTrabajadores
    this.serviceTrabajadorSolicitud = "TrabajadorSolicitud";
    this.actionInformacionTrabajadores = "InformacionTrabajadores";
    this.actionFinalizarTrabajo = "FinalizarTrabajo";

    this.ctrlActions = new ControlActions();
    this.divSolicitud = "main";

    this.scanner = new Instascan.Scanner(
        {
            video: document.getElementById('preview')
        }
    );


    this.RetrieveData = function () {
        var params = { ID_Solicitud: this.ctrlActions.GetSolicitud() };
        this.ctrlActions.GetToApiId(this.service, this.retrieveSolicitudId, params, function (data) {
            var pagoSolicitud = new vPagoSolicitud();
            var monedaUsuario = pagoSolicitud.ctrlActions.GetLoggedInforUser().Moneda;
            //Se configura la informacion del API a un formato mas amigable
            pagoSolicitud.ConfigurarBotonPago(data);
            data = pagoSolicitud.formatData(data, monedaUsuario);
            pagoSolicitud.ctrlActions.BindFieldsContainer(pagoSolicitud.divSolicitud, data);
        });
    }

    //Funcion utilizada para activar / finalizar un trabajo
    this.RealizarPago = function () {
        var solicitudData = {};
        solicitudData.ID = this.ctrlActions.GetSolicitud();

        this.ctrlActions.PutToAPI(this.service + "/" + this.actionFinalizarTrabajo, solicitudData, "ID", function () {
            $('#modalRealizarPago').modal('toggle');
            $('#modalSolicitudCompleta').modal('toggle');
        });
    }

    this.validarQR = function (codigoQR) {
        var idSolicitud = this.ctrlActions.GetSolicitud();
        if (Number(idSolicitud) === Number(codigoQR))
            $('#modalRealizarPago').modal('toggle');
        else
            $('#modalErrorCodigo').modal('toggle');
    }

    this.formatData = function (data, monedaUsuario) {

        if (Boolean(data.Impuestos))
            data.Impuestos = monedaUsuario + " " + data.Impuestos.toLocaleString("en", {
                minimumFractionDigits: 0,
                maximumFractionDigits: 0
            });


        if (Boolean(data.CostoTotal))
            data.CostoTotal = monedaUsuario + " " + data.CostoTotal.toLocaleString("en", {
                minimumFractionDigits: 0,
                maximumFractionDigits: 0
            });


        if (Boolean(data.CostoNeto))
            data.CostoNeto = monedaUsuario + " " + data.CostoNeto.toLocaleString("en", {
                minimumFractionDigits: 0,
                maximumFractionDigits: 0
            });

        if (Boolean(data.PrecioFinal))
            data.PrecioFinal = "USD" + " " + data.PrecioFinal.toLocaleString("en", {
                minimumFractionDigits: 0,
                maximumFractionDigits: 0
            });

        return data;
    }

    this.ConfigurarBotonPago = function ({ PrecioFinal }) {

        if (Boolean(PrecioFinal)) {

            var paypalService = new PayPalService();
            var pagoSolicitud = new vPagoSolicitud();

            paypalService.pagoSolicitud(pagoSolicitud, PrecioFinal);
        }

    }

    this.setIdSolicitud = function () {
        var solicitudData = sessionStorage.getItem('tblSolicitudesActivas' + '_selected');
        if (Boolean(solicitudData)) {
            var id = JSON.parse(solicitudData).ID;
            sessionStorage.setItem('idSolicitud', id);
        }
    }

    this.getIdEmpresa = function () {
        var ofertaData = sessionStorage.getItem('tblSolicitudesActivas' + '_selected');
        if (Boolean(ofertaData)) {
            var idEmpresa = JSON.parse(ofertaData).CedulaEmpresa;
            return idEmpresa;
        }
    }

}

$(document).ready(function () {

    var pagoSolicitud = new vPagoSolicitud();

    pagoSolicitud.RetrieveData();

    $('#btnContinuar').on('click', function () {
        window.location.href = '/Solicitud/vAgregarFotografias';
    });

    pagoSolicitud.scanner.addListener('scan', function (content) {
        pagoSolicitud.validarQR(content);
    });

    Instascan.Camera.getCameras().then(cameras => {
        if (cameras.length > 0) {
            pagoSolicitud.scanner.start(cameras[0]);
        } else {
            console.error("No se encontró ninguna cámara");
        }
    });

});

