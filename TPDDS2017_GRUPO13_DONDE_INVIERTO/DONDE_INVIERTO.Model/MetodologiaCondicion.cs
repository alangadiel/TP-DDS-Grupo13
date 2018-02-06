using System.Runtime.Serialization;

namespace DONDE_INVIERTO.Model
{
    [DataContract]
    public class MetodologiaCondicion
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int MedodologiaId { get; set; }

        [DataMember]
        public int CondicionId { get; set; }
    }
}
