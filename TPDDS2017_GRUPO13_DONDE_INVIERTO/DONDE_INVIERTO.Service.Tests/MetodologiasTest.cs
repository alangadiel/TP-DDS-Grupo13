using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System.Collections.Generic;
using DONDE_INVIERTO.Service;
using System.Text.RegularExpressions;
using DONDE_INVIERTO.ANTLR;

namespace DONDE_INVIERTO.Service.Tests
{
    [TestClass]
    public class MetodologiasTest
    {
        [TestMethod]
        public void Longevidad()
        {
            var serv = new MetodologiaService
            {
                Condiciones = new List<ITipoCondicion>
                {
                    new Longevidad() //Ordena por fecha de fundacion, y descarta las que tengan menos de 10 años
                }
            };
            var empresas = new List<EmpresaView>
            {
                new EmpresaView
                {
                    Nombre = "vieja2",
                    FechaFundacion = new DateTime(1950, 1, 1)
                },
                 new EmpresaView
                {
                    Nombre = "vieja1",
                    FechaFundacion = new DateTime(1940, 1, 1)
                },

                new EmpresaView
                {
                    Nombre = "vieja3",
                    FechaFundacion = new DateTime(1960, 1, 1)
                },
                new EmpresaView
                {
                    Nombre = "nueva1",
                    FechaFundacion = new DateTime(2016, 1, 1)
                },

                new EmpresaView
                {
                    Nombre = "nueva2",
                    FechaFundacion = new DateTime(2013, 1, 1)
                },
            };

            var res = serv.ObtenerEmpresasDeseables(empresas, new List<ComponenteOperando>());
            serv.OrdenarEmpresas(res, new List<ComponenteOperando>());

            Assert.AreEqual(3, res.Count);
            Assert.AreEqual("vieja1", res[0].Nombre);
            Assert.AreEqual("vieja2", res[1].Nombre);
            Assert.AreEqual(1950, res[1].FechaFundacion.Value.Year);
            Assert.AreEqual("vieja3", res[2].Nombre);
        }

        [TestMethod]
        public void MargenesCreciente()
        {
            var componentes = new List<ComponenteOperando>()
            {
                new ComponenteOperando
                {
                    Formula = "cuenta + 1",
                    Nombre = "ind"
                },
                new ComponenteOperando
                {
                    Nombre = "cuenta",
                    Valor = 50,
                    BalanceId = 1
                },
                new ComponenteOperando
                {
                    Nombre = "cuenta",
                    Valor = 60,
                    BalanceId = 2
                },
                
                new ComponenteOperando
                {
                    Nombre = "cuenta",
                    Valor = 30,
                    BalanceId = 3
                },
            };

            var indicador = new ComponenteOperando
            {
                Formula = "ind + 10"
            };
        
            var serv = new MetodologiaService
            {
                Condiciones = new List<ITipoCondicion>
                {
                    new MargenesCreciente{ Componente = indicador } //filtra por margenes siempre crecientes
                }

            };
            var empresas = new List<EmpresaView>
            {
                new EmpresaView
                {
                    Nombre = "e1",
                    Id = 1,
                    Balances = new List<Balance>
                    {
                        new Balance
                        {
                            Periodo = 2010,
                            Id = 1,
                            EmpresaId = 1,
                        },
                        new Balance
                        {
                            Periodo = 2011,
                            Id = 2,
                            EmpresaId = 1,
                        },
                    }
                },
                new EmpresaView
                {
                    Nombre = "e2",
                    Id = 2,
                    Balances = new List<Balance>
                    {
                        new Balance
                        {
                            Periodo = 2010,
                            Id = 1,
                            EmpresaId = 2,
                        },
                        new Balance
                        {
                            Periodo = 2011,
                            Id = 3,
                            EmpresaId = 2,
                        },
                    }
                },
            };

            var res = serv.ObtenerEmpresasDeseables(empresas, componentes);

            Assert.AreEqual(empresas[0], res[0]);
            Assert.AreEqual(1, res.Count);
        }


        [TestMethod]
        public void MinimizarDeuda()
        {
            var componentes = new List<ComponenteOperando>()
            {
                new ComponenteOperando
                {
                    Formula = "cuenta + 1",
                    Nombre = "ind"
                },
                new ComponenteOperando
                {
                    Nombre = "cuenta",
                    Valor = 30,
                    BalanceId = 1
                },
                new ComponenteOperando
                {
                    Nombre = "cuenta",
                    Valor = 50,
                    BalanceId = 2
                },

                new ComponenteOperando
                {
                    Nombre = "cuenta",
                    Valor = 60,
                    BalanceId = 3
                },
            };

            var indicador = new ComponenteOperando
            {
                Formula = "ind + 10"
            };

            var serv = new MetodologiaService
            {
                Condiciones = new List<ITipoCondicion>
                {
                    new MinimizarDeuda{ Componente = indicador } //filtra por margenes siempre crecientes
                }

            };
            var empresas = new List<EmpresaView>
            {
                new EmpresaView
                {
                    Nombre = "e1",
                    Id = 1,
                    Balances = new List<Balance>
                    {
                        new Balance
                        {
                            Periodo = 2018,
                            Id = 2,
                            EmpresaId = 1,
                        },
                    }
                },
                new EmpresaView
                {
                    Nombre = "e2",
                    Id = 2,
                    Balances = new List<Balance>
                    {
                        new Balance
                        {
                            Periodo = 2010,
                            Id = 1,
                            EmpresaId = 2,
                        },
                        new Balance
                        {
                            Periodo = 2018,
                            Id = 3,
                            EmpresaId = 2,
                        },
                    }
                },
                new EmpresaView
                {
                    Nombre = "e3",
                    Id = 3,
                    Balances = new List<Balance>
                    {
                        new Balance
                        {
                            Periodo = 2018,
                            Id = 1,
                            EmpresaId = 3,
                        },
                        
                    }
                },
            };

            var res = new List<EmpresaView>();
            res.AddRange(empresas);
            serv.OrdenarEmpresas(res, componentes);

            Assert.AreEqual(empresas[2], res[0]);
            Assert.AreEqual(empresas[0], res[1]);
            Assert.AreEqual(empresas[1], res[2]);

        }
    }
}
