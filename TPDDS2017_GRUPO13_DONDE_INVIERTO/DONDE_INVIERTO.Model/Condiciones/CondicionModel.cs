using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.Model.Condiciones
{
    public class CondicionModel
    {
        public TipoCondicion Tipo { get; set; }
        public int? Indicador_Id { get; set; }
        public string Descripcion { get; set; }
    }
}