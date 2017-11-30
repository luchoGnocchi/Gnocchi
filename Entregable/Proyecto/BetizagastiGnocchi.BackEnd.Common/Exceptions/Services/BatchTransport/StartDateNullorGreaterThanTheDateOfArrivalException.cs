using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Services.BatchTransportServices
{
	[Serializable]
	public class StartDateNullorGreaterThanTheDateOfArrivalException : Exception
	{
		public StartDateNullorGreaterThanTheDateOfArrivalException()
		{
		}

		public StartDateNullorGreaterThanTheDateOfArrivalException(string message) : base(message)
		{
		}

		public StartDateNullorGreaterThanTheDateOfArrivalException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected StartDateNullorGreaterThanTheDateOfArrivalException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}