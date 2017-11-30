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
using BetizagastiGnocchi.BackEnd.Common.Services.Batch;
using BetizagastiGnocchi.BackEnd.Common.Services.General;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;

namespace BetizagastiGnocchi.BackEnd.Services.BatchServices
{
	public class BatchService : IBatchService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IUserService userService;
		private readonly IVehicleService vehicleService;
		public BatchService(IUnitOfWork unitOfWork, IUserService userService, IVehicleService vehicleService)
		{
			this.unitOfWork = unitOfWork;
			this.userService = userService;
			this.vehicleService = vehicleService;
		}

		public BatchService(IUserService userService,  IVehicleService vehicleService)
		{
			this.unitOfWork = new UnitOfWork();
			this.vehicleService = vehicleService;
			this.userService = userService;

		}
		public void Add(string token, Batch item)
		{

			if (userService.HasAccess(token, "Batch.Add"))
			{
				
                Expression<Func<Batch, bool>> filter = dto => dto.Name == item.Name;
				List<Vehicle> vehicleToInster = new List<Vehicle>();
				foreach (var vehicleInstance in item.Vehicles)
				{
					var vehicleTolist = vehicleService.ExistPlate(vehicleInstance.VIN);
					if (vehicleTolist == null)
						throw new BatchAlreadyRegisteredException(string.Format("El vehiculo '{0}' no existe en  el sistema.", vehicleInstance.VIN));
					if(vehicleTolist.Batch!=null)
						throw new BatchAlreadyRegisteredException(string.Format("El vehiculo '{0}' ya esta asigando a otro lote", vehicleInstance.VIN));
					vehicleToInster.Add(vehicleTolist);

				}
				if (vehicleToInster.Count == 0)
                    throw new BatchWithoutVehicleException(string.Format("El Lote '{0}' debe contener almenos un vehiculo.", item.Name));
				var batchs = unitOfWork.BatchRepository.Get(filter, null, "");
				if (batchs == null || batchs.Count() == 0)
				{
					item.Vehicles = vehicleToInster;
					item.Creator = unitOfWork.UserRepository.GetAll().Where(u => u.Token.ToString() == token).FirstOrDefault();
					unitOfWork.BatchRepository.Insert(item);
					unitOfWork.Save();
					return;
				}
				throw new BatchAlreadyRegisteredException(string.Format("El Lote '{0}' ya está registrado.", item.Name));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
		}

		public void DeleteById(string token, params object[] keyValues)
		{
			if (userService.HasAccess(token, "Batch.DeleteById"))
			{
			 
				if (Exist(keyValues))
				{
					unitOfWork.BatchRepository.Delete(keyValues);
					unitOfWork.Save();
					return;
				}
				throw new BatchNotFoundException(string.Format("El lote con Id '{0}' no fue encontrado.", keyValues));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}

		public bool Exist(params object[] keyValues)
		{
			Batch Batch = unitOfWork.BatchRepository.GetByID(keyValues[0]);
			return Batch != null;
		}

		public ICollection<Batch> GetAll()
		{
			return unitOfWork.BatchRepository.GetAll().ToList();
		}

		public Batch GetbyId(params object[] keyValues)
		{
			return unitOfWork.BatchRepository.GetByID(keyValues[0]);
		}

		public Batch Update(string token, Batch item)
		{
			 
				if (userService.HasAccess(token, "Batch.UpdateById"))
				{
					Expression<Func<Batch, bool>> filter = dto => dto.Name == item.Name && dto.Id != item.Id;
				List<Vehicle> vehicleToInster = new List<Vehicle>();
				foreach (var vehicleInstance in item.Vehicles)
				{
					var vehicleTolist = vehicleService.ExistPlate(vehicleInstance.VIN);
					if (vehicleTolist == null)
						throw new BatchAlreadyRegisteredException(string.Format("El vehiculo '{0}' no existe en  el sistema.", vehicleInstance.VIN));
					if (vehicleTolist.Batch != null)
						throw new BatchAlreadyRegisteredException(string.Format("El vehiculo '{0}' ya esta asigando a otro lote", vehicleInstance.VIN));
					vehicleToInster.Add(vehicleTolist);

				}
				var batchs = unitOfWork.BatchRepository.Get(filter, null, "");
					if (batchs == null || batchs.Count() == 0)
					{
					item.Vehicles = vehicleToInster;
						unitOfWork.BatchRepository.Update(item, item.Id);
						unitOfWork.Save();
						return item;
					}
					throw new BatchAlreadyRegisteredException(string.Format("El Lote '{0}' ya está registrado con ese nombre.", item.Name));
				}
				throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
			 
		}

		public void AddVehicle(string token , Vehicle vehicle, params object[] keyValues)
		{
			if (userService.HasAccess(token, "Batch.AddVehicle"))
			{
           
				var vehilceoutBatch=unitOfWork.VehicleRepository.GetAll();
               
                if (vehilceoutBatch.ToList().Count() > 0 && vehilceoutBatch.ToList().Any(x=>x.VIN==vehicle.VIN))
					  

					
                        if (Exist(keyValues)) {
						var batchToInsertVechicle = GetbyId(keyValues);
						var vehicleTolist = vehicleService.ExistPlate(vehicle.VIN);
						if (vehicleTolist == null)
							throw new BatchAlreadyRegisteredException(string.Format("El vehiculo '{0}' no existe en  el sistema.", vehicle.VIN));
						if (vehicleTolist.Batch != null)
							throw new BatchAlreadyRegisteredException(string.Format("El vehiculo '{0}' ya esta asigando a otro lote", vehicleTolist.VIN));
					batchToInsertVechicle.Vehicles.Add(vehicleTolist);
						unitOfWork.BatchRepository.Update(batchToInsertVechicle);
					unitOfWork.Save();
					return ;
							}
					throw new BatchAlreadyRegisteredException(string.Format("Existen lotes que tienen el VIM '{0}'  ya registrado.", vehicle.VIN));

			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}
		public bool IsReadyToTransport(params object[] keyValues)
		{
			return !GetbyId(keyValues).Vehicles.Any(x => !x.ReadyToGo()) ? true: throw new BatchNotAuthorizedException(string.Format("No todos los vehiculos del lote tienen una inspeccion")) ;
		}
	}
}
