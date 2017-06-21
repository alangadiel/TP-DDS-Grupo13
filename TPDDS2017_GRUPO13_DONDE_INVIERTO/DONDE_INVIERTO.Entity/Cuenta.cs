using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DONDE_INVIERTO.Entity
{
    public class Cuenta : Entity<Model.Cuenta>
    {
        private static volatile Cuenta instance;
        private static object syncRoot = new object();

        private Cuenta()
        {
            base.Initialize();
        }

        public static Cuenta Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Cuenta();
                    }
                }
                return instance;
            }
        }
    }
}
