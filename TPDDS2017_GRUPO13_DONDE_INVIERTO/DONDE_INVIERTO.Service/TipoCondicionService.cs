using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;
using System.Collections.Generic;
using System.Linq;

namespace DONDE_INVIERTO.Service
{
    public class TipoCondicionService
    {
        private static List<TipoCondicion> condiciones = Context.ReadAll<TipoCondicion>().ToList();
        public static List<TipoCondicion> GetAll()
        {
            return condiciones;
        }
    }
}
