using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using DONDE_INVIERTO.ANTLR;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System;
using System.Collections.Generic;
using DONDE_INVIERTO.DataStorage;
using System.Linq;

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


        public List<ComponenteOperando> List()
        {
            return Context.Session.Query<ComponenteOperando>().OrderBy(ind => ind.Nombre).ToList();
        }

        public void Save(ComponenteOperando indicador)
        {
            indicador.Discriminador = "Indicador";
            Context.Save(indicador);
        }

        public void Delete(int id)
        {
            var indicador = Get(id);
            Context.Delete(indicador);
        }

        public ComponenteOperando Get(int id)
        {
            return Context.Session.Query<ComponenteOperando>().
                Where(ind => ind.Id == id).First();
        }
    }
}
