using BetizagastiGnocchi.BackEnd.DAL;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.UserService;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System;

namespace BetizagastiGnocchi.FrontEnd.WebApi.Controllers
{
    public class VehicleController : ApiController
    {
        private readonly IVehicleService vehicleService;
		private readonly IUserService userService;

		public VehicleController()
        {
            vehicleService = new VehicleService(userService);
        }

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        // GET: api/Vehicle
        public IHttpActionResult GetAllVehicles()
        {

            IEnumerable<object> vehicles = vehicleService.GetAll();
            return Ok(vehicles);
        }

        // GET: api/Vehicle/1
        public IHttpActionResult GetVehicleById(int id)
        {

            var vehicle = vehicleService.GetbyId(id);
            return Ok(vehicle);
        }
		// GET: api/Vehicle/1
		[Route("api/VehicleByVim")]
		[ResponseType(typeof(Vehicle))]
		public IHttpActionResult GetVehicleByVIM(string VIM)
		{

			var vehicle = vehicleService.ExistPlate(VIM);
		
			return Ok(vehicle);
		}
		// PUT: api/Vehicle/5
		[ResponseType(typeof(void))]
        public IHttpActionResult PutVehicle(int id, Vehicle vehicle)
        {
            if (id < 1 || vehicle == null)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle.Id)
            {
                return BadRequest();
            }
            string token = "";
            if (Request.Headers.Contains("oauth_token"))
            {
                token = Request.Headers.GetValues("oauth_token").First();
            }

            try
            {
                vehicleService.Update(token, vehicle);
                return StatusCode(HttpStatusCode.NoContent);
            }catch(Exception e)
            {
                return Ok(e.Message);
            }
        }

        // POST: api/Vehicle        
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string token = "";
            if (Request.Headers.Contains("oauth_token"))
            {
                token = Request.Headers.GetValues("oauth_token").First();
            }
            try
            {
                vehicleService.Add(token, vehicle);
                return Ok("vehiculo creado con exito");
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        // DELETE: api/Vehicle/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult DeleteVehicle(int id)
        {
            string token = "";
            if (Request.Headers.Contains("oauth_token"))
            {
                token = Request.Headers.GetValues("oauth_token").First();
            }
            try
            {
                vehicleService.DeleteById(token, id);

            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}