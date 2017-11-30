using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
    public class DamageRegistry
    {
		[Key]
		public int Id { get; set; }
		public string Description { get; set; }
		public List<byte[]> Image { get; set; }
	}
}