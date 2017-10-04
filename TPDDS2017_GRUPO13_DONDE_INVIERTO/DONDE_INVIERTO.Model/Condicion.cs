namespace DONDE_INVIERTO.Model
{
    public class Condicion : Model
    {
        public virtual Indicador Indicador { get; set; }

        public virtual string Descartar { get; set; }

        public virtual string Ordenar { get; set; }
    }
}
