using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DONDE_INVIERTO.Service
{
    public class ComponenteService
    {
        public ComponenteOperando Componente { get; set; }

        public List<ComponenteOperando> List(string username)
        {
            return Context.Session.Query<ComponenteOperando>()
                .Where(comp => comp.UsuarioCreador_Id == UserService.GetUserId(username))
                .OrderBy(comp => comp.Nombre).ToList();
        }

        public double ObtenerValor(EmpresaView empresa, int periodo, List<ComponenteOperando> listaOperandos)
        {
            if (Componente.Formula != null)
                return (new IndicadorService()).ObtenerValor(Componente, empresa, periodo, listaOperandos);

            else return (new CuentaService()).ObtenerValor(Componente, empresa, periodo, listaOperandos);
        }
    }
}
