using System.Collections.Generic;
using System.Linq;
using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;

namespace DONDE_INVIERTO.Service
{
    public class CuentaService
    {/*
        public void Save(Cuenta cuenta)
        {
            StorageProvider<Cuenta>.Save(cuenta);
        }*/

        public Cuenta Cuenta { get; set; }

        public double ObtenerValor(Empresa empresa, int periodo, List<ComponenteOperando> listaOperandos)
        {
            List<Balance> balances = empresa.Balances;
            Balance balanceBuscado = balances.FirstOrDefault(x => x.Periodo == periodo);
            Cuenta cuentaBuscada = balanceBuscado.Cuentas.FirstOrDefault(x => x.Nombre.ToLower() == Cuenta.Nombre.ToLower());
            return cuentaBuscada != null ? cuentaBuscada.Valor : 0;
        }
    }
}
