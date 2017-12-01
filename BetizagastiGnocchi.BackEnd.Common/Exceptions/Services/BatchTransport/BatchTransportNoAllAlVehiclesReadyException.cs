using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Services.BatchTransportServices
{
	[Serializable]
	public class BatchTransportNoAllAlVehiclesReadyException : Exception
	{
		public BatchTransportNoAllAlVehiclesReadyException()
		{
		}

		public BatchTransportNoAllAlVehiclesReadyException(string message) : base(message)
		{
		}

		public BatchTransportNoAllAlVehiclesReadyException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected BatchTransportNoAllAlVehiclesReadyException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}