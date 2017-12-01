using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Services.BatchTransportServices
{
	[Serializable]
	public class BatchTransportWithEmptyBatchException : Exception
	{
		public BatchTransportWithEmptyBatchException()
		{
		}

		public BatchTransportWithEmptyBatchException(string message) : base(message)
		{
		}

		public BatchTransportWithEmptyBatchException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected BatchTransportWithEmptyBatchException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}