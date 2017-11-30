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
		public int Time { get; set; }
        public User User { get; set; }
        public Vehicle Vehicle { get; set; }
        public Zone OriginZone { get; set; }
        public Zone DestinationZone { get; set; }
    }
}