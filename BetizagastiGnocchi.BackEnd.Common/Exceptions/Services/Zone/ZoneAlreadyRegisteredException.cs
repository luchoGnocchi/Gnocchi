using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Services.ZoneServices
{
	[Serializable]
	public class ZoneAlreadyRegisteredException : Exception
	{
		public ZoneAlreadyRegisteredException()
		{
		}

		public ZoneAlreadyRegisteredException(string message) : base(message)
		{
		}

		public ZoneAlreadyRegisteredException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ZoneAlreadyRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}