using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTLR.Clases2
{
    class Metodologia
    {
        public Metodologia(string strategy, Indicador OrdenIzq, Indicador OrdenDer)
        {
            if (!this.setStrategyOrden(strategy))
                throw new Exception();
            indicadorOrdenDer = OrdenDer;
            indicadorOrdenIzq = OrdenIzq;
        }
        public Metodologia(string strategyEx, Indicador ExcluyenteIzq, Indicador ExcluyenteDer, string strategyOr, Indicador OrdenIzq, Indicador OrdenDer)
        {
            if (!this.setStrategyExclusion(strategyEx))
                throw new Exception();
            if (!this.setStrategyOrden(strategyOr))
                throw new Exception();
            indicadorOrdenDer = OrdenDer;
            indicadorOrdenIzq = OrdenIzq;
            indicadorExcluyenteIzq = ExcluyenteIzq;
            indicadorExcluyenteDer = ExcluyenteDer;
        }
        public Metodologia(Indicador ExcluyenteIzq, Indicador ExcluyenteDer, string strategy)
        {
            if (!this.setStrategyExclusion(strategy))
                throw new Exception();
            indicadorExcluyenteIzq = ExcluyenteIzq;
            indicadorExcluyenteDer = ExcluyenteDer;
        }

        public static List<Metodologia> Metodologias = new List<Metodologia>();
        public string Nombre { get; set; }

        private int limiteDeAnios;
        private Indicador indicadorExcluyenteIzq;
        private Indicador indicadorOrdenIzq;
        private Indicador indicadorExcluyenteDer;
        private Indicador indicadorOrdenDer;
        private Strategy strategyExcluyente;
        private Strategy strategyOrden;

        public bool Orden(int a, int b) //Retorna True si a>b, para ordenar la lista
        {
            return this.strategyOrden.Comparar(a, b);
        }
        public bool Excluir(int a, int b) //Retorna True si a>b, para ordenar la lista
        {
            return this.strategyExcluyente.Comparar(a, b);
        }

        public bool setStrategyExclusion(string s)
        {
            if (Strategy.IsValid(s))
            {
                this.strategyExcluyente = Strategy.ToStrategy(s);
                return true;
            } else
                return false;
        }
        public bool setStrategyOrden(string s)
        {
            if (Strategy.IsValid(s))
            {
                this.strategyOrden = Strategy.ToStrategy(s);
                return true;
            }
            else
                return false;
        }
    }
}
