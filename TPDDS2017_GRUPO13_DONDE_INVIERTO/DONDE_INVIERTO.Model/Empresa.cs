using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace DONDE_INVIERTO.Model
{
    [DataContract]
    public class Empresa
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string CUIT { get; set; }
        [DataMember]
        public DateTime FechaFundacion { get; set; }
    }
}