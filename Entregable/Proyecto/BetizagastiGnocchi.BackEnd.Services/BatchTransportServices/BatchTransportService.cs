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

namespace BetizagastiGnocchi.BackEnd.Services.BatchTransportServices
{
	public class BatchTransportService : IBatchTransportService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IUserService userService;
		private readonly IBatchService batchService;
		public BatchTransportService(IUnitOfWork unitOfWork, IUserService userService)
		{
			this.unitOfWork = unitOfWork;
			this.userService = userService;
		}

		public BatchTransportService(IUserService userService, IBatchService batchService)
		{
			this.unitOfWork = new UnitOfWork();
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
						throw new BatchAlreadyRegisteredException(string.Format("El lote '{0}' no existe en  el sistema.", batchsInstance.Name));
					if (batchTolist.BatchTransport != null)
						throw new BatchAlreadyRegisteredException(string.Format("El lote '{0}' ya esta asigando a otro lote para trasladar ", batchsInstance.Name));

					if (batchTolist.ReadyForTransport())
						throw new BatchTransportWithoutVehicleException(string.Format("No se cumplen las condicciones de inspeccion en los vehiculos para poder ser  transportado."));
					batchsToInsert.Add(batchsInstance);
				}
				if (batchsToInsert.Count == 0)
					throw new BatchTransportWithoutVehicleException(string.Format("Debe contener almenos un lote valido para poder ser transportado."));
				item.Batchs = batchsToInsert;
				item.StartDate = new DateTime(1998, 04, 30); 
				item.FinishDate = new DateTime(1998, 04, 30); 
				item.Transporter  = unitOfWork.UserRepository.GetAll().Where(u => u.Token.ToString() == token).FirstOrDefault(); 
				unitOfWork.BatchTransportRepository.Insert(item);
					unitOfWork.Save();
					return;
				 
				throw new BatchTransportNoReadyToTransportException(string.Format("Existen Vehiculos  vehiculos no listos para ser transportados"));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
		}

		public void DeleteById(string token, params object[] keyValues)
		{
			if (userService.HasAccess(token, "BatchTransport.DeleteById"))
			{

				if (Exist(keyValues))
				{
					unitOfWork.BatchTransportRepository.Delete(keyValues);
					unitOfWork.Save();
					return;
				}
				throw new BatchTransportNotFoundException(string.Format("El transporte de lote con Id '{0}' no fue encontrado.", keyValues));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}

		public bool Exist(params object[] keyValues)
		{
			BatchTransport BatchTransport = unitOfWork.BatchTransportRepository.GetByID(keyValues[0]);
			return BatchTransport != null;
		}

		public ICollection<BatchTransport> GetAll()
		{
			return unitOfWork.BatchTransportRepository.GetAll().ToList();
		}

		public BatchTransport GetbyId(params object[] keyValues)
		{
			return unitOfWork.BatchTransportRepository.GetByID(keyValues[0]);
		}

		public BatchTransport Update(string token, BatchTransport item)
		{

			if (userService.HasAccess(token, "BatchTransport.UpdateById"))
			{
				Expression<Func<BatchTransport, bool>> filter = dto => dto.Batchs.Any(x => !x.ReadyForTransport());
				var BatchTransports = unitOfWork.BatchTransportRepository.Get(filter, null, "");
				if (BatchTransports == null || BatchTransports.Count() == 0)
				{
					unitOfWork.BatchTransportRepository.Update(item, item.Id);
					unitOfWork.Save();
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

				var batchTransport = unitOfWork.BatchTransportRepository.GetByID(keyValues);
				if (batchTransport != null)
					throw new BatchTransportNotFoundException();

				if (!batchTransport.Batchs.Contains(batch))
				{
					
					batchTransport.Batchs.Add(batch);
					unitOfWork.BatchTransportRepository.Update(batchTransport, batchTransport.Id);
					unitOfWork.Save();
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

				var batchTransport = unitOfWork.BatchTransportRepository.GetByID(keyValues);
				if (batchTransport == null)
					throw new BatchTransportNotFoundException();
				if (batchTransport.Batchs.Count() > 0)
				{

					batchTransport.StartDate = DateTime.Now;
					unitOfWork.BatchTransportRepository.Update(batchTransport, batchTransport.Id);
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

				var batchTransport = unitOfWork.BatchTransportRepository.GetByID(keyValues);
				if (batchTransport != null)
					throw new BatchTransportNotFoundException();
				if (batchTransport.Batchs.Count() > 0)
				{
					if (batchTransport.StartDate != null && batchTransport.StartDate < DateTime.Now)
					{
						batchTransport.FinishDate = DateTime.Now;
						unitOfWork.BatchTransportRepository.Update(batchTransport, batchTransport.Id);
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
