using BetizagastiGnocchi.BackEnd.Common.Exceptions;
using BetizagastiGnocchi.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
	public class Vehicle
	{

		[Key]
		public int Id { get; set; }

		public string Brand { get; set; }

		public string Model { get; set; }

		public int Year { get; set; }

		public virtual List<State> HistoryState { get; set; } = new List<State>();

		public int? BatchId { get; set; }
		public virtual Batch Batch { get; set; }

		public string Color { get; set; }
		
		public string VehicleType { get; set; }

		public string VIN { get; set; }

        public virtual List<Inspection> Inspections { get; set; } 

		public override string ToString()
        {
            return $"{VehicleType} {Brand} {Model} {Year}, Color {Color}, VIN: {VIN}";
        }
		public Inspection getLastInspection(){
			int lastInspectionIndex = Inspections.Count - 1;
			if (lastInspectionIndex == -1)
				throw new VehicleNotInspectedException();

			return Inspections[lastInspectionIndex];
				}
		 
        public bool ReadyToGo()
        {
		 
			int lastStateIndex = HistoryState.Count - 1;
			try
			{
				if (getLastInspection().Status == InspectionStatus.OK)
				{
					if(lastStateIndex==-1)
						throw new VehicleNotInspectedException();
					if (HistoryState[lastStateIndex].PlaceInMoment == Place.Puerto)
					return true;
				}
				    return false;
			}
			catch (Exception)
			{
				throw new VehicleNotInspectedException();
			}
		}
		public bool ReadyToAssingZone()
		{
			int lastStateIndex = HistoryState.Count - 1;
			try
			{
				if (getLastInspection().Status == InspectionStatus.OK)
				{
					if (lastStateIndex == -1)
						throw new VehicleNotInspectedException();
					if (HistoryState[lastStateIndex].PlaceInMoment == Place.Patio)
						return true;
				}
				return false;
			}
			catch (Exception)
			{
				throw new VehicleNotInspectedException();
			}
		}

	}
}
