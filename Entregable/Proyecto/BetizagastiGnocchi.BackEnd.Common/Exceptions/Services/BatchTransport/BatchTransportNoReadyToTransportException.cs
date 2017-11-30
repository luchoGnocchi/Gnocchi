using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Common.Services.BatchTransport
{
	[Serializable]
    public class BatchTransportNoReadyToTransportException : Exception
	{
		public BatchTransportNoReadyToTransportException()
		{
		}

		public BatchTransportNoReadyToTransportException(string message) : base(message)
		{
		}

		public BatchTransportNoReadyToTransportException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected BatchTransportNoReadyToTransportException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}