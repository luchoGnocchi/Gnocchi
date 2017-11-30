using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Common.Services.BatchTransport
{
	[Serializable]
    public class BatchTransportWithoutVehicleException : Exception
	{
		public BatchTransportWithoutVehicleException()
		{
		}

		public BatchTransportWithoutVehicleException(string message) : base(message)
		{
		}

		public BatchTransportWithoutVehicleException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected BatchTransportWithoutVehicleException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}