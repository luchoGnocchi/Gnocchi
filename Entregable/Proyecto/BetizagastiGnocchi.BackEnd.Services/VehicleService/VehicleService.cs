using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.DAL;
using System.Net;
using System.Linq.Expressions;
using BetizagastiGnocchi.BackEnd.Services.UserService;
using BetizagastiGnocchi.BackEnd.Common.Services.Vehicle;
using BetizagastiGnocchi.BackEnd.Common.Services.General;

namespace BetizagastiGnocchi.BackEnd.Services.VehicleService
{
	public class VehicleService : IVehicleService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IUserService userService;
		
		public VehicleService(IUnitOfWork unitOfWork, IUserService userService)
		{
			this.unitOfWork = unitOfWork;
			this.userService = userService;
		}

		public VehicleService(IUserService userService)
		{
			this.unitOfWork = new UnitOfWork();
			this.userService = userService;
		}
		public void Add(string token,Vehicle item )	
		{
			if(userService.HasAccess(token, "Vehicle.Add"))
			{
				Expression<Func<Vehicle, bool>> filter = dto => dto.VIN == item.VIN;
				var vehicles = unitOfWork.VehicleRepository.Get(filter, null, "");
				if (vehicles == null || vehicles.Count() == 0)
				{
					item.HistoryState.Add(new State { CurrentDate = DateTime.Now, PlaceInMoment = Domain.Enum.Place.Puerto });
					unitOfWork.VehicleRepository.Insert(item);
					unitOfWork.Save();
					return;
				}
				throw new VehicleVINAlreadyRegisteredException(string.Format("El Vehiculo '{0}' ya está registrado.", item.VIN));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción", item.VIN));
		}
		//Todo Luciano: se definio en aulas que los vehiculos no se pueden borrar
		public void DeleteById(string token, params object[] keyValues)
		{
	 	if(userService.HasAccess(token, "Vehicle.DeleteById"))
			{
				Vehicle item = GetbyId(keyValues);
				Expression<Func<Vehicle, bool>> filter = dto => dto.VIN == item.VIN;
				var vehicles = unitOfWork.VehicleRepository.Get(filter, null, "");
				if (vehicles != null || vehicles.Count() > 0)
				{
					unitOfWork.VehicleRepository.Delete(keyValues);
					unitOfWork.Save();
					return;
				}
				throw new VehicleVINAlreadyRegisteredException(string.Format("El Vehiculo '{0}' ya está registrado.", item.VIN));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}
		
		public bool Exist(params object[] keyValues)
		{
			Vehicle vehicle = unitOfWork.VehicleRepository.GetByID(keyValues[0]);
			return vehicle != null;
		}

		public Vehicle ExistPlate(string Plate)
		{
			return unitOfWork.VehicleRepository.GetAll().Where(x => x.VIN== Plate).FirstOrDefault();
		}

		public ICollection<Vehicle> GetAll()
		{
			return unitOfWork.VehicleRepository.GetAll().ToList();
		}

		public Vehicle GetbyId(params object[] keyValues)
		{
		 
			return unitOfWork.VehicleRepository.GetByID(keyValues[0]);
		}

		public Vehicle Update(string token, Vehicle item)
		{
			if (userService.HasAccess(token, "Vehicle.UpdateById"))
			{
				Expression<Func<Vehicle, bool>> filter = dto => dto.VIN == item.VIN && dto.Id!=item.Id;
				var vehicles = unitOfWork.VehicleRepository.Get(filter, null, "");
				if (vehicles == null || vehicles.Count() == 0)
				{
					unitOfWork.VehicleRepository.Update(item, item.Id);
					unitOfWork.Save();
					return item;
				}
				throw new VehicleVINAlreadyRegisteredException(string.Format("El Vehiculo '{0}' ya está registrado.", item.VIN));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción", item.VIN));
		}
	}
}
