using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using TrailHealth.Integration.Disconnected;

namespace DONDE_INVIERTO.Model
{
	[DataContract]
	public abstract class TipoCondicionBase : EditableEntity
	{
		private int _id;
		private string _codigo;
		private string _descripcion;
		[DataMember]
		public virtual string Codigo
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		[DataMember]
		public virtual string Descripcion
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
