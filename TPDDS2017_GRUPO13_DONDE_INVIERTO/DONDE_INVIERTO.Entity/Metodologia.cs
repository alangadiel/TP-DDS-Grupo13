namespace DONDE_INVIERTO.Entity
{
    public class Metodologia : Entity<Model.Metodologia>
    {
        private static volatile Metodologia instance;
        private static object syncRoot = new object();

        private Metodologia()
        {
            base.Initialize();
        }

        public static Metodologia Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Metodologia();
                    }
                }
                return instance;
            }
        }
    }
}