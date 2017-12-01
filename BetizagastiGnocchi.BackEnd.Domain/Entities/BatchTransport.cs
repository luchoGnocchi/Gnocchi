using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
	public class BatchTransport
	{
		[Key]
		public int Id { get; set; }


		public virtual List<Batch> Batchs { get; set; } = new List<Batch>();
        
        [ForeignKey("Transporter")]
        public int? UserdId { get; set; }
        public virtual User Transporter { get; set; }
        [ForeignKey("Creator")]
        public int? CreatorUserId { get; set; }
        public virtual User Creator { get; set; }
        public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public void StartTravel()
		{
			foreach (var batch in Batchs)
			{
				foreach (var vehicle in batch.Vehicles)
				{
					vehicle.HistoryState.Add(new State { CurrentDate = DateTime.Now, PlaceInMoment = Domain.Enum.Place.EnTransporte });
				}
			}
		}
		public void FinishTravel()
		{
			foreach (var batch in Batchs)
			{
				foreach (var vehicle in batch.Vehicles)
				{
					vehicle.HistoryState.Add(new State { CurrentDate = DateTime.Now, PlaceInMoment = Domain.Enum.Place.Patio });
				}
			}
		}
		public bool TravelisStart()
		{
			return StartDate != new DateTime(1998, 04, 30);
		}
		public bool TravelisFinish()
		{
			return FinishDate != new DateTime(1998, 04, 30);
		}

	}
}