using ANTLR;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;
using System.Collections.Generic;

namespace DONDE_INVIERTO.Service
{
    public class IndicadorService
    {
        public void Save(string name, string content)
        {
            var lexer = new GramaticaLexer(new AntlrInputStream(content));
            var tokens = new CommonTokenStream(lexer);
            var parser = new GramaticaParser(tokens);
            parser.BuildParseTree = true;
            var indicadorContext = parser.indicador();
            var walker = new ParseTreeWalker();
            var listener = new Listener(name);
            walker.Walk(listener, indicadorContext);

            var model = new Indicador();
            model.BinaryTree = listener.Indicador.BinaryTree;
            model.Nombre = listener.Indicador.Nombre;
            model.Contenido = content;

            ANTLR.Clases2.Indicador.Indicadores.Add(listener.Indicador);

            StorageProvider<Indicador>.Save(model);
        }

        public IList<Indicador> List()
        {
            return StorageProvider<Indicador>.ReadAll();
        }


    }
}
