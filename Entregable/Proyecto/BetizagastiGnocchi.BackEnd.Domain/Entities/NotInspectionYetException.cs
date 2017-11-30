using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
	[Serializable]
	internal class NotInspectionYetException : Exception
	{
		public NotInspectionYetException()
		{
		}

		public NotInspectionYetException(string message) : base(message)
		{
		}

		public NotInspectionYetException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected NotInspectionYetException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}