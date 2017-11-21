using ANTLR;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DONDE_INVIERTO.Service
{
    public class IndicadorService
    {
        public void Save(string name, string content)
        {
            /*
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
            */
            var indicador = new Indicador { Nombre = name, Contenido = content };

            StorageProvider<Indicador>.Save(indicador);
        }

        public static double GetValor(Empresa empresa, Indicador indicador, Periodo periodoInicio, Periodo periodoFin)
        {
            List<double> valores = new List<double>();

            for(int i = periodoInicio.Anio.Year; i < periodoFin.Anio.Year; i++)
            {
                valores.Add(IndicadorService.Calcular(indicador,i));
            }
            return valores.Aggregate((double v1, double v2) => { return v1 + v2; }); //Suma todos los valores
        }

        private static double Calcular(Indicador indicador, int i)
        {
            
            var lexer = new GramaticaLexer(new AntlrInputStream(indicador.Contenido));
            var tokens = new CommonTokenStream(lexer);
            var parser = new GramaticaParser(tokens);
            parser.BuildParseTree = true;
            var indicadorContext = parser.indicador();
            var walker = new ParseTreeWalker();
            var listener = new Listener(indicador.Nombre);
            walker.Walk(listener, indicadorContext);
            indicador.BinaryTree = listener.Indicador.BinaryTree;
            //ANTLR.Clases2.Indicador.Indicadores.Add(listener.Indicador);


            
        }

        public IList<Indicador> List()
        {
            return StorageProvider<Indicador>.ReadAll();
        }
    }
}
