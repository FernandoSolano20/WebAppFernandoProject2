using Entities_POJO;
using System;

namespace CoreAPI.AppCode.Helper
{
    public static class MonedaHelper
    {
        public static decimal ObtenerValorMoneda(string monedaUsuario)
        {
            var monedaManager = new MonedaManager.MonedaManager();
            Moneda monedas = monedaManager.ObtenerMonedaValor();
            return Convert.ToDecimal(monedas.GetType().GetProperty(monedaUsuario).GetValue(monedas, null));
        }
    }
}
