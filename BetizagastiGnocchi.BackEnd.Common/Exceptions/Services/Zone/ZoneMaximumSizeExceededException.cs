using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Services.ZoneServices
{
	[Serializable]
	public class ZoneMaximumSizeExceededException : Exception
	{
		public ZoneMaximumSizeExceededException()
		{
		}

		public ZoneMaximumSizeExceededException(string message) : base(message)
		{
		}

		public ZoneMaximumSizeExceededException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ZoneMaximumSizeExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}