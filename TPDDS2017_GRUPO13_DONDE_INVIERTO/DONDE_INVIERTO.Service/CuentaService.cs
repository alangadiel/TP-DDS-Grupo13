using System.Collections.Generic;
using System.Linq;
using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;

namespace DONDE_INVIERTO.Service
{
    public class CuentaService
    { 
        public double ObtenerValor(ComponenteOperando cuenta, EmpresaView empresa, int periodo, List<ComponenteOperando> listaOperandos)
        {
            var balanceBuscado = empresa.Balances.FirstOrDefault(x => x.Periodo == periodo);

            if (balanceBuscado == null)
                throw new System.Exception("No se encuentra una cuenta en el periodo " + periodo);

            var componentes = listaOperandos.Where(comp => comp.BalanceId!=null && comp.BalanceId == balanceBuscado.Id).ToList();

            var cuentaBuscada = componentes.FirstOrDefault(x => x.Nombre.ToLower() == cuenta.Nombre.ToLower());

            if (cuentaBuscada == null)
                throw new System.Exception("No se encuentra una cuenta con el nombre " + cuenta.Nombre);

            return (double) cuentaBuscada.Valor.Value;
        }
    }
}
