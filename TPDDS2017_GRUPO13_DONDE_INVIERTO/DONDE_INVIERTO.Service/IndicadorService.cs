using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using DONDE_INVIERTO.ANTLR;
using DONDE_INVIERTO.ANTLR.Gramatica;
using DONDE_INVIERTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DONDE_INVIERTO.Service
{
    public class IndicadorService
    {
        const string pattern = @"((\b([A-z]*[0-9]*|[0-9]*[A-z]*)[a-z0-9]*\b)([+\-\*\/]\(?(\b([a-z]*[0-9]*|[0-9]*[a-z]*)[a-z0-9]*\b)\)?)+)";

        public Indicador Indicador { get; set; }
        public double ObtenerValor(Empresa empresa, int periodo, List<ComponenteOperando> listaOperandos)
        {
            AntlrInputStream input = new AntlrInputStream(Indicador.Formula);
            gramaticaLexer lexer = new gramaticaLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            gramaticaParser parser = new gramaticaParser(tokens);
            IParseTree tree = parser.expr();
            VisitorCore visitor = new VisitorCore(empresa, periodo, listaOperandos);
            return Math.Round(visitor.Visit(tree), 2);
        }
    }
}
