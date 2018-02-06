using Antlr4.Runtime;
using DONDE_INVIERTO.ANTLR.Gramatica;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System;
using System.Collections.Generic;

namespace DONDE_INVIERTO.ANTLR
{
    public class IndicadorCore
    {
        protected readonly Indicador _indicador;

        public IndicadorCore(Indicador indicador)
        {
            _indicador = indicador;
        }

        public double ObtenerValor(EmpresaView empresa, int periodo, List<Indicador> indicadores)
        {
            var input = new AntlrInputStream(_indicador.Formula);
            var lexer = new gramaticaLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new gramaticaParser(tokens);
            var visitor = new VisitorCore(empresa, periodo, indicadores);
            return Math.Round(visitor.Visit(parser.expr()), 2);
        }
    }
}
