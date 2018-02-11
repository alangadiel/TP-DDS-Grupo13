using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System.Collections.Generic;
using DONDE_INVIERTO.Service;
using System.Text.RegularExpressions;

namespace DONDE_INVIERTO.Service.Tests
{
    [TestClass]
    public class IndicadoresTest
    {
        const string pattern = @"((\b([A-z]*[0-9]*|[0-9]*[A-z]*)[a-z0-9]*\b)([+\-\*\/]\(?(\b([a-z]*[0-9]*|[0-9]*[a-z]*)[a-z0-9]*\b)\)?)+)";
        [TestMethod]
        public void SumaRecursivaIndicadores()
        {
            ComponenteOperando indicadorTest = new ComponenteOperando
            {
                Formula = "cuenta + 1",
                Nombre = "ind"
            };
            ComponenteOperando cuenta = new ComponenteOperando
            {
                Nombre = "cuenta",
                Valor = 50,
                BalanceId = 1
            };
            ComponenteOperando indicador2 = new ComponenteOperando
            {
                Formula = "ind + 10"
            };
            EmpresaView empresa = new EmpresaView() { Id=4 } ;
            Balance bal = new Balance
            {
                Id = 1,
                EmpresaId = empresa.Id,
                Periodo = 2017
            };
            //bal.Cuentas.Add(cuenta);
            empresa.Balances.Add(bal);

            List<ComponenteOperando> lista = new List<ComponenteOperando>
            {
                cuenta,
                indicadorTest
            };
            int periodo = 2017;
            var serv = new IndicadorService() { Indicador = indicador2 };
            double result = serv.ObtenerValor(empresa, periodo, lista);
            Assert.AreEqual(result, 61);
        }

        [TestMethod]
        public void IndicadorMasCuentaPorValor()
        {
            ComponenteOperando indicadorTest = new ComponenteOperando
            {
                Formula = "cuenta * 10",
                Nombre = "ind"
            };
            ComponenteOperando cuenta = new ComponenteOperando
            {
                Nombre = "cuenta",
                Valor = 50,
                BalanceId=1
            };
            ComponenteOperando indicador2 = new ComponenteOperando
            {
                Formula = "ind + 25"
            };
            EmpresaView empresa = new EmpresaView() { Id = 4 };
            Balance bal = new Balance
            {
                Id=1,
                EmpresaId = empresa.Id,
                Periodo = 2017
            };
            empresa.Balances.Add(bal);

            List<ComponenteOperando> lista = new List<ComponenteOperando>
            {
                cuenta,
                indicadorTest
            };
            int periodo = 2017;
            var serv = new IndicadorService() { Indicador = indicador2 };
            double result = serv.ObtenerValor(empresa, periodo, lista);
            Assert.AreEqual(result, 525);
        }
        [TestMethod]
        public void SumaSoloCuenta()
        {
            ComponenteOperando indicadorTest = new ComponenteOperando
            {
                Formula = "18 + terd",
                Nombre = "ind"
            };
            ComponenteOperando cuenta = new ComponenteOperando
            {
                Nombre = "terd",
                Valor = 50,
                BalanceId = 1
            };
            EmpresaView empresa = new EmpresaView() { Id = 4 };
            Balance bal = new Balance
            {
                Id =1, 
                EmpresaId = empresa.Id,
                Periodo = 2017
            };
            empresa.Balances.Add(bal);

            List<ComponenteOperando> lista = new List<ComponenteOperando>
            {
                cuenta,
                indicadorTest
            };
            int periodo = 2017;
            var serv = new IndicadorService() { Indicador = indicadorTest };
            double result = serv.ObtenerValor(empresa, periodo, lista);
            Assert.AreEqual(result, 68);
        }
        [TestMethod]
        public void MultiplicacionCuentaValor()
        {
            ComponenteOperando indicadorTest = new ComponenteOperando
            {
                Formula = "10 * terd",
                Nombre = "ind"
            };
            ComponenteOperando cuenta = new ComponenteOperando
            {
                Nombre = "terd",
                Valor = 50,
                BalanceId = 1
            };

            EmpresaView empresa = new EmpresaView() { Id = 4 };
            Balance bal = new Balance
            {
                Id=1,
                EmpresaId = empresa.Id,
                Periodo = 2017
            };
            empresa.Balances.Add(bal);

            List<ComponenteOperando> lista = new List<ComponenteOperando>
            {
                cuenta,
                indicadorTest
            };
            int periodo = 2017;
            var serv = new IndicadorService() { Indicador = indicadorTest };

            double result = serv.ObtenerValor(empresa, periodo, lista);
            Assert.AreEqual(result, 500);
        }
        [TestMethod]
        public void DivisionConParentesisEsCorrecto()
        {
            string formulaAParsear = "a/(b+c)";
            bool result = Regex.IsMatch(formulaAParsear, pattern);
            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void MultiplicacionSinSegundoOperandoIncorrecto()
        {
            string formulaAParsear = "a*";
            bool result = Regex.IsMatch(formulaAParsear, pattern);
            Assert.AreEqual(result, false);
        }
    }
}
