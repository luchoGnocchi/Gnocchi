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
using BetizagastiGnocchi.BackEnd.Services.BatchServices;
using BetizagastiGnocchi.BackEnd.Common.Services.General;
using BetizagastiGnocchi.BackEnd.Common.Services.BatchTransport;
using BetizagastiGnocchi.BackEnd.Common.Services.Batch;
using BetizagastiGnocchi.BackEnd.Services.Core.Generics;

namespace BetizagastiGnocchi.BackEnd.Services.BatchTransportServices
{
	public class BatchTransportService : GenericService<BatchTransport>, IBatchTransportService
	{
	 
        private readonly IRepository<BatchTransport> _genericRepository;
        private readonly IUserService userService;
		private readonly IBatchService batchService;
		 

		public BatchTransportService(IRepository<BatchTransport> genericRepository, IUserService userService, IBatchService batchService):base(genericRepository)
		{
            this._genericRepository = genericRepository;
			this.userService = userService;
			this.batchService = batchService;
		}
		public void Add(string token, BatchTransport item)
		{

			if (userService.HasAccess(token, "BatchTransport.Add"))
			{
				List<Batch> batchsToInsert = new List<Batch>();
				foreach (var batchsInstance in item.Batchs)
				{
					var batchTolist = batchService.GetbyId(batchsInstance.Id);
					if (batchTolist == null)
						throw new BatchAlreadyRegisteredException(string.Format("El lote '{0}' no existe en  el sistema.", batchTolist.Name));
					if (batchTolist.BatchTransport != null)
						throw new BatchAlreadyRegisteredException(string.Format("El lote '{0}' ya esta asigando a otro transporte ", batchTolist.Name));

					if (batchTolist.ReadyForTransport())
						throw new BatchTransportWithoutVehicleException(string.Format("No se cumplen las condicciones de inspeccion en los vehiculos para poder ser  transportado."));
					batchsToInsert.Add(batchTolist);
				}
				if (batchsToInsert.Count == 0)
					throw new BatchTransportWithoutVehicleException(string.Format("Debe contener almenos un lote valido para poder ser transportado."));
				item.Batchs = batchsToInsert;
				item.StartDate = new DateTime(1998, 04, 30); 
				item.FinishDate = new DateTime(1998, 04, 30); 
				item.Creator  = userService.GetAll().Where(u => u.Token.ToString() == token).FirstOrDefault();
                _genericRepository.Insert(item);
		 
					return;
				 
				throw new BatchTransportNoReadyToTransportException(string.Format("Existen Vehiculos  vehiculos no listos para ser transportados"));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
		}

		public override void DeleteById(string token, params object[] keyValues)
		{
			if (userService.HasAccess(token, "BatchTransport.DeleteById"))
			{

				if (Exist(keyValues))
				{
                    _genericRepository.Delete(keyValues);
				 
					return;
				}
				throw new BatchTransportNotFoundException(string.Format("El transporte de lote con Id '{0}' no fue encontrado.", keyValues));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}

		public override BatchTransport Update(string token, BatchTransport item)
		{
			if (userService.HasAccess(token, "BatchTransport.UpdateById"))
			{
				Expression<Func<BatchTransport, bool>> filter = dto => dto.Batchs.Any(x => !x.ReadyForTransport());
				var BatchTransports = _genericRepository.Get(filter, null, "");
				if (BatchTransports == null || BatchTransports.Count() == 0)
				{
                    _genericRepository.Update(item, item.Id);
					 
					return item;
				}
				throw new BatchTransportNoAllAlVehiclesReadyException(string.Format("Existen vehiuculos que no estan listos para ser transportados."));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}

		public void AddBatch(string token, Batch batch, params object[] keyValues)
		{
			if (userService.HasAccess(token, "BatchTransport.AddBatch"))
			{

				var batchTransport = _genericRepository.GetByID(keyValues);
				if (batchTransport != null)
					throw new BatchTransportNotFoundException();

				if (!batchTransport.Batchs.Contains(batch))
				{
					if(batchTransport.StartDate!=null)
						throw new BatchTransportNotFoundException(); //cambiar excepcion
					batchTransport.Batchs.Add(batch);
                    _genericRepository.Update(batchTransport, batchTransport.Id);
				
					return;
				}
				throw new BatchAlreadyRegisteredInBatchTransportException();


			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}

		public void StartTravel(string token, params object[] keyValues)
		{
			if (userService.HasAccess(token, "BatchTransport.StrartTravel"))
			{

				var batchTransport = _genericRepository.GetByID(keyValues);
				if (batchTransport == null)
					throw new BatchTransportNotFoundException();
				if (batchTransport.Batchs.Count() > 0)
				{
					 
					batchTransport.StartDate = DateTime.Now;
					batchTransport.StartTravel();
                    batchTransport.Transporter = userService.GetAll().Where(u => u.Token.ToString() == token).FirstOrDefault();
                    _genericRepository.Update(batchTransport, batchTransport.Id);
					return;
				}
				throw new BatchTransportWithEmptyBatchException();

			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}

		public void FinishTravel(string token, params object[] keyValues)
		{
			if (userService.HasAccess(token, "BatchTransport.FinishTravel"))
			{

				var batchTransport = _genericRepository.GetByID(keyValues);
				if (batchTransport == null)
					throw new BatchTransportNotFoundException();
				if (batchTransport.Batchs.Count() > 0)
				{
					if (batchTransport.TravelisStart() && !batchTransport.TravelisFinish())
					{
						batchTransport.FinishDate = DateTime.Now;
						batchTransport.FinishTravel();
                        _genericRepository.Update(batchTransport, batchTransport.Id);
						return;
					}
					throw new StartDateNullorGreaterThanTheDateOfArrivalException();

				}
				throw new BatchTransportWithEmptyBatchException();

			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}
	}
}
