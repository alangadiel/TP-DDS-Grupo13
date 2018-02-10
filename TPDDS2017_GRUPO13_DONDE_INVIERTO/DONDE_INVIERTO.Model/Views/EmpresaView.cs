using System;
using System.Collections.Generic;

namespace DONDE_INVIERTO.Model.Views
{
    public class EmpresaView
    {
        public EmpresaView()
        {
            Balances = new List<Balance>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime? FechaFundacion { get; set; }

        public List<Balance> Balances { get; set; }

    }
}
