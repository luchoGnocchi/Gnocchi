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
using BetizagastiGnocchi.BackEnd.Services.Core.Generics;

namespace BetizagastiGnocchi.BackEnd.Services.InspectionService
{
	public class InspectionService : GenericService<Inspection>, IInspectionService
	{
		private readonly IRepository<Inspection> _genericRepository;
		private readonly IUserService userService;
		private readonly IVehicleService vehicleService;

		public InspectionService(IRepository<Inspection> genericRepository, IUserService userService, IVehicleService vehicleService):base(genericRepository)
		{
			this.userService = userService;
			this.vehicleService = vehicleService;
			this._genericRepository = genericRepository;
		}
		public override void Add(string token, Inspection item)
		{

			if (userService.HasAccess(token, "Inspection.Add"))
			{
				if (item.Vehicle == null)
					throw new InspectionWithoutVehicleException(string.Format("Deben existir Vehiculos para poder realizar la inspeccion."));
                if(item.Status==Domain.Enum.InspectionStatus.OK && item.DamageRegistries.Count>0)
                    throw new InspectionWithoutVehicleException(string.Format("Deben estar como dañado para poder adjuntar daños"));

                Expression<Func<Inspection, bool>> filter = dto => dto.Place == item.Place && dto.Vehicle.VIN == item.Vehicle.VIN;
				var Inspections = _genericRepository.Get(filter, null, "");
				if (Inspections == null || Inspections.Count() == 0)
                {
                    AccesoParaLugar(token, item);
                    var vehicleTolist = vehicleService.ExistPlate(item.Vehicle.VIN);
                    if (vehicleTolist == null)

                        throw new VehicleCommissionIsPercentageException(string.Format("El vehiculo '{0}' no existe en  el sistema.", item.Vehicle.VIN));//astul
                    if (vehicleTolist.HistoryState.Count() != 4 && item.Place == Domain.Enum.InspectionPlace.Patio)
                    {
                        throw new VehicleCommissionIsPercentageException(string.Format("El vehiculo '{0}' debe estar en el patio para poder realizar la segunda inspeccion.", item.Vehicle.VIN));
                    }
                    if (item.Status == Domain.Enum.InspectionStatus.OK && item.Place == Domain.Enum.InspectionPlace.Puerto)
                        vehicleTolist.HistoryState.Add(new State { CurrentDate = DateTime.Now, PlaceInMoment = Domain.Enum.Place.EsperandoParaSalir });
                    if (!item.DamageRegistries.Any() && item.Place == Domain.Enum.InspectionPlace.Patio)
                    {
                        item.DamageRegistries = vehicleTolist.Inspections.Last().DamageRegistries;
                        item.DamageRegistries = new List<DamageRegistry>();
                        foreach (var dam in vehicleTolist.Inspections.Last().DamageRegistries)
                        {
                            item.DamageRegistries.Add(new DamageRegistry() { Image=dam.Image, Description=dam.Description});
                        }
                    }
                        //Todo Luciano: segun la letra dice que cuando una inspeccion es en el patio si no se ingresan daños se toman los daños de la ultima inspeccion
                       
                    item.DateAndTime = DateTime.Now;
                    item.Vehicle = vehicleTolist;
                    item.Inspector = userService.GetAll().Where(u => u.Token.ToString() == token).FirstOrDefault();
                    _genericRepository.Insert(item);

                    return;
                }
                throw new InspectionAlreadyRegisteredException(string.Format("La inspeccion ya fue realizada para  '{0}'  en '{1}'", item.Vehicle, item.Place));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
		}

        private void AccesoParaLugar(string token, Inspection item)
        {
            if (item.Place == Domain.Enum.InspectionPlace.Puerto)
            {
                userService.HasAccess(token, "Inspection.Puerto");
            }
            if (item.Place == Domain.Enum.InspectionPlace.Patio)
            {
                userService.HasAccess(token, "Inspection.Patio");
            }
        }

        public override void DeleteById(string token, params object[] keyValues)
		{
			if (userService.HasAccess(token, "Inspection.DeleteById"))
			{

				if (Exist(keyValues))
				{
					_genericRepository.Delete(keyValues);
					 
					return;
				}
				throw new InspectionNotFoundException(string.Format("La inspeccion con Id '{0}' no fue encontrado.", keyValues));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}
 
		public override Inspection Update(string token, Inspection item)
		{

			if (userService.HasAccess(token, "Inspection.UpdateById"))
			{
				Expression<Func<Inspection, bool>> filter = filter = dto => dto.Place == item.Place && dto.Vehicle == item.Vehicle && dto.Id != item.Id;
				var Inspections = _genericRepository.Get(filter, null, "");
				if (Inspections == null || Inspections.Count() == 0)
				{
                    AccesoParaLugar(token, item);
                    var vehicleTolist = vehicleService.ExistPlate(item.Vehicle.VIN);
					if (vehicleTolist == null)
						throw new VehicleCommissionIsPercentageException(string.Format("El vehiculo '{0}' no existe en  el sistema.", item.Vehicle.VIN));//astul
					if (item.Status == Domain.Enum.InspectionStatus.OK && item.Place == Domain.Enum.InspectionPlace.Puerto)
						vehicleTolist.HistoryState.Add(new State { CurrentDate = DateTime.Now, PlaceInMoment = Domain.Enum.Place.EsperandoParaSalir });

					item.Vehicle = vehicleTolist;
					_genericRepository.Update(item);
					 
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
				var vehilceoutInspection = _genericRepository.GetAll();
				if (Exist(keyValues))
				{
					var InspectionToDamage = GetbyId(keyValues);
                    AccesoParaLugar(token, InspectionToDamage);
                    InspectionToDamage.DamageRegistries.Add(DamageRegistry);
					_genericRepository.Update(InspectionToDamage, InspectionToDamage.Id);
					 
					return;
				}
				throw new InspectionNotFoundException(string.Format("No existe inspecciones con ese id '{0}'.", keyValues[0]));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
		}
	}
}
