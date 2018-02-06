using ANTLR.Condiciones;
using DONDE_INVIERTO.Model;
using System.Collections.Generic;

namespace DONDE_INVIERTO.ANTLR
{
    public class CondicionesFactory
    {
        private static List<ITipoCondicion> tiposCondicion =
            new List<ITipoCondicion>();
        public static CondicionView CreateCondicion(Condicion condicion, TipoCondicion tipoCondicion)
        {
            var type = tiposCondicion.Find(tcond => tcond.Tipo.Equals(tipoCondicion));
            return new CondicionView()
            {
                Condicion = condicion,
                TipoCondicion = type
            };
        }
    }
}