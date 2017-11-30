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
using BetizagastiGnocchi.BackEnd.Common.Services.Inspection;
using BetizagastiGnocchi.BackEnd.Common.Services.General;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;
using BetizagastiGnocchi.BackEnd.Common.Services.Vehicle;

namespace BetizagastiGnocchi.BackEnd.Services.InspectionService
{
	public class InspectionService : IInspectionService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IUserService userService;
		private readonly IVehicleService vehicleService;

		public InspectionService(IUnitOfWork unitOfWork, IUserService userService, IVehicleService vehicleService)
		{
			this.unitOfWork = unitOfWork;
			this.userService = userService;
			this.vehicleService = vehicleService;
		}

		public InspectionService(IUserService userService, IVehicleService vehicleService)
		{
			this.unitOfWork = new UnitOfWork();
			this.userService = userService;
			this.vehicleService = vehicleService;
		}
		public void Add(string token, Inspection item)
		{

			if (userService.HasAccess(token, "Inspection.Add"))
			{
				if (item.Vehicle == null)
					throw new InspectionWithoutVehicleException(string.Format("Deben existir Vehiculos para poder realizar la inspeccion."));

				Expression<Func<Inspection, bool>> filter = dto => dto.Place == item.Place && dto.Vehicle.VIN == item.Vehicle.VIN;
				var Inspections = unitOfWork.InspectionRepository.Get(filter, null, "");
				if (Inspections == null || Inspections.Count() == 0)
				{
					var vehicleTolist = vehicleService.ExistPlate(item.Vehicle.VIN);
					if (vehicleTolist == null)
						throw new VehicleCommissionIsPercentageException(string.Format("El vehiculo '{0}' no existe en  el sistema.", item.Vehicle.VIN));//astul
					if (item.Status == Domain.Enum.InspectionStatus.OK && item.Place == Domain.Enum.InspectionPlace.Puerto)
						vehicleTolist.HistoryState.Add(new State { CurrentDate = DateTime.Now, PlaceInMoment = Domain.Enum.Place.EsperandoParaSalir });
					item.DateAndTime = DateTime.Now;
					item.Vehicle = vehicleTolist;
					item.Inspector = unitOfWork.UserRepository.GetAll().Where(u => u.Token.ToString() == token).FirstOrDefault();
					unitOfWork.InspectionRepository.Insert(item);
					unitOfWork.Save();
					return;
				}
				throw new InspectionAlreadyRegisteredException(string.Format("La inspeccion ya fue realizada para  '{0}'  en '{1}'", item.Vehicle, item.Place));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
		}

		public void DeleteById(string token, params object[] keyValues)
		{
			if (userService.HasAccess(token, "Inspection.DeleteById"))
			{

				if (Exist(keyValues))
				{
					unitOfWork.InspectionRepository.Delete(keyValues);
					unitOfWork.Save();
					return;
				}
				throw new InspectionNotFoundException(string.Format("La inspeccion con Id '{0}' no fue encontrado.", keyValues));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}

		public bool Exist(params object[] keyValues)
		{
			Inspection Inspection = unitOfWork.InspectionRepository.GetByID(keyValues[0]);
			return Inspection != null;
		}

		public ICollection<Inspection> GetAll()
		{
			return unitOfWork.InspectionRepository.GetAll().ToList();
		}

		public Inspection GetbyId(params object[] keyValues)
		{
			return unitOfWork.InspectionRepository.GetByID(keyValues[0]);
		}

		public Inspection Update(string token, Inspection item)
		{

			if (userService.HasAccess(token, "Inspection.UpdateById"))
			{
				Expression<Func<Inspection, bool>> filter = filter = dto => dto.Place == item.Place && dto.Vehicle == item.Vehicle && dto.Id != item.Id;
				var Inspections = unitOfWork.InspectionRepository.Get(filter, null, "");
				if (Inspections == null || Inspections.Count() == 0)
				{

					var vehicleTolist = vehicleService.ExistPlate(item.Vehicle.VIN);
					if (vehicleTolist == null)
						throw new VehicleCommissionIsPercentageException(string.Format("El vehiculo '{0}' no existe en  el sistema.", item.Vehicle.VIN));//astul
					if (item.Status == Domain.Enum.InspectionStatus.OK && item.Place == Domain.Enum.InspectionPlace.Puerto)
						vehicleTolist.HistoryState.Add(new State { CurrentDate = DateTime.Now, PlaceInMoment = Domain.Enum.Place.EsperandoParaSalir });

					item.Vehicle = vehicleTolist;
					unitOfWork.InspectionRepository.Update(item);
					unitOfWork.Save();
					return item;
				}
				throw new InspectionAlreadyRegisteredException(string.Format("La inspeccion ya fue realizada para  '{0}'  en '{1}', no se puede actualizar", item.Vehicle, item.Place));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}

		public void AddDamage(string token, DamageRegistry DamageRegistry, params object[] keyValues)
		{
			if (userService.HasAccess(token, "Inspection.AddDamage"))
			{
				var vehilceoutInspection = unitOfWork.InspectionRepository.GetAll();
				if (Exist(keyValues))
				{
					var InspectionToDamage = GetbyId(keyValues);
					InspectionToDamage.DamageRegistries.Add(DamageRegistry);
					unitOfWork.InspectionRepository.Update(InspectionToDamage, InspectionToDamage.Id);
					unitOfWork.Save();
					return;
				}
				throw new InspectionNotFoundException(string.Format("No existe inspecciones con ese id '{0}'.", keyValues[0]));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
		}



	}
}
