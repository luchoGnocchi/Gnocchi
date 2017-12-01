using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Services.BatchTransportServices
{
	[Serializable]
	public class BatchAlreadyRegisteredInBatchTransportException : Exception
	{
		public BatchAlreadyRegisteredInBatchTransportException()
		{
		}

		public BatchAlreadyRegisteredInBatchTransportException(string message) : base(message)
		{
		}

		public BatchAlreadyRegisteredInBatchTransportException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected BatchAlreadyRegisteredInBatchTransportException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}