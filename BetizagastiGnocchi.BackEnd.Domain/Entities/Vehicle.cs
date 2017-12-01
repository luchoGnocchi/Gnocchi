using BetizagastiGnocchi.BackEnd.Common.Exceptions;
using BetizagastiGnocchi.BackEnd.Common.Services.Vehicle;
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

        public int? ZoneId { get; set; }
        public virtual Zone zone { get; set; }
        public int? SellId { get; set; }
        public virtual Sell sell { get; set; }
        public string Color { get; set; }

        public VehicleType VehicleType { get; set; }

        public string VIN { get; set; }
        public bool readyToBuy { get; set; } = false;
        public virtual List<Inspection> Inspections { get; set; }
        public virtual List<VehicleMovement> MovementInZone { get; set; } = new List<VehicleMovement>();

        public override string ToString()
        {
            return $"{VehicleType} {Brand} {Model} {Year}, Color {Color}, VIN: {VIN}";
        }
        public Inspection getLastInspection() {
            int lastInspectionIndex = Inspections.Count - 1;
            if (lastInspectionIndex == -1)
                throw new VehicleNotInspectedException();

            return Inspections[lastInspectionIndex];
        }
        public Zone getLastZone()
        {
            return zone;
        }

        public bool ReadyToGo()
        {

            int lastStateIndex = HistoryState.Count - 1;
            try
            {
                if (getLastInspection().Status == InspectionStatus.OK)
                {
                    if (lastStateIndex == -1)
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
                if (getLastInspection().Place == InspectionPlace.Patio)
                {
                    return true;
                }
                throw new VehicleIsNotInYardException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
