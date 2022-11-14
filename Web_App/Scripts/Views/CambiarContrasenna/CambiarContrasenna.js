function Cambiar() {

    this.service = 'Usuario';
    this.createFormId = "change-pass-form";
    this.ctrlActions = new ControlActions();

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
                $("#change-pass").modal("hide");
                this.ctrlActions.PostToAPI("Contrasenna", contrasenna, "",
                    function (response) {
                    });
            } else {
                contrasenna.addClass("red-border");
                repetirContrasenna.addClass("red-border");
            }
        }
    }
}
