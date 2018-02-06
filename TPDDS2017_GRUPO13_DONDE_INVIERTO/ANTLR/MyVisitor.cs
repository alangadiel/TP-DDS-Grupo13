using Antlr4.Runtime.Misc;
using DONDE_INVIERTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DONDE_INVIERTO.ANTLR
{
    class MyVisitor : gramaticaBaseVisitor<double>
    {
        public int periodo;
        public Empresa empresa;
        public List<ComponenteOperando> listaOperandos;
        public MyVisitor(Empresa _empresa, int _periodo, List<ComponenteOperando> _listaOperandos)
        {
            this.empresa = _empresa;
            this.periodo = _periodo;
            this.listaOperandos = _listaOperandos;
        }
        public override double VisitParentesis([NotNull] gramaticaParser.ParentesisContext context)
        {
            return base.Visit(context.expr());
        }
        public override double VisitSuma([NotNull] gramaticaParser.SumaContext context)
        {
            double left = Visit(context.expr(0));
            double right = Visit(context.expr(1));
            return left + right;
        }
        public override double VisitResta([NotNull] gramaticaParser.RestaContext context)
        {
            double left = Visit(context.expr(0));
            double right = Visit(context.expr(1));
            return left - right;
        }
        public override double VisitProducto([NotNull] gramaticaParser.ProductoContext context)
        {
            double left = Visit(context.expr(0));
            double right = Visit(context.expr(1));
            return left * right;
        }
        public override double VisitDivision([NotNull] gramaticaParser.DivisionContext context)
        {
            double left = Visit(context.expr(0));
            double right = Visit(context.expr(1));
            return left / right;
        }
        public override double VisitNumero([NotNull] gramaticaParser.NumeroContext context)
        {
            return double.Parse(context.num().GetText());
        }
        public override double VisitIndicador([NotNull] gramaticaParser.IndicadorContext context)
        {
            string indicadorBuscado = context.INDICADOR().GetText();
            ComponenteOperando indicadorEncontrado = listaOperandos.FirstOrDefault(x => x.Nombre.ToLower() == indicadorBuscado.ToLower());
            if (indicadorEncontrado != null)
                return indicadorEncontrado.ObtenerValor(empresa, this.periodo, listaOperandos);
            else
                throw new Exception();
        }
    }
}