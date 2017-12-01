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



        public VehicleController(IVehicleService vehicleService, IUserService userService)
        {
            this.vehicleService = vehicleService;
            this.userService = userService;
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
        [Route("api/vehicle/VehicleByVIN")]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicleByVIN(string VIN)
        {

            var vehicle = vehicleService.ExistPlate(VIN);

            if (vehicle == null)
                return Content(HttpStatusCode.ExpectationFailed, "No se encontramos ese vehiculo :(");
            return Ok(vehicle);

        }

        [Route("api/vehicle/GetVehicleOutBatch")]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicleOutBatch()
        {

            var vehicle = vehicleService.GetVehicleOutBatch();

            return Ok(vehicle);
        }

        [Route("api/vehicle/GetVehicleReadyToSell")]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicleReadyToSell()
        {

            var vehicle = vehicleService.GetVehicleReadyToSell();

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
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
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
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
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
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("api/vehicle/sell")]
        public IHttpActionResult sellVehicle(string VIN, Sell toSell)
        {
            string token = "";
            if (Request.Headers.Contains("oauth_token"))
            {
                token = Request.Headers.GetValues("oauth_token").First();
            }
            try
            {
                if (vehicleService.sell(VIN, toSell))
                {
                    return Ok("vehiculo vendido con exito");
                }
                return Content(HttpStatusCode.BadRequest, "llamado invalido");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }

        }

    }
}