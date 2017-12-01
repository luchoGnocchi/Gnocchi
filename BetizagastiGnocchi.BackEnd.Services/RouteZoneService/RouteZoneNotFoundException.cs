using System;
using System.Runtime.Serialization;

namespace BetizagastiGnocchi.BackEnd.Services.RouteZoneServices
{
    [Serializable]
    internal class RouteZoneNotFoundException : Exception
    {
        public RouteZoneNotFoundException()
        {
        }

        public RouteZoneNotFoundException(string message) : base(message)
        {
        }

        public RouteZoneNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RouteZoneNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}