using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DONDE_INVIERTO.Model;

namespace DONDE_INVIERTO.Model.Views
{
    public class CondicionView
    {
        public  string Descripcion { get; set; }

        public TipoCondicion Tipo { get; set; }

        public int Id { get; set; }

        public ComponenteOperando Indicador { get; set; }
      
    }
}
