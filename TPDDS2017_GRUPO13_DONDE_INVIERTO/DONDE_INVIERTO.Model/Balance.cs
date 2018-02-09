using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DONDE_INVIERTO.Model
{
    [DataContract]
    public class Balance
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Periodo { get; set; }

        [DataMember]
        public decimal Valor { get; set; }

        [DataMember]
        public int EmpresaId { get; set; }

    }
}