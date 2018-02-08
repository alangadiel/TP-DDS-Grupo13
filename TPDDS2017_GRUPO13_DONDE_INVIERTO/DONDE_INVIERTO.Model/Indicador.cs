using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using ANTLR;

namespace DONDE_INVIERTO.Model
{
    public class Indicador : ComponenteOperando
    {
        const string pattern = @"((\b([A-z]*[0-9]*|[0-9]*[A-z]*)[a-z0-9]*\b)([+\-\*\/]\(?(\b([a-z]*[0-9]*|[0-9]*[a-z]*)[a-z0-9]*\b)\)?)+)";
        public string Formula { get; set; }
        public string UsuarioCreador_Id { get; set; }
        //public virtual ApplicationUser UsuarioCreador { get; set; }
        public List<ComponenteOperando> Operandos { get; set; }
        public override double ObtenerValor(Empresa empresa, int periodo, List<ComponenteOperando> listaOperandos)
        {
            AntlrInputStream input = new AntlrInputStream(this.Formula);
            gramaticaLexer lexer = new gramaticaLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            gramaticaParser parser = new gramaticaParser(tokens);
            IParseTree tree = parser.expr();
            MyVisitor visitor = new MyVisitor(empresa, periodo, listaOperandos);
            return Math.Round(visitor.Visit(tree), 2);
        }
        public void Editar(Indicador indEdited)
        {
            //this.Nombre = indEdited.Nombre;
            this.Formula = indEdited.Formula;
            this.UsuarioCreador_Id = indEdited.UsuarioCreador_Id;
            this.Operandos = indEdited.Operandos;
        }
        public void ValidarExpresionFormula(IEnumerable<Indicador> indicadores)
        {
            //GramaticaLexer lexer = new GramaticaLexer(new AntlrInputStream(this.Formula));
            //CommonTokenStream tokens = new CommonTokenStream(lexer);
            //GramaticaParser parser = new GramaticaParser(tokens);
            //parser.BuildParseTree = true;
            //GramaticaParser.IndicadorContext indicadorContext = parser.indicador();
            //ParseTreeWalker walker = new ParseTreeWalker();
            //Listener listener = new Listener(textBox2.Text);
            //walker.Walk(listener, indicadorContext);

            ////lo muestro en el tree view
            //treeView1.Nodes.Clear();
            //BinaryTreeNode<IContenidoNodo> nodo = listener.ArbolBinario.Root;
            //treeView1.Nodes.Add(agregarAlTreeView(nodo));

            ////guardar Listener.ArbolBinario
            //Indicadores.listaDeIndicadores.Add(listener.ArbolBinario);
        }
    }
}
