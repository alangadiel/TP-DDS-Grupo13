using ANTLR;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
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
        public void Save(string name, string content)
        {
            GramaticaLexer lexer = new GramaticaLexer(new AntlrInputStream(content));
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GramaticaParser parser = new GramaticaParser(tokens);
            parser.BuildParseTree = true;
            GramaticaParser.IndicadorContext indicadorContext = parser.indicador();
            ParseTreeWalker walker = new ParseTreeWalker();
            Listener listener = new Listener(name);
            walker.Walk(listener, indicadorContext);

            var model = new Indicador();
            model.BinaryTree = listener.Indicador.BinaryTree;
            model.Nombre = listener.Indicador.Nombre;
            model.Contenido = content;

            ANTLR.Clases2.Indicador.Indicadores.Add(listener.Indicador);

            Entity.Indicador.Instance.Save(model);
        }

        public IEnumerable<Indicador> List()
        {
            return Entity.Indicador.Instance.GetAll();
        }


    }
}
