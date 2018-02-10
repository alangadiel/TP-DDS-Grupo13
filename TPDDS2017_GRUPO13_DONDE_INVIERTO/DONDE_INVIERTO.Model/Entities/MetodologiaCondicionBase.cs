using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using TrailHealth.Integration.Disconnected;

namespace DONDE_INVIERTO.Model
{
	[DataContract]
	public abstract class MetodologiaCondicionBase : EditableEntity
	{
		private int _id;
		private int _condicionId;
		private int _metodologiaId;
		[DataMember]
		public virtual int CondicionId
		{
			get { return _condicionId; }
			set { _condicionId = value; }
		}
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		[DataMember]
		public virtual int MetodologiaId
		{
			get { return _metodologiaId; }
			set { _metodologiaId = value; }
		}
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
