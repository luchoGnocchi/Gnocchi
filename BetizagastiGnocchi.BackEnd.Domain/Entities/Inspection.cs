using System;
using BetizagastiGnocchi.BackEnd.Domain.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
    public class Inspection
    {
		[Key]
		public int Id { get; set; }
		public InspectionStatus Status { get; set; }

        public DateTime DateAndTime { get; set; }

        public InspectionPlace Place { get; set; }

        public User Inspector { get; set; }
		public int VehicleId { get; set; }
		public virtual Vehicle Vehicle { get; set; }

		public virtual List<DamageRegistry> DamageRegistries { get; set; } = new List<DamageRegistry>();

    }
}