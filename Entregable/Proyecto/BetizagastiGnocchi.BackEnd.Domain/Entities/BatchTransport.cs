using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
    public class BatchTransport
    {
		[Key]
		public int Id { get; set; }


		public virtual List<Batch> Batchs { get; set; } = new List<Batch>();
        public User Transporter { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}