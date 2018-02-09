using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
//using System.Web.Script.Serialization;

namespace DONDE_INVIERTO.Model
{
    public class Balance
    {
        public Balance()
        {
            Cuentas = new List<Cuenta>();
        }
        public int Id { get; set; }
        public virtual List<Cuenta> Cuentas { get; set; }
        public int Periodo { get; set; }
        //public int Empresa_Id { get; set; }

        public string Empresa_CUIT { get; set; }

        [NotMapped]
        //[ScriptIgnore]
        public  Empresa Empresa { get; set; }

        public double Total {
            get {
                return this.Cuentas.Sum(x => x.Valor);
            }
        }


    }
}