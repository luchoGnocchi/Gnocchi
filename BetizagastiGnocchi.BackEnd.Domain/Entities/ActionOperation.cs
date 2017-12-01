using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
    public class ActionOperation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserRol> UserRoles { get; set; } = new HashSet<UserRol>();
    }
}
