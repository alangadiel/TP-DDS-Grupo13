using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using TrailHealth.Integration.Disconnected;

namespace DONDE_INVIERTO.Model
{
	[DataContract]
	public abstract class CondicionBase : EditableEntity
	{
		private int _id;
		private string _descripcion;
		private string _discriminador;
		private int? _indicadorId;
		[DataMember]
		public virtual string Descripcion
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		[DataMember]
		public virtual string Discriminador
		{
			get { return _discriminador; }
			set { _discriminador = value; }
		}
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		[DataMember]
		public virtual int? IndicadorId
		{
			get { return _indicadorId; }
			set { _indicadorId = value; }
		}
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
