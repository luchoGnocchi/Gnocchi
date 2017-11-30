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
using BetizagastiGnocchi.BackEnd.Services.InspectionService;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;

namespace BetizagastiGnocchi.FrontEnd.WebApi.Controllers
{
    public class InspectionController : ApiController
    {
        private readonly IInspectionService inspectionService;
		private readonly IUserService userService;
		private readonly IVehicleService vehicleService;
		public InspectionController()
        {
            inspectionService = new InspectionService(userService,vehicleService);

		}

			
        public InspectionController(IInspectionService inspectionService, IUserService userService, IVehicleService vehicleService)
        {
            this.inspectionService = inspectionService;
			this.userService = userService;
			this.vehicleService = vehicleService;
        }

        // GET: api/Inspection
        public IHttpActionResult GetAllInspections()
        {

            IEnumerable<object> inspections = inspectionService.GetAll();
            return Ok(inspections);
        }

        // GET: api/Inspection/1
        public IHttpActionResult GetInspectionById(int id)
        {

            var inspection = inspectionService.GetbyId(id);
            return Ok(inspection);
        }

        // PUT: api/Inspection/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInspection(int id, Inspection inspection)
        {
            if (id < 1 || inspection == null)
            {
                return BadRequest(ModelState);
            }

            if (id != inspection.Id)
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
                inspectionService.Update(token, inspection);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }

        }

        // POST: api/Inspection        
        [ResponseType(typeof(Inspection))]
        public IHttpActionResult PostInspection(Inspection inspection)
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
                inspectionService.Add(token, inspection);
                return Ok("inspection creada con exito");
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }

        }

        // DELETE: api/Inspection/5
        [ResponseType(typeof(Inspection))]
        public IHttpActionResult DeleteInspection(int id)
        {
            string token = "";
            if (Request.Headers.Contains("oauth_token"))
            {
                token = Request.Headers.GetValues("oauth_token").First();
            }
            try
            {
                inspectionService.DeleteById(token, id);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("api/Inspection/AddDamage")]
        public HttpResponseMessage AddDamageToInspection(int  inspection, DamageRegistry damage)
        {
            HttpResponseMessage response = null;
            try
            {
                if (ModelState.IsValid)
                {
                    string token = Request.Headers.GetValues("oauth_token").First();
                    inspectionService.AddDamage(token, damage, inspection);
                    response = Request.CreateResponse(HttpStatusCode.Accepted);
                }
                else
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            }
            catch(Exception e)
            {
                return response = new HttpResponseMessage() { Content = new StringContent(e.Message) };
            }
        }
    }
}