using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using TrailHealth.Integration.Disconnected;

namespace DONDE_INVIERTO.Model
{
	[DataContract]
	public abstract class BalanceBase : EditableEntity
	{
		private int _id;
		private int _empresaId;
		private int _periodo;
		private decimal? _valor;
		[DataMember]
		public virtual int EmpresaId
		{
			get { return _empresaId; }
			set { _empresaId = value; }
		}
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		[DataMember]
		public virtual int Periodo
		{
			get { return _periodo; }
			set { _periodo = value; }
		}
		[DataMember]
		public virtual decimal? Valor
		{
			get { return _valor; }
			set { _valor = value; }
		}
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
