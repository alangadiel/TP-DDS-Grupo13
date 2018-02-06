using System.Runtime.Serialization;

namespace DONDE_INVIERTO.Model
{
    [DataContract]
    public class Indicador
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public decimal? Valor { get; set; }

        [DataMember]
        public string Formula { get; set; }

        [DataMember]
        public string Discriminador { get; set; }

        [DataMember]
        public int? IndicadorPadreId { get; set; }

        [DataMember]
        public int? BalanceId { get; set; }

    }
}
