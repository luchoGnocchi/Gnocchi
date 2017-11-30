using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
    public class Zone
    {
        public Zone()
        {
        }
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Zone> SubZones { get; set; } = new List<Zone>();
        public int MaxCapacity { get; set; }
        public int UsedCapacity { get; set; }
		public virtual List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

		public bool ValidateSubZonesCapacity()
        {
            int totalCapacityOfSubZones = 0;
            foreach (var subzone in SubZones)
            {
                totalCapacityOfSubZones += subzone.MaxCapacity;
            }
            return totalCapacityOfSubZones <= MaxCapacity;
        }
    }
}