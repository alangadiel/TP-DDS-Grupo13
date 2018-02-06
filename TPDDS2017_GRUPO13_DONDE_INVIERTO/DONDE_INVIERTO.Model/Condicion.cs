using System.Runtime.Serialization;

namespace DONDE_INVIERTO.Model
{
    [DataContract]
    public class Condicion
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int? IndicadorId { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string Discriminador { get; set; }

        [DataMember]
        public int? TipoCondicionId { get; set; }
    }
}
