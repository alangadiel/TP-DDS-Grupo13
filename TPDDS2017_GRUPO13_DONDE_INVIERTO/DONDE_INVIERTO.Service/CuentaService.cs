using DONDE_INVIERTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DONDE_INVIERTO.Service
{
    public class CuentaService
    {
        public int Save(Cuenta cuenta)
        {
           return Entity.Cuenta.Instance.Save(cuenta);
        }

    }
}
