using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Domain.Enum;
using BetizagastiGnocchi.BackEnd.Services.BatchServices;
using BetizagastiGnocchi.BackEnd.Services.UserService;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BetizagastiGnocchi.FrontEnd.WebApi.Controllers
{
	public class ValuesController : ApiController
	{
		private readonly IUserService _userService;
		private readonly IVehicleService _vehicleService;
		private readonly IBatchService _batchService;

		public ValuesController(IUserService userService, IVehicleService vehicleService, IBatchService batchService )
		{
			_userService = userService;
			_vehicleService = vehicleService;
			_batchService = batchService;
		}

		// GET api/values
		public string Get()
		{
			try
			{
                UserRol rolo = new UserRol { UType = UserType.Admin };
                rolo.ActionOperations.Add(new ActionOperation { Name = "Vehicle.Add" });

                rolo.ActionOperations.Add(new ActionOperation { Name = "Batch.Add" });

                rolo.ActionOperations.Add(new ActionOperation { Name = "Batch.AddVehicle" });

                _userService.CreateUser("xxxx", new User { UserName = "Lucho", Token = new Guid(), Salt = "xxx", Password = "lucho123", Rol = rolo });
                var user = _userService.GetbyId(1);
                
            }
			catch (Exception ex)
			{
				return ex.Message;
			}
			return "ok";
		}

		// GET api/values/5
		public string Get(int id)

		{
			try
			{
				//var user = _userService.GetbyId(id);
				//	var batch = new Batch
				//	{
				//		Creator = user,
				//		Description = "lolo",
				//		Name = "batch 12"
				//	};
				//             //	VehicleService
				var vehicle = new Vehicle
				{
					//Batch = batch,
					Brand = "brauuund1",
					Color = "reuud1",
					Model = "ecuuosport1",
					VehicleType = "fuuord1",
					VIN = "viuun126",
					Year = 20917
				};
				_vehicleService.Add("09FFD4A8-CC48-4DE9-8335-9D9700E881D7", vehicle);
				//	// batch.Vehicles.Add(_vehicleService.GetbyId(2));
				////	_vehicleService.Add( user.Token.ToString(),vehicle);
				//	//_batchService.Add(user.Token.ToString(),batch);
				//	var xop = _vehicleService.GetbyId(1);
				//	_batchService.AddVehicle(user.Token.ToString(), xop, 1);

				// //            batch.Vehicles.Add(_vehicleService.GetbyId(1));
				//	//var x = _vehicleService.GetbyId(1);

				// //            //_vehicleService.Update(user.Token.ToString(), x);

				//   var popi=  _batchService.GetbyId(1);
				//_batchService.Add(user.Token.ToString(), batch);
				//	string token = _userService.Login("Lucho", "lucho123");
			}
			catch (Exception ex)
			{

				return ex.Message;
			}
		
			return "ok";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
