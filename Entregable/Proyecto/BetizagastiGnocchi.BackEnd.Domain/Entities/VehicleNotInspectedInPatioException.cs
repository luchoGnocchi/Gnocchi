using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
	[Serializable]
	internal class VehicleNotInspectedInPatioException : Exception
	{
		public VehicleNotInspectedInPatioException()
		{
		}

		public VehicleNotInspectedInPatioException(string message) : base(message)
		{
		}

		public VehicleNotInspectedInPatioException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected VehicleNotInspectedInPatioException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}