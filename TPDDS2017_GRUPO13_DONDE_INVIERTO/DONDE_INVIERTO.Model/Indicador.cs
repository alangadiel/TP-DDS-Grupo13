using ANTLR.Clases2;
using System.ComponentModel.DataAnnotations;
using System;
using ANTLR;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace DONDE_INVIERTO.Model
{
    public class Indicador : Model
    {
        [Required]
        public virtual string Nombre { get; set; }

        public virtual BinaryTree<IContenidoNodo> BinaryTree { get; set; }

        [Required]
        public virtual string Contenido { get; set; }

        public virtual Usuario Usuario { get; set; }

        public double Calcular(int anio)
        {
            
            var lexer = new GramaticaLexer(new AntlrInputStream(this.Contenido));
            var tokens = new CommonTokenStream(lexer);
            var parser = new GramaticaParser(tokens);
            parser.BuildParseTree = true;
            var indicadorContext = parser.indicador();
            var walker = new ParseTreeWalker();
            var listener = new Listener(this.Nombre);
            walker.Walk(listener, indicadorContext);

            model.BinaryTree = listener.Indicador.BinaryTree;


            ANTLR.Clases2.Indicador.Indicadores.Add(listener.Indicador);
            




        }
    }
}
