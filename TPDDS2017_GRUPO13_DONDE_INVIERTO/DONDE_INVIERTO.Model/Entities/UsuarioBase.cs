using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using TrailHealth.Integration.Disconnected;

namespace DONDE_INVIERTO.Model
{
	[DataContract]
	public abstract class UsuarioBase : EditableEntity
	{
		private int _id;
		private string _contrasenia;
		private string _username;
		[DataMember]
		public virtual string Contrasenia
		{
			get { return _contrasenia; }
			set { _contrasenia = value; }
		}
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		[DataMember]
		public virtual string Username
		{
			get { return _username; }
			set { _username = value; }
		}
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
