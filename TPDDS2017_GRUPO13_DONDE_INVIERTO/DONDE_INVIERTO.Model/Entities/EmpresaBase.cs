using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using TrailHealth.Integration.Disconnected;

namespace DONDE_INVIERTO.Model
{
	[DataContract]
	public abstract class EmpresaBase : EditableEntity
	{
		private int _id;
		private DateTime? _fechaFundacion;
		private string _nombre;
		[DataMember]
		public virtual DateTime? FechaFundacion
		{
			get { return _fechaFundacion; }
			set { _fechaFundacion = value; }
		}
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		[DataMember]
		public virtual string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
