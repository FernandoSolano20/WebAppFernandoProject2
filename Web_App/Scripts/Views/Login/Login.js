function Login() {

    this.service = 'Usuario';
    this.createFormId = "change-pass-form";
    this.ctrlActions = new ControlActions();

    this.Login = function () {
        var email = document.getElementById("email").value;
        var password = document.getElementById("password").value;
        var ctrlActions = new ControlActions();
        ctrlActions.GetToApi("Usuario/IniciarSesion?email=" + email + "&contrasenna=" + encodeURIComponent(password),
            function(response) {
                sessionStorage.setItem("Id", response[0].Identificacion);
                sessionStorage.setItem("Usuario", JSON.stringify(response[0]));
                var roles = [];
                var ctrlActions = new ControlActions();
                for (var i = 1; i < response.length; i++) {
                    roles.push(response[i].Nombre);
                }
                sessionStorage.setItem("Roles", JSON.stringify(roles));
                if (roles.some(x => x == "Oferente Físico" || x == "Oferente Jurídico")) {
                    ctrlActions.GetToApi("Membresia/GetIsPremium?IdentificacionUsuario=" + response[0].Identificacion,
                        function(response) {
                            sessionStorage.setItem("EsPremium", JSON.stringify(response));
                        });
                }
                if (response[0].Estado == "CAMBCONTRA" || response[0].Estado == "NPCC") {
                    $('#change-pass').modal('toggle');
                }
                else if (response[0].Estado == "NOPAGO") {
                    ctrlActions.GetToServer("Language/CambiarLenguaje?lenguaje=" + response[0].Lenguaje.trim() +
                        "&id=" + response[0].Identificacion +
                        "&idEmpresa=" + response[0].IdEmpresa,
                        function () {
                        redirectNoPago(roles);
                    });
                } else {
                    ctrlActions.GetToServer("Language/CambiarLenguaje?lenguaje=" + response[0].Lenguaje.trim() +
                        "&id=" + response[0].Identificacion +
                        "&idEmpresa=" + response[0].IdEmpresa, function() {
                        redirectToPage(roles);
                    });
                }
            });
    }

    this.CleanUpdate = function () {
        this.ctrlActions.CleanDataForm(this.createFormId);
    }

    this.ChangePass = function () {
        if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
            var contrasenna = $("#contrasenna");
            var repetirContrasenna = $("#repetir-contrasenna");
            if (contrasenna.val() == repetirContrasenna.val()) {
                contrasenna.removeClass("red-border");
                repetirContrasenna.removeClass("red-border");
                var contrasenna = {};
                contrasenna = this.ctrlActions.GetDataForm(this.createFormId);
                contrasenna.IdUsuario = sessionStorage.getItem("Id");

                this.ctrlActions.PostToAPI("Contrasenna", contrasenna, "",
                    function (response) {
                        if (response.Data.Estado === "NOPAGO") {
                            var ctrlActions = new ControlActions();
                            redirectNoPago(ctrlActions.GetRolesLoggedUser());
                        } else {
                            var ctrlActions = new ControlActions();
                            ctrlActions.GetToServer("Language/CambiarLenguaje?lenguaje=" + response.Data.Lenguaje.trim() +
                                "&id=" + response.Data.Identificacion +
                                "&idEmpresa=" + response.Data.IdEmpresa,
                                function () {
                                    redirectToPage(ctrlActions.GetRolesLoggedUser());
                                });
                        }
                    });
            } else {
                contrasenna.addClass("red-border");
                repetirContrasenna.addClass("red-border");
            }
        }
    }

    this.ForgetPass = function () {
        var email = document.getElementById("email-forgot").value;
        var usuario = {};
        usuario.email = email;
        $('#forgot-pass').modal('hide');
        this.ctrlActions.PostToAPI("Usuario/RecuperarClave", usuario, "",
            function (response) {
                $('#forgot-pass').modal('hide');
            });
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var login = new Login();
    document.getElementById("login").addEventListener("click", login.Login);

    var searchParams = new URLSearchParams(window.location.search);
    if (searchParams.has('email')) {
        $("[for='email']").addClass("active");
        document.querySelector("#email").value = searchParams.get('email');
    }
});

function redirectNoPago(tipoUsuario) {
    if (tipoUsuario.some(x => x === "Oferente Físico")) {
        window.location.href = "/Membresia/vMembresiaFisico";
    }
    else {
        window.location.href = "/Membresia/vMembresiaJuridico";
    }
}

function redirectToPage(tipoUsuario) {
    if (tipoUsuario.some(x => x === "Administrador")) {
        window.location.href = "/Administrador/vdashboardadministrador";
    }
    else if (tipoUsuario.some(x => x === "Oferente Físico")) {
        window.location.href = "/OferenteFisico/vDashboardOferenteFisico";
    }
    else if (tipoUsuario.some(x => x === "Oferente Jurídico")) {
        window.location.href = "/OferenteJuridico/vDashboardOferenteJuridico";
    }
    else if (tipoUsuario.some(x => x === "Cliente")) {
        window.location.href = "/Cliente/Dashboard";
    }
}

