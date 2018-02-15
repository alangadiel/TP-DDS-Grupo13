using System.Collections.Generic;

namespace DONDE_INVIERTO.Model.Views
{
    public class BalanceView
    {
        public List<ComponenteOperando> Cuentas { get; set; }
        public int Id { get; set; }
        public int Periodo { get; set; }
        public decimal? Valor { get; set; }
        public Empresa Empresa { get; set; }

        public BalanceView()
        {
            Empresa = new Empresa();
            Cuentas = new List<ComponenteOperando>();
        }

        public BalanceView(Balance balance, List<ComponenteOperando> cuentas, Empresa empresa)
        {
            Empresa = empresa;
            Id = balance.Id;
            Periodo = balance.Periodo;
            Valor = balance.Valor;
            Cuentas = cuentas;
        }
    }
}
