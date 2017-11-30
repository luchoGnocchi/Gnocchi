using BetizagastiGnocchi.BackEnd.Domain.Enum;
using System;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
	public class State
	{
		public int Id { get; set; }
		public Place PlaceInMoment { get; set; }
		public DateTime CurrentDate { get; set; }
	}
}