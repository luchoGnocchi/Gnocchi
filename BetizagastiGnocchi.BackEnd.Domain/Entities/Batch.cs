using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
    public class Batch
    {
		[Key]
		public int Id { get; set; }
        public int UserdId { get; set; }
        public virtual User User { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

		
		public virtual BatchTransport BatchTransport { get; set; }
		public virtual List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public override string ToString()
        {
            return $"Lote: {Name} || {Description}";
        }

        public bool ReadyForTransport()
        {
            foreach (var vehicle in Vehicles)
            {
                if (!vehicle.ReadyToGo())
                {
                    return false;
                }
            }
            return true;
        }
    }
}