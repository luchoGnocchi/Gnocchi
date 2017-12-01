using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Common.Services.BatchTransport
{
	[Serializable]
	public class BatchTransportNotFoundException : Exception
	{
		public BatchTransportNotFoundException()
		{
		}

		public BatchTransportNotFoundException(string message) : base(message)
		{
		}

		public BatchTransportNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected BatchTransportNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}