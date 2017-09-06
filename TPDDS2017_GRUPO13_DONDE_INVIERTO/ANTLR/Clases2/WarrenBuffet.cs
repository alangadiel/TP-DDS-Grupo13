using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases2
{
    class WarrenBuffet
    {
        public Metodologia Maximizar_ROE { get; set; }
        public Metodologia Minimizar_Deuda { get; set; }
        public Metodologia Márgenes_Crecientes  { get; set; }
        public Metodologia Longevidad { get; set; }
        
        public WarrenBuffet()
        {
            Indicador ROE = new Indicador("ROE");

            Indicador PD = new Indicador("PD"); // proporción de deuda 

            Indicador Margen_Anterior = new Indicador("MA");

            Indicador Margen_Siguiente = new Indicador("MS");

            Indicador Edad = new Indicador("E");

            Indicador Diez = new Indicador("10");
            Diez.BinaryTree.Root.Value = new Numero(10);

            this.Maximizar_ROE = new Metodologia(">", ROE, ROE);
            this.Minimizar_Deuda = new Metodologia("<", PD, PD);
            this.Márgenes_Crecientes = new Metodologia("<", Margen_Anterior, Margen_Siguiente);
            this.Longevidad = new Metodologia("<", Edad, Diez, ">", Edad, Edad);
        }
    }
}
