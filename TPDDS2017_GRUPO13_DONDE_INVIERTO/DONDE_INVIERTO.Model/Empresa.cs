using System;
using System.Runtime.Serialization;

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
        public DateTime FechaFundacion { get; set; }
    }
}
