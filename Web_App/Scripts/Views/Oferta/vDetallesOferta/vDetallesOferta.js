function vDetallesOferta() {

    this.service = 'Oferta';
    this.serviceSolicitud = "Solicitud";

    this.actionRetrieveOferta = "ObtenerConEmpresa";
    this.actionAceptarOferta = "AceptarOferta";
    this.actionRechazarOferta = "UpdateStatus";

    //InformacionTrabajadores
    this.serviceTrabajadorSolicitud = "TrabajadorSolicitud";
    this.actionInformacionTrabajadores = "InformacionTrabajadores";

    this.ctrlActions = new ControlActions();
    this.divOferta = "main";

    this.RetrieveData = function () {
        var params = { ID_Solicitud: this.ctrlActions.GetSolicitud(), ID_Empresa: this.getIdEmpresa() };
        this.ctrlActions.GetToApiId(this.service, this.actionRetrieveOferta, params, function (data) {
            var detallesOferta = new vDetallesOferta();

            var monedaUsuario = detallesOferta.ctrlActions.GetLoggedInforUser().Moneda;
            data = detallesOferta.formatData(data, monedaUsuario);

            detallesOferta.ctrlActions.BindFieldsContainer(detallesOferta.divOferta, data);

            detallesOferta.ctrlActions.GetToApiId(detallesOferta.serviceTrabajadorSolicitud, detallesOferta.actionInformacionTrabajadores, params, function (data) {
                detallesOferta.construirListaTrabajadores(data);
            });
        });
    }

    this.AceptarOferta = function () {
        var data = { ID: this.ctrlActions.GetSolicitud(), ID_Empresa: this.getIdEmpresa() };

        this.ctrlActions.PutToAPI(this.serviceSolicitud + "/" + this.actionAceptarOferta, data, "ID_Empresa", function () {
            $('#modalAceptarOferta').modal('toggle');

        });
    }

    this.RechazarOferta = function () {

        var params = { IdSolicitud: this.ctrlActions.GetSolicitud(), IdEmpresa: this.getIdEmpresa() };
        var serviceURL = `${this.service}/${this.actionRechazarOferta}`;

        this.ctrlActions.PutToAPI(serviceURL, params, "IdSolicitud", function () {

            window.location.href = '/Oferta/vVisualizarOfertas';

        });
    }

    this.getIdEmpresa = function () {
        var ofertaData = sessionStorage.getItem('tblOfertas' + '_selected');
        if (Boolean(ofertaData)) {
            var idEmpresa = JSON.parse(ofertaData).IdEmpresa;
            return idEmpresa;
        }
    }

    this.formatData = function (data, monedaUsuario) {

        if (Boolean(data.CancelacionCliente))
            data.CancelacionCliente = monedaUsuario + " " + data.CancelacionCliente.toLocaleString("en", {
                minimumFractionDigits: 0,
                maximumFractionDigits: 0
            });


        if (Boolean(data.PrecioCliente))
            data.PrecioCliente = monedaUsuario + " " + data.PrecioCliente.toLocaleString("en", {
                minimumFractionDigits: 0,
                maximumFractionDigits: 0
            });
        else
            data.PrecioCliente = "N/A";

        return data;
    }

    this.construirListaTrabajadores = function (data) {

        //Contenedor para la lista de trabajadores
        const trabajadoresContainer = document.querySelector('#listaTrabajadores');
        const monedaUsuario = this.ctrlActions.GetLoggedInforUser().Moneda;
        if (Boolean(data)) {
            data.forEach(function ({ NombreUsuario, PrimerApellidoUsuario, SegundoApellidoUsuario, PrecioMonedaUsuario }, index) {

                //Nombre trabajador
                let pNombreTrabajador = document.createElement('p');
                pNombreTrabajador.innerHTML = `${NombreUsuario} ${PrimerApellidoUsuario} ${SegundoApellidoUsuario}`;
                pNombreTrabajador.classList.add('h6');

                let contenedorNombreTrabajador = document.createElement('div');
                contenedorNombreTrabajador.classList.add('col-sm-12', 'col-lg-6');
                contenedorNombreTrabajador.appendChild(pNombreTrabajador);

                //Precio por hora
                let pPrecioPorHora = document.createElement('p');
                pPrecioPorHora.innerHTML = `${monedaUsuario} ${PrecioMonedaUsuario.toLocaleString()}`;

                let contendorPrecioPorHora = document.createElement('div');
                contendorPrecioPorHora.classList.add('col-sm-12', 'col-lg-6');
                contendorPrecioPorHora.appendChild(pPrecioPorHora);

                //Row para los textos
                let row = document.createElement('div');
                row.classList.add('row');

                row.appendChild(contenedorNombreTrabajador);
                row.appendChild(contendorPrecioPorHora);

                trabajadoresContainer.appendChild(row);
            });
        }
    }
}

$(document).ready(function () {

    var detallesOferta = new vDetallesOferta();

    detallesOferta.RetrieveData();

    $('#btnAceptarOferta').on('click', function () {
        detallesOferta.AceptarOferta();
    });

    $('#btnRechazarOferta').on('click', function () {
        $('#modalRechazarSolicitud').modal('toggle');
    });

    $('#btnEjecutarRechazo').on('click', function () {
        $('#modalRechazarSolicitud').modal('toggle');
        detallesOferta.RechazarOferta();
    });


});

