using DONDE_INVIERTO.Model;
using DONDE_INVIERTO.Model.Views;
using System.Collections.Generic;

namespace DONDE_INVIERTO.ANTLR
{
    public interface ITipoCondicion
    {
        TipoCondicion Tipo { get; set; }

        Indicador Indicador { get; set; }

        //En los Analizar, retornar true cuando no haya criterio

        bool Analizar(EmpresaView empresa, List<Indicador> indicadores);//True si no hay que descartar a la empresa

        bool Analizar(EmpresaView empresa1, EmpresaView empresa2, List<Indicador> indicadores); //True si empresa1>empresa2

    }
}
