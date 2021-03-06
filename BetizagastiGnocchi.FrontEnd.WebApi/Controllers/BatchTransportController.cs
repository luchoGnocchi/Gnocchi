﻿using BetizagastiGnocchi.BackEnd.DAL;
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
using BetizagastiGnocchi.BackEnd.Services.BatchTransportServices;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;
using BetizagastiGnocchi.BackEnd.Services.BatchServices;

namespace BetizagastiGnocchi.FrontEnd.WebApi.Controllers
{
    public class BatchTransportController : ApiController
    {
        private readonly IBatchTransportService batchTransportService;
        private readonly IUserService userService;
        private readonly IVehicleService vehicleService;
        private readonly IBatchService batchService;




        public BatchTransportController(IBatchTransportService batchTransportService, IVehicleService vehicleService, IUserService _userService, IBatchService batchService)
        {
            this.batchTransportService = batchTransportService;
            this.vehicleService = vehicleService;
            this.userService = _userService;
            this.batchService = batchService;
        }

        // GET: api/BatchTransport
        public IHttpActionResult GetAllBatchTransports()
        {

            IEnumerable<object> batchTransportes = batchTransportService.GetAll();
            return Ok(batchTransportes);
        }

        // GET: api/BatchTransport/1
        public IHttpActionResult GetBatchTransportById(int id)
        {

            var batchTransport = batchTransportService.GetbyId(id);
            return Ok(batchTransport);
        }

        // PUT: api/BatchTransport/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBatchTransport(int id, BatchTransport batchTransport)
        {
            if (id < 1 || batchTransport == null)
            {
                return BadRequest(ModelState);
            }

            if (id != batchTransport.Id)
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
                batchTransportService.Update(token, batchTransport);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }
        }

        // POST: api/BatchTransport        
        [ResponseType(typeof(BatchTransport))]
        public IHttpActionResult PostBatchTransport(BatchTransport batchTransport)
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
                batchTransportService.Add(token, batchTransport);
                return Ok("lote a transportar creado con exito");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }

        }

        // DELETE: api/BatchTransport/5
        [ResponseType(typeof(BatchTransport))]
        public IHttpActionResult DeleteBatchTransport(int id)
        {
            string token = "";
            if (Request.Headers.Contains("oauth_token"))
            {
                token = Request.Headers.GetValues("oauth_token").First();
            }
            try
            {
                batchTransportService.DeleteById(token, id);

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("api/StartTransport")]
        [ResponseType(typeof(Vehicle))]
        [HttpPost]
        public IHttpActionResult PutStarBatchTransport(int IdbatchTransport)
        {
            HttpResponseMessage response = null;
            try
            {
                if (ModelState.IsValid)
                {
                    string token = Request.Headers.GetValues("oauth_token").First();
                    batchTransportService.StartTravel(token, IdbatchTransport);
                    response = Request.CreateResponse(HttpStatusCode.Accepted);
                    return Content(HttpStatusCode.OK, "Se ha comenzado el viaje");
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "modelo invalido");
                    // response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

            }
            catch (Exception e)
            {
                //	return response = new HttpResponseMessage() { Content = new StringContent(e.Message) };
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }
        }
        [Route("api/FinshiTransport")]
        [ResponseType(typeof(Vehicle))]
        [HttpPost]
        public IHttpActionResult PutFinshBatchTransport(int IdbatchTransport)
        {
            HttpResponseMessage response = null;
            try
            {
                if (ModelState.IsValid)
                {
                    string token = Request.Headers.GetValues("oauth_token").First();
                    batchTransportService.FinishTravel(token, IdbatchTransport);
                    return Content(HttpStatusCode.OK, "Se ha finalizado el viaje");
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "modelo invalido");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }
        }
        [Route("api/AddBatchToTransport")]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult PutAddBatchToBatchTransport(int IdbatchToTransport, Batch batch)
        {
            HttpResponseMessage response = null;
            try
            {
                if (ModelState.IsValid)
                {
                    string token = Request.Headers.GetValues("oauth_token").First();
                    batchTransportService.AddBatch(token, batch, IdbatchToTransport);
                    return Content(HttpStatusCode.OK, "Se ha finalizado el viaje");
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "modelo invalido");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, e.Message);
            }

        }
    }
}