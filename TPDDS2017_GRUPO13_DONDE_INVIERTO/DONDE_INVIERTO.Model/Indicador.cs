using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DONDE_INVIERTO.Model
{
    public class Indicador : ComponenteOperando
    {
        public string Formula { get; set; }
        public string UsuarioCreador_Id { get; set; }
        public List<ComponenteOperando> Operandos { get; set; }

        public void Editar(Indicador indEdited)
        {
            //this.Nombre = indEdited.Nombre;
            this.Formula = indEdited.Formula;
            this.UsuarioCreador_Id = indEdited.UsuarioCreador_Id;
            this.Operandos = indEdited.Operandos;
        }
    }
}
