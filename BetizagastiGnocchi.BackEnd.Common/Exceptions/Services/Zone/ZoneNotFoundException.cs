using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Services.ZoneServices
{
	[Serializable]
	public class ZoneNotFoundException : Exception
	{
		public ZoneNotFoundException()
		{
		}

		public ZoneNotFoundException(string message) : base(message)
		{
		}

		public ZoneNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ZoneNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}