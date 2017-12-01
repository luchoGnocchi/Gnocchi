using BetizagastiGnocchi.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
	public class UserRol
	{
		public int Id { get; set; }
		public UserType UType { get; set; }

		public virtual ICollection<ActionOperation> ActionOperations { get; set; } = new HashSet<ActionOperation>();
	}
}
