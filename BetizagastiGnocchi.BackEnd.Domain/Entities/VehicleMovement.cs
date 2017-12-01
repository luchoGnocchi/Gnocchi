using System;
using System.ComponentModel.DataAnnotations;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
    public class VehicleMovement
    {

        public VehicleMovement()
        {
        }
		[Key]
		public int Id { get; set; }
		public DateTime Time { get; set; }
        public virtual User User { get; set; }
        public virtual Zone OriginZone { get; set; }
        public virtual Zone DestinationZone { get; set; }
    }
}