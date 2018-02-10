using System.Collections.Generic;

namespace DONDE_INVIERTO.Model.Views
{
    public class BalanceView
    {
        public List<ComponenteOperando> Componentes { get; set; }
        public int Id { get; set; }
        public int Periodo { get; set; }
        public decimal Valor { get; set; }
        public int EmpresaId { get; set; }

        public BalanceView(Balance balance, List<ComponenteOperando> componentes)
        {
            EmpresaId = balance.EmpresaId;
            Id = balance.Id;
            Periodo = balance.Periodo;
            Valor = balance.Valor;
            Componentes = componentes;
        }
    }
}
