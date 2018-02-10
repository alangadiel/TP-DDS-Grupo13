using System.Collections.Generic;
using System.Linq;
using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;

namespace DONDE_INVIERTO.Service
{
    public class CuentaService
    {

        public ComponenteOperando Cuenta { get; set; }

        public double ObtenerValor(EmpresaView empresa, int periodo, List<ComponenteOperando> listaOperandos)
        {
            var balances = empresa.Balances;
            var balanceBuscado = balances.FirstOrDefault(x => x.Periodo == periodo);
            var componentes = Context.Session.Query<ComponenteOperando>().Where(comp => comp.BalanceId == balanceBuscado.Id).ToList();
            var cuentaBuscada = componentes.FirstOrDefault(x => x.Nombre.ToLower() == Cuenta.Nombre.ToLower());
            return cuentaBuscada != null ? (double) cuentaBuscada.Valor.Value : 0;
        }
    }
}
