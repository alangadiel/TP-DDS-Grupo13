using System.Collections.Generic;

namespace DONDE_INVIERTO.Model
{
    public class ComponenteOperando
    {
        public int Id { get; set; }
        public int? IndicadorPadre_Id { get; set; }
        public string Nombre { get; set; }
        //public abstract double ObtenerValor(Empresa empresa, int periodo, List<ComponenteOperando> listaOperandos);
        public string Formula { get; set; }
        public decimal? Valor { get; set; }
    }
}