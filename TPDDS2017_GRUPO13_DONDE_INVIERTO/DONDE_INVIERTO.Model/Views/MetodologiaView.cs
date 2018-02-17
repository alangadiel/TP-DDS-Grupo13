using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DONDE_INVIERTO.Model.Views
{
    [DataContract]
    public class MetodologiaView
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public List<Condicion> Condiciones { get; set; }
    }
}
