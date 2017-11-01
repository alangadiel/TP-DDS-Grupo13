using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;

namespace DONDE_INVIERTO.Service
{
    public class PeriodoService
    {
        public void Save(Periodo periodo)
        {
            StorageProvider<Periodo>.Save(periodo);
        }
    }
}
