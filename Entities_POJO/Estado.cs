namespace Entities_POJO
{
    public static class Estado
    {
        public const string ACT= "ACT";
        public const string DES= "DES";
        public const string TRABAJADOR = "TRABAJADOR";
        public const string DESYNOPAGO = "DESYNOPAGO";
        public const string NOPAGO = "NOPAGO";
        public const string NOPAGOYCAMBIARCONTRASENNA = "NPCC";
        public const string NOAPROVADO = "NOAPROVADO";
        public const string CAMBIARCONTRASENNA = "CAMBCONTRA";
        public const string ELI= "ELI";
        public const string CRE= "CRE";
        public const string FIN = "FIN";
        public const string BORRADO = "BORRADO";

        //Estados solicitud

        //Pendiente de recibir una oferta de trabajo
        public const string PENDIENTE_ADJUDICAR = "PENDIENTE";
        //Solicitud desactivada por el cliente antes de aceptar una oferta de trabajo
        public const string PENDIENTE_ADJUDICAR_DESACTIVADA = "PEND_DES";
        //Si la solicitud no fue completada por el usuario
        public const string INCOMPLETO = "INCOMP";
        //Si la solicitud esta pendiente de calificar
        public const string PENDIENTE_CALIFICAR = "PENDCALIF";
        //Si la solicitud esta completa
        public const string COMPLETO = "COMPLETO";
        //Estado mientras el usuario acepta la oferta y inicia el trabajo
        public const string POR_INICIAR = "PORINICIAR";

    }
}
