using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.Model.Condiciones
{
    public class CondicionesFactory
    {
        public static Condicion CreateCondicion(CondicionModel model)
        {
            Condicion condi;
            switch (model.Tipo)
            {
                case TipoCondicion.Creciente:
                    condi = new MargenesCreciente();
                break;
                case TipoCondicion.MayorAUno:
                    condi = new MayorAUno();
                break;
                case TipoCondicion.Longevidad:
                    condi = new Longevidad();
                break;
                default:
                    condi = new MayorAUno();
                break;
            }
            condi.Tipo = model.Tipo;
            condi.Indicador_Id = model.Indicador_Id;
            condi.Descripcion = model.Descripcion;
            return condi;
        }
    }
}