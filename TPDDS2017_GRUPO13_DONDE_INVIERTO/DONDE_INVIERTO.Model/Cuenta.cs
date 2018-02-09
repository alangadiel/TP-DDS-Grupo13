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
    }
}