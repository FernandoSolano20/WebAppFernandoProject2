var logout = document.getElementById("cerrar-sesion");
if (sessionStorage.getItem("Id") == null) {
    window.location.href = "/Home/Login";
} else {
    logout.addEventListener("click",
        function() {
            sessionStorage.clear();
            window.location.href = "/Home/Login";
        });
}