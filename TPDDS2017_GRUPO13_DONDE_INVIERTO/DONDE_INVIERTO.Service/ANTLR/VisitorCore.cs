﻿using Antlr4.Runtime.Misc;
using DONDE_INVIERTO.ANTLR.Gramatica;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using DONDE_INVIERTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DONDE_INVIERTO.ANTLR
{
    public class VisitorCore : gramaticaBaseVisitor<double>
    {
        protected readonly int _periodo;
        protected readonly EmpresaView  _empresa;
        protected readonly List<ComponenteOperando> _componentes;

        public VisitorCore(EmpresaView empresa, int periodo, List<ComponenteOperando> componentes)
        {
            _empresa = empresa;
            _periodo = periodo;
            _componentes = componentes;
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
            var indicadorBuscado = context.INDICADOR().GetText();
            var indicadorEncontrado = _componentes.FirstOrDefault(x => x.Nombre.ToLower() == indicadorBuscado.ToLower());
            if (indicadorEncontrado == null) throw new Exception("No se encontro el indicador: " + indicadorBuscado);
            var serv = new ComponenteService { Componente = indicadorEncontrado };
            return serv.ObtenerValor(_empresa, _periodo, _componentes);
        }
    }
}