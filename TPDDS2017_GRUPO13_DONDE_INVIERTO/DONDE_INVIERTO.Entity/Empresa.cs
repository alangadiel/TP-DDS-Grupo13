using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DONDE_INVIERTO.Model;

namespace DONDE_INVIERTO.Entity
{
    public class Empresa : Entity<Model.Empresa>
    {
        private static volatile Empresa instance;
        private static object syncRoot = new object();

        private Empresa()
        {
            base.Initialize();
            base.Save(new Model.Empresa { Nombre = "PRUEBA 1" });
            base.Save(new Model.Empresa { Nombre = "PRUEBA 2" });
        }

        public static Empresa Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Empresa();
                    }
                }
                return instance;
            }
        }



    }
}
