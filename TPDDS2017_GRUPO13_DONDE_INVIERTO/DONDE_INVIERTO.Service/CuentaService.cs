using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;

namespace DONDE_INVIERTO.Service
{
    public class CuentaService
    {
        public void Save(Cuenta cuenta)
        {
            StorageProvider<Cuenta>.Save(cuenta);
        }

    }
}
