using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.Model
{
    public class Cuenta : ComponenteOperando
    {

        public int Balance_Id { get; set; }
        public double Valor { get; set; }

        public override double ObtenerValor(Empresa empresa, int periodo, List<ComponenteOperando> listaOperandos)
        {
            List<Balance> balances = empresa.Balances;
            Balance balanceBuscado = balances.FirstOrDefault(x => x.Periodo == periodo);
            Cuenta cuentaBuscada = balanceBuscado.Cuentas.FirstOrDefault(x => x.Nombre.ToLower() == this.Nombre.ToLower());
            return cuentaBuscada != null ? cuentaBuscada.Valor : 0;
        }
    }
}