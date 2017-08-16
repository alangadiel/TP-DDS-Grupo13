using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DONDE_INVIERTO.Entity
{
    public class Periodo : Entity<Model.Periodo>
    {
        private static volatile Periodo instance;
        private static object syncRoot = new object();

        private Periodo()
        {
            base.Initialize();
        }

        public static Periodo Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Periodo();
                    }
                }
                return instance;
            }
        }

    }
}
