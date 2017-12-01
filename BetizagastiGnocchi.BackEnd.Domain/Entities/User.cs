

using BetizagastiGnocchi.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
	public class User : IEquatable<User>
	{
		[Key]
		public int Id { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }


        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }



        public Guid Token { get; set; }

		[ForeignKey("Rol")]
		public int Rol_Id { get; set; }
		public virtual UserRol Rol { get; set; }

		public string Salt { get; set; }

		public bool Equals(User other)
		{
			if (other == null)
			{
				return false;
			}

			return this.Token.Equals(other.Token);
		}
	}
}
