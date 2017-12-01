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
using BetizagastiGnocchi.BackEnd.Services.Core.Generics;

namespace BetizagastiGnocchi.BackEnd.Services.VehicleService
{
	public class VehicleService :GenericService<Vehicle>, IVehicleService
	{
	
		private readonly IUserService userService;
		private readonly IRepository<Vehicle> _genericRepository;



		public VehicleService(IRepository<Vehicle> genericRepository, IUserService _userService) : base(genericRepository)
		{
			_genericRepository = genericRepository;
			this.userService = _userService;
		}

		public override void Add(string token,Vehicle item )	
		{
			if(userService.HasAccess(token, "Vehicle.Add"))
			{
				Expression<Func<Vehicle, bool>> filter = dto => dto.VIN == item.VIN;
				var vehicles = _genericRepository.Get(filter, null, "");
				if (vehicles == null || vehicles.Count() == 0)
				{
					item.HistoryState.Add(new State { CurrentDate = DateTime.Now, PlaceInMoment = Domain.Enum.Place.Puerto });
					_genericRepository.Insert(item);
					 
					return;
				}
				throw new VehicleVINAlreadyRegisteredException(string.Format("El Vehiculo '{0}' ya está registrado.", item.VIN));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción", item.VIN));
		}
		//Todo Luciano: se definio en aulas que los vehiculos no se pueden borrar
		public override void DeleteById(string token, params object[] keyValues)
		{
	 	if(userService.HasAccess(token, "Vehicle.DeleteById"))
			{
				Vehicle item = GetbyId(keyValues);
				Expression<Func<Vehicle, bool>> filter = dto => dto.VIN == item.VIN;
				var vehicles = _genericRepository.Get(filter, null, "");
				if (vehicles != null || vehicles.Count() > 0)
				{
					_genericRepository.Delete(keyValues);
					 
					return;
				}
				throw new VehicleVINAlreadyRegisteredException(string.Format("El Vehiculo '{0}' ya está registrado.", item.VIN));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}
		
	 

		public Vehicle ExistPlate(string Plate)
		{
			return _genericRepository.GetAll().Where(x => x.VIN== Plate).FirstOrDefault();
		}

        public List<Vehicle> GetVehicleOutBatch()
        {
            return _genericRepository.GetAll().Where(x => x.Batch == null).ToList();
        }

        public List<Vehicle> GetVehicleReadyToSell()
        {
                return _genericRepository.GetAll().Where(x => x.readyToBuy).ToList();
        }

        public bool sell(string Plate, Sell info)
        {
            Vehicle toSell = ExistPlate(Plate);
            if (toSell != null) {
                if (toSell.sell?.Name == null ||  toSell.sell?.Name==""  )
                {
                    toSell.sell = info;
                    _genericRepository.Update(toSell, toSell.Id);
                    return true;
                }
                throw new VehicleNotFoundException(string.Format("El Vehiculo '{0}' ya fue vendido registrado.",Plate));
            }
            throw new VehicleNotFoundException(string.Format("El Vehiculo '{0}' ya está registrado.",Plate));
                    }

        public override Vehicle Update(string token, Vehicle item)
		{
			if (userService.HasAccess(token, "Vehicle.UpdateById"))
			{
				Expression<Func<Vehicle, bool>> filter = dto => dto.VIN == item.VIN && dto.Id!=item.Id;
				var vehicles = _genericRepository.Get(filter, null, "");
				if (vehicles == null || vehicles.Count() == 0)
				{
					_genericRepository.Update(item, item.Id);
					 
					return item;
				}
				throw new VehicleVINAlreadyRegisteredException(string.Format("El Vehiculo '{0}' ya está registrado.", item.VIN));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción", item.VIN));
		}

      
    }
}
