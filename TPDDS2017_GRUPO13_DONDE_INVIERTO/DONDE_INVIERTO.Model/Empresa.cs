using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.Model
{
    public class Empresa
    {
        public Empresa()
        {
            this.Balances = new List<Balance>();
        }
        public string Nombre { get; set; }
        public string CUIT { get; set; }
        public virtual List<Balance> Balances { get; set; }
        public DateTime FechaFundacion { get; set; }

        public void Editar(Empresa empresaEditada)
        {
            this.Nombre = empresaEditada.Nombre;
            this.FechaFundacion = empresaEditada.FechaFundacion;
        }
    }
}