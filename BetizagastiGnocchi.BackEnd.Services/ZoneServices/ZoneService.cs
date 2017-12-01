using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.DAL;
using BetizagastiGnocchi.BackEnd.Services.UserService;
using System.Linq.Expressions;
using System.Net;

using BetizagastiGnocchi.BackEnd.Common.Services.General;
using BetizagastiGnocchi.BackEnd.Services.Core.Interfaces;
using BetizagastiGnocchi.BackEnd.Services.Core.Generics;
using BetizagastiGnocchi.BackEnd.Common.Services.Vehicle;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;
using BetizagastiGnocchi.BackEnd.Services.RouteZoneServices;

namespace BetizagastiGnocchi.BackEnd.Services.ZoneServices
{
	public class ZoneService : GenericService<Zone>, IZoneService
	{
		
		private readonly IUserService userService;
		private readonly IRepository<Zone> genericRepository;
		private readonly IVehicleService vehicleService;
        private readonly IRouteZoneService routeZoneService;

        public ZoneService(IRepository<Zone> genericRepository,IVehicleService VehicleService ,  IUserService userService, IRouteZoneService RouteZoneService) :base(genericRepository)
		{
			this.genericRepository = genericRepository;
			this.vehicleService = VehicleService;
			this.userService = userService;
            this.routeZoneService = RouteZoneService;
		}
		public override void Add(string token, Zone item)
		{

			if (userService.HasAccess(token, "Zone.Add"))
			{

				Expression<Func<Zone, bool>> filter = dto => dto.Name == item.Name;
				var Zones = genericRepository.Get(filter, null, "");
				if (Zones == null || Zones.Count() == 0)
				{
					if (!item.ValidateSubZonesCapacity())
					{
						throw new ZoneMaximumSizeExceededException(string.Format("La zona '{0}' no respeta el formato de capacidad de zona- subzona.", item.Name));
					}
					genericRepository.Insert(item);
					
					return;
				}
				throw new ZoneAlreadyRegisteredException(string.Format("La zona '{0}' ya está registrada.", item.Name));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
		}
		public override void DeleteById(string token, params object[] keyValues)
		{
			if (userService.HasAccess(token, "Zone.DeleteById"))
			{

				if (Exist(keyValues))
				{
					genericRepository.Delete(keyValues);
					
					return;
				}
				throw new ZoneNotFoundException(string.Format("El Zone con Id '{0}' no fue encontrado.", keyValues));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}
		public override Zone Update(string token, Zone item)
		{
			try
			{
	if (userService.HasAccess(token, "Zone.UpdateById"))
			{
				Expression<Func<Zone, bool>> filter = dto => dto.Name == item.Name && dto.Id != item.Id;
				var Zones = genericRepository.Get(filter, null, "");
				if (Zones == null || Zones.Count() == 0)
				{
						item.Vehicles.Any(x => x.ReadyToAssingZone());
						if (!item.ValidateSubZonesCapacity())
						throw new ZoneMaximumSizeExceededException(string.Format("La zona '{0}' no respeta el formato de capacidad de zona-subzona.", item.Name));
						genericRepository.Update(item, item.Id);
					return item;
				}
				throw new ZoneAlreadyRegisteredException(string.Format("La Zona '{0}' ya está registrado con ese nombre.", item.Name));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
			}
			catch (Exception)
			{

				throw;
			}
		
		}
		public void AddVehicle(string token, Vehicle item, params object[] keyValues)
		{
			if (userService.HasAccess(token, "Zone.AddVehicle"))
			{

				var vehicle = vehicleService.GetAll().Where(x => x.VIN == item.VIN).FirstOrDefault();


				if (vehicle != null)
				{
					try
					{
						vehicle.ReadyToAssingZone();
						if (Exist(keyValues))
                        {

                            var ZoneToInsertVechicle = GetbyId(keyValues);
                            ZoneToInsertVechicle.avaibleToAddNewVehicle();
                            AsignState(token, vehicle, ZoneToInsertVechicle);
                            vehicleReadytoBuy(vehicle, ZoneToInsertVechicle);
                            vehicleService.Update(token, vehicle);

                            return;
                        }
                        throw new ZoneNotFoundException(string.Format("No se encontro la Zona indicada.", vehicle.VIN));
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
				throw new VehicleNotFoundException(string.Format("No se encontro en el sistema el vehiculo con VIM '{0}'.", item.VIN));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}

        private void AsignState(string token, Vehicle vehicle, Zone ZoneToInsertVechicle)
        {
            if (vehicle.HistoryState.Count == 4)
            {
                vehicle.HistoryState.Add(new State { CurrentDate = DateTime.Now, PlaceInMoment = Domain.Enum.Place.EnZona });
                vehicle.MovementInZone.Add(new VehicleMovement()
                {
                   DestinationZone = ZoneToInsertVechicle,
                    OriginZone = null,
                    Time = DateTime.Now,
               //     User = userService.getUserByToken(token)

                });
            }
            else
            {

               
                var x = new VehicleMovement()
                {
                    DestinationZone = ZoneToInsertVechicle,
                    OriginZone = vehicle.zone,
                    Time = DateTime.Now,
                    //  User = userService.getUserByToken(token)

                };
                x.OriginZone.UsedCapacity--;
                x.DestinationZone.UsedCapacity++;
                vehicle.MovementInZone.Add(x);
             

                if (x.DestinationZone.UsedCapacity > x.DestinationZone.MaxCapacity)
                    throw new ZoneNotFoundException(string.Format("La zona esta llena, se cancelo la operacion."));
            }
        }

        private void vehicleReadytoBuy(Vehicle vehicle, Zone ZoneToInsertVechicle)
        {
         
         vehicle.zone = ZoneToInsertVechicle;
            
            var listMovement = routeZoneService.GetAll();
            var okHistory = false;
            var MovementArray = listMovement.ToArray();
            var MovementInZoneArray = vehicle.MovementInZone.ToArray();
            if (listMovement.Count < vehicle.MovementInZone.Count)
            {
                for (int i = 0; i < MovementInZoneArray.Count(); i++)
                {
                    for (int j = 0; j < MovementArray.Count() && (i+j)< MovementInZoneArray.Count(); j++)
                    {
                        if (!(MovementArray[j].ZonesToPass.Equals(MovementInZoneArray[i + j].DestinationZone.Name)))
                            break;
                        if (j == MovementArray.Count() - 1)
                        {
                            okHistory = true;
                        }

                    }

                }
            }
            if (okHistory) { 
                vehicle.readyToBuy = true;
            vehicle.HistoryState.Add(new State { CurrentDate = DateTime.Now, PlaceInMoment = Domain.Enum.Place.Vendido });
            }
        }
    }
}
