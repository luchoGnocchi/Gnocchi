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

namespace BetizagastiGnocchi.BackEnd.Services.ZoneServices
{
	public class ZoneService : IZoneService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IUserService userService;
		public ZoneService(IUnitOfWork unitOfWork, IUserService userService)
		{
			this.unitOfWork = unitOfWork;
			this.userService = userService;
		}

		public ZoneService(IUserService userService)
		{
			this.unitOfWork = new UnitOfWork();
			this.userService = userService;
		}
		public void Add(string token, Zone item)
		{

			if (userService.HasAccess(token, "Zone.Add"))
			{

				Expression<Func<Zone, bool>> filter = dto => dto.Name == item.Name;
				var Zones = unitOfWork.ZoneRepository.Get(filter, null, "");
				if (Zones == null || Zones.Count() == 0)
				{
					if (!item.ValidateSubZonesCapacity())
					{
						throw new ZoneMaximumSizeExceededException(string.Format("La zona '{0}' no respeta el formato de capacidad de zona- subzona.", item.Name));
					}
					unitOfWork.ZoneRepository.Insert(item);
					unitOfWork.Save();
					return;
				}
				throw new ZoneAlreadyRegisteredException(string.Format("La zona '{0}' ya está registrada.", item.Name));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
		}
		public void DeleteById(string token, params object[] keyValues)
		{
			if (userService.HasAccess(token, "Zone.DeleteById"))
			{

				if (Exist(keyValues))
				{
					unitOfWork.ZoneRepository.Delete(keyValues);
					unitOfWork.Save();
					return;
				}
				throw new ZoneNotFoundException(string.Format("El Zone con Id '{0}' no fue encontrado.", keyValues));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}
		public bool Exist(params object[] keyValues)
		{
			Zone Zone = unitOfWork.ZoneRepository.GetByID(keyValues[0]);
			return Zone != null;
		}

		public ICollection<Zone> GetAll()
		{
			return unitOfWork.ZoneRepository.GetAll().ToList();
		}

		public Zone GetbyId(params object[] keyValues)
		{
			return unitOfWork.ZoneRepository.GetByID(keyValues[0]);
		}

		public Zone Update(string token, Zone item)
		{
			try
			{
	if (userService.HasAccess(token, "Zone.UpdateById"))
			{
				Expression<Func<Zone, bool>> filter = dto => dto.Name == item.Name && dto.Id != item.Id;
				var Zones = unitOfWork.ZoneRepository.Get(filter, null, "");
				if (Zones == null || Zones.Count() == 0)
				{
					if(item.Vehicles.Any(x=>x.ReadyToAssingZone()))
					

					if (!item.ValidateSubZonesCapacity())
						throw new ZoneMaximumSizeExceededException(string.Format("La zona '{0}' no respeta el formato de capacidad de zona-subzona.", item.Name));
					 

					unitOfWork.ZoneRepository.Update(item, item.Id);
					unitOfWork.Save();
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

				var vehicle = unitOfWork.VehicleRepository.GetAll().Where(x => x.VIN == item.VIN).FirstOrDefault();


				if (vehicle != null)
				{
					try
					{
						if (!vehicle.ReadyToAssingZone())
							throw new ZoneAlreadyRegisteredException(string.Format("Existen Zones que tienen el VIM '{0}'  ya registrado.", vehicle.VIN));
						if (Exist(keyValues))
						{
							var ZoneToInsertVechicle = GetbyId(keyValues);
							ZoneToInsertVechicle.Vehicles.Add(vehicle);
							unitOfWork.ZoneRepository.Update(ZoneToInsertVechicle, ZoneToInsertVechicle.Id);
							unitOfWork.Save();
							return;
						}
						throw new ZoneAlreadyRegisteredException(string.Format("Existen Zones que tienen el VIM '{0}'  ya registrado.", vehicle.VIN));

					}
					catch (Exception)
					{


					}

				}
				throw new ZoneAlreadyRegisteredException(string.Format("Existen Zones que tienen el VIM '{0}'  ya registrado.", vehicle.VIN));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}



	}
}
