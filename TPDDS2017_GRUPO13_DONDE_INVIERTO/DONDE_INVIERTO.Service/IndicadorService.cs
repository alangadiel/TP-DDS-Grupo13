using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using DONDE_INVIERTO.ANTLR;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System;
using System.Collections.Generic;
using DONDE_INVIERTO.DataStorage;
using System.Linq;
using System.Web.Script.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace DONDE_INVIERTO.Service
{
    public class IndicadorService
    {
        public double ObtenerValor(ComponenteOperando indicador, EmpresaView empresa, int periodo, List<ComponenteOperando> listaOperandos)
        {
            AntlrInputStream input = new AntlrInputStream(indicador.Formula);
            gramaticaLexer lexer = new gramaticaLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            gramaticaParser parser = new gramaticaParser(tokens);
            IParseTree tree = parser.expr();
            VisitorCore visitor = new VisitorCore(empresa, periodo, listaOperandos);
            return Math.Round(visitor.Visit(tree), 2);
        }

        public double EvaluarIndicadorParaEmpresa(int idIndicador, int idEmpresa, int periodo, string username)
        {
            //Obtengo el indicador y empresa solicitada
            var indicador = Get(idIndicador);
            var empSv = new EmpresaService();
            var empresa = empSv.Get(idEmpresa);
            var empresaView = new EmpresaView
            {
                Id = empresa.Id,
                FechaFundacion = empresa.FechaFundacion,
                Nombre = empresa.Nombre,
                Balances = Context.Session.Query<Balance>().Where(b => b.EmpresaId == idEmpresa).ToList()
            };
            //Aplico el indicador, es decir, hay que parsear la formula
            var listaOperandos = Context.Session.Query<ComponenteOperando>()
                .Where(c => c.UsuarioCreador_Id == UserService.GetUserId(username)).ToList();
            return ObtenerValor(indicador, empresaView, periodo, listaOperandos);
        }

        public List<ComponenteOperando> List(string username)
        {
            return Context.Session.Query<ComponenteOperando>()
                .Where(ind => ind.UsuarioCreador_Id == UserService.GetUserId(username) && ind.Formula != null)
                .OrderBy(ind => ind.Nombre).ToList();
        }

        public void Save(ComponenteOperando indicador, string username)
        {
            indicador.Discriminador = "Indicador";
            indicador.UsuarioCreador_Id = UserService.GetUserId(username);
            Save(indicador);
        }

        public void Save(ComponenteOperando indicador)
        {
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
