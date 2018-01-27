namespace DONDE_INVIERTO.Model
{
    public class Condicion : Model
    {
        public virtual Indicador Indicador { get; set; }

        public virtual int Antiguedad { get; set; }

        public virtual bool Mayor { get; set; }

        public virtual bool Creciente { get; set; }

        public virtual double Valor { get; set; }

    }
}
