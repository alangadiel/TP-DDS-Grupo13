using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using TrailHealth.Integration.Disconnected;

namespace DONDE_INVIERTO.Model
{
	[DataContract]
	public abstract class ComponenteOperandoBase : EditableEntity
	{
		private int _id;
		private int? _balanceId;
		private string _discriminador;
		private string _formula;
		private int? _padreId;
		private string _nombre;
		private decimal? _valor;
		[DataMember]
		public virtual int? BalanceId
		{
			get { return _balanceId; }
			set { _balanceId = value; }
		}
		[DataMember]
		public virtual string Discriminador
		{
			get { return _discriminador; }
			set { _discriminador = value; }
		}
		[DataMember]
		public virtual string Formula
		{
			get { return _formula; }
			set { _formula = value; }
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
		[DataMember]
		public virtual int? PadreId
		{
			get { return _padreId; }
			set { _padreId = value; }
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
