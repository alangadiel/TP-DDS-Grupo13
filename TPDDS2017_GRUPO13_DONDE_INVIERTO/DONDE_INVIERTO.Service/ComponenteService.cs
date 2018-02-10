using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.ANTLR;
using Antlr4;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using DONDE_INVIERTO.Model.Views;

namespace DONDE_INVIERTO.Service
{
    public class ComponenteService
    {
        public ComponenteOperando Componente { get; set; }

        public double ObtenerValor(EmpresaView empresa, int periodo, List<ComponenteOperando> listaOperandos)
        {
            if (Componente.Formula != null)
                return (new IndicadorService { Indicador = Componente }).ObtenerValor(empresa, periodo, listaOperandos);

            else if (Componente.Valor != null)
                return (new CuentaService { Cuenta = Componente }).ObtenerValor(empresa, periodo, listaOperandos);

            else throw new Exception("No se identifica el tipo de operando");
        }
    }
}
