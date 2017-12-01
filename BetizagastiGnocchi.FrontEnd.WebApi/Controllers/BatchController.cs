using BetizagastiGnocchi.BackEnd.DAL;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.UserService;
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
using BetizagastiGnocchi.BackEnd.Services.BatchServices;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;

namespace BetizagastiGnocchi.FrontEnd.WebApi.Controllers
{
    public class BatchController : ApiController
    {
        private readonly IBatchService batchService;
        private readonly IUserService userService;
        private readonly IVehicleService vehicleService;


        public BatchController(IUserService userService, IBatchService batchService, IVehicleService vehicleService)
        {
            this.userService = userService;
            this.batchService = batchService;
            this.vehicleService = vehicleService;
        }

        // GET: api/Batch
        public IHttpActionResult GetAllBatchs()
        {
            IEnumerable<object> batches = batchService.GetAll();
            return Ok(batches);
        }

        // GET: api/Batch/1
        public IHttpActionResult GetBatchById(int id)
        {

            var batch = batchService.GetbyId(id);
            return Ok(batch);
        }

        // PUT: api/Batch/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBatch(int id, Batch batch)
        {
            if (id < 1 || batch == null)
            {
                return BadRequest(ModelState);
            }

            if (id != batch.Id)
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
                batchService.Update(token, batch);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }
        }

        // POST: api/Batch        
        [ResponseType(typeof(Batch))]
        public IHttpActionResult PostBatch(Batch batch)
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
                batchService.Add(token, batch);
                return Ok("lote creado con exito");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }

        }

        // DELETE: api/Batch/5
        [ResponseType(typeof(Batch))]
        public IHttpActionResult DeleteBatch(int id)
        {
            string token = "";
            if (Request.Headers.Contains("oauth_token"))
            {
                token = Request.Headers.GetValues("oauth_token").First();
            }
            try
            {
                batchService.DeleteById(token, id);
                return Ok("lote eliminado con exito");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }

        }

        [Route("api/AddVehicle")]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult PutVehicleToBatch(int Idbatch, Vehicle vehicle)
        {
            HttpResponseMessage response = null;
            try
            {
                if (ModelState.IsValid)
                {
                    string token = Request.Headers.GetValues("oauth_token").First();
                    batchService.AddVehicle(token, vehicle, Idbatch);
                    response = Request.CreateResponse(HttpStatusCode.Accepted);
                    return Ok("Vehiculo agregado a lote con exito");
                }
                else
                {
                    return Content(HttpStatusCode.ExpectationFailed, "fallas en el modelo");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }

        }
    }
}