using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using DONDE_INVIERTO.ANTLR;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System;
using System.Collections.Generic;

namespace DONDE_INVIERTO.Service
{
    public class IndicadorService 
    {
        public ComponenteOperando Indicador { get; set; }
        public double ObtenerValor(EmpresaView empresa, int periodo, List<ComponenteOperando> listaOperandos)
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
