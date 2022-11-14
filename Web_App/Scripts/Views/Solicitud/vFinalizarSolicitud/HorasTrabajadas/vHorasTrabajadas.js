function vHorasTrabajadas() {

    //InformacionTrabajadores
    this.serviceTrabajadorSolicitud = "TrabajadorSolicitud";
    this.actionInformacionTrabajadores = "InformacionTrabajadores";
    this.actionUpdateHorasTrabajadas = "IngresarHorasTrabajadas";
    this.actionFijarPrecioFinal = "FijarPrecioFinal";

    this.ctrlActions = new ControlActions();
    this.divOferta = "main";

    this.RetrieveData = function () {
        var params = { ID_Solicitud: this.ctrlActions.GetSolicitud(), ID_Empresa: this.getIdEmpresa() };

        this.ctrlActions.GetToApiId(this.serviceTrabajadorSolicitud, this.actionInformacionTrabajadores, params, function (data) {
            var horasTrabajadas = new vHorasTrabajadas();
            horasTrabajadas.construirListaTrabajadores(data);
        });
    }

    this.CalculateTotal = function () {
        this.ctrlActions.ExecutePerFormData('listaTrabajadores', function ({ value, dataset }) {

            var horasTrabajadas = new vHorasTrabajadas();

            var data = {
                IdSolicitud: horasTrabajadas.ctrlActions.GetSolicitud(),
                IdTrabajador: dataset.idTrabajador,
                HorasTrabajadas: value
            };
            var service = `${horasTrabajadas.serviceTrabajadorSolicitud}/${horasTrabajadas.actionUpdateHorasTrabajadas}`;

            horasTrabajadas.ctrlActions.PutToAPI(service, data, "IdSolicitud", function () {

                var dataPrecioFinal = {
                    IdSolicitud: horasTrabajadas.ctrlActions.GetSolicitud(),
                    IdEmpresa: horasTrabajadas.getIdEmpresa()
                }
                var servicePrecioFinal = `${horasTrabajadas.serviceTrabajadorSolicitud}/${horasTrabajadas.actionFijarPrecioFinal}`;

                horasTrabajadas.ctrlActions.PutToAPI(servicePrecioFinal, dataPrecioFinal, "IdSolicitud", function () {
                    console.log('updated');
                    window.location.href = '/Solicitud/vPagoSolicitud'
                });

            });

        });
    }

    this.getIdEmpresa = function () {
        var solicitudData = sessionStorage.getItem('tblSolicitudesActivas' + '_selected');
        if (Boolean(solicitudData)) {
            var idEmpresa = JSON.parse(solicitudData).CedulaEmpresa;
            return idEmpresa;
        }
    }

    this.construirListaTrabajadores = function (data) {

        //Contenedor para la lista de trabajadores
        const trabajadoresContainer = document.querySelector('#listaTrabajadores');

        if (Boolean(data)) {
            
            data.forEach(function ({ IdTrabajador, NombreUsuario, PrimerApellidoUsuario, SegundoApellidoUsuario }, index) {
                const txtID = 'txtTrabajador' + (index + 1);
                const columnDataNameTrabajador = 'NombreUsuario';
                //Label trabajador
                let pNombreTrabajador = document.createElement('label');
                pNombreTrabajador.setAttribute('for', txtID);
                pNombreTrabajador.innerHTML = `${NombreUsuario} ${PrimerApellidoUsuario} ${SegundoApellidoUsuario}`;

                let contenedorNombreTrabajador = document.createElement('div');
                contenedorNombreTrabajador.classList.add('md-form', 'form-group');
                contenedorNombreTrabajador.appendChild(pNombreTrabajador);

                let contenedorColumna = document.createElement('div');
                contenedorColumna.classList.add('col-sm-12', 'col-lg-4');
                contenedorColumna.appendChild(contenedorNombreTrabajador);

                //Input trabajador
                let inputHoras = document.createElement('input');
                inputHoras.setAttribute('type', 'number');
                inputHoras.setAttribute('min', 1);
                inputHoras.setAttribute('id', txtID);
                inputHoras.classList.add('form-control');
                inputHoras.setAttribute('ColumnDataName', columnDataNameTrabajador);
                inputHoras.dataset.idTrabajador = IdTrabajador;


                let contenedorInput = document.createElement('div');
                contenedorInput.classList.add('md-form', 'form-group');
                contenedorInput.appendChild(inputHoras);

                let contenedorColumnaInput = document.createElement('div');
                contenedorColumnaInput.classList.add('col-sm-12', 'col-lg-8');
                contenedorColumnaInput.appendChild(contenedorInput);

                //Row para los textos
                let row = document.createElement('div');
                row.classList.add('row');

                row.appendChild(contenedorColumna);
                row.appendChild(contenedorColumnaInput);

                trabajadoresContainer.appendChild(row);
            });
        }
    }
}

$(document).ready(function () {

    var horasTrabajadas = new vHorasTrabajadas();

    horasTrabajadas.RetrieveData();

    $('#btnContinuar').on('click', function () {
        horasTrabajadas.CalculateTotal();
    });
});

