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
using BetizagastiGnocchi.BackEnd.Services.ZoneServices;

namespace BetizagastiGnocchi.FrontEnd.WebApi.Controllers
{
	public class ZoneController : ApiController
	{
		private readonly IZoneService ZoneService;
		private readonly IUserService userService;
		public ZoneController()
		{


			ZoneService = new ZoneService(userService);
		}

		public ZoneController(IZoneService ZoneService)
		{
			this.ZoneService = ZoneService;
		}

		// GET: api/Zone
		public IHttpActionResult GetAllZones()
		{

			IEnumerable<object> Zonees = ZoneService.GetAll();
			return Ok(Zonees);
		}

		// GET: api/Zone/1
		public IHttpActionResult GetZoneById(int id)
		{

			var Zone = ZoneService.GetbyId(id);
			return Ok(Zone);
		}

		// PUT: api/Zone/5
		[ResponseType(typeof(void))]
		public IHttpActionResult PutZone(int id, Zone Zone)
		{
			if (id < 1 || Zone == null)
			{
				return BadRequest(ModelState);
			}

			if (id != Zone.Id)
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
				ZoneService.Update(token, Zone);
				return StatusCode(HttpStatusCode.NoContent);
			}
			catch (Exception e)
			{
				return Ok(e.Message);
			}
		}

		// POST: api/Zone        
		[ResponseType(typeof(Zone))]
		public IHttpActionResult PostZone(Zone Zone)
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
				ZoneService.Add(token, Zone);
				return Ok("lote creado con exito");
			}
			catch (Exception e)
			{
				return Ok(e.Message);
			}

		}

		// DELETE: api/Zone/5
		[ResponseType(typeof(Zone))]
		public IHttpActionResult DeleteZone(int id)
		{
			string token = "";
			if (Request.Headers.Contains("oauth_token"))
			{
				token = Request.Headers.GetValues("oauth_token").First();
			}
			try
			{
				ZoneService.DeleteById(token, id);

			}
			catch (Exception e)
			{
				return Ok(e.Message);
			}
			return StatusCode(HttpStatusCode.NoContent);
		}

		[HttpPost]
		[Route("api/Zone/AddVehicle")]
		public HttpResponseMessage AddVehicleToZone(Zone Zone, Vehicle vehicle)
		{
			HttpResponseMessage response = null;
			try
			{
				if (ModelState.IsValid)
				{
					string token = Request.Headers.GetValues("oauth_token").First();
					ZoneService.AddVehicle(token, vehicle, Zone.Id);
					response = Request.CreateResponse(HttpStatusCode.Accepted);
				}
				else
				{
					response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
				}
				return response;
			}
			catch (Exception e)
			{
				return response = new HttpResponseMessage() { Content = new StringContent(e.Message) };
			}

		}
	}
}