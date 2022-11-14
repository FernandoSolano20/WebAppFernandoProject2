
function vDashboardAdministrador() {


	this.service = 'Reportes';
	this.ingresosDiariosAction = 'IngresosDiarios';
	this.ingresosMensualesAction = 'IngresosMensualesPlataforma';

	this.cardIngresosDiarios = "cardIngresosDiarios"
	this.spanValorIngresosDiarios = 'spanValorIngresosDiarios';
	this.spanFechaIngresosDiarios = 'spanFechaIngresosDiarios';

	this.coloresFondo = [
		'rgba(255, 99, 132, 0.2)',
		'rgba(54, 162, 235, 0.2)',
		'rgba(255, 206, 86, 0.2)',
		'rgba(75, 192, 192, 0.2)',
		'rgba(153, 102, 255, 0.2)',
		'rgba(255, 159, 64, 0.2)'
	];

	this.coloresBorde = [
		'rgba(255,99,132,1)',
		'rgba(54, 162, 235, 1)',
		'rgba(255, 206, 86, 1)',
		'rgba(75, 192, 192, 1)',
		'rgba(153, 102, 255, 1)',
		'rgba(255, 159, 64, 1)'
	];

	this.ctrlActions = new ControlActions();

	this.RetrieveIngresosDiarios = function () {
		var service = `${this.service}/${this.ingresosDiariosAction}`
		this.ctrlActions.GetToApi(service, function (data) {
			var ctrl = new ControlActions();
			var dashboard = new vDashboardAdministrador();

			if (Boolean(data.Fecha)) {
				data.Fecha = new Date(data.Fecha).toLocaleDateString();
			}
			ctrl.BindFields(dashboard.cardIngresosDiarios, data);
		});
	}

	this.RetrieveIngresosMensuales = function () {
		var periodo = { PeriodoMeses: 5 };
		this.ctrlActions.GetToApiId(this.service, this.ingresosMensualesAction, periodo, this.generarGraficoMensual);
	}

	this.generarGraficoMensual = function (data) {
		var contenedorGrafico = document.getElementById("reporteIngresosMensualesPlataforma").getContext('2d');
		var dashboard = new vDashboardAdministrador();

		if (Boolean(data.Meses) && Boolean(data.Ingresos)) {
			var myChart = new Chart(contenedorGrafico, {
				type: 'bar',
				data: {
					labels: data.Meses,
					datasets: [{
						label: 'Ingresos USD',
						data: data.Ingresos,
						backgroundColor: dashboard.coloresFondo,
						borderColor: dashboard.coloresBorde,
						borderWidth: 1
					}]
				},
				options: {
					scales: {
						yAxes: [{
							ticks: {
								beginAtZero: true
							}
						}]
					}
				}
			});
		}
		
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var dashboard = new vDashboardAdministrador();
	dashboard.RetrieveIngresosDiarios();
	dashboard.RetrieveIngresosMensuales();

});

