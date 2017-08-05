namespace DONDE_INVIERTO.Entity
{
    public class Indicador : Entity<Model.Indicador>
    {
        private static volatile Indicador instance;
        private static object syncRoot = new object();

        private Indicador()
        {
            base.Initialize();
        }

        public static Indicador Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Indicador();
                    }
                }
                return instance;
            }
        }
    }
}
