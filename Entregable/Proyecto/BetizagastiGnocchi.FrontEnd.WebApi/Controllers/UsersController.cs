using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.UserService;
using System;
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



namespace BetizagastiGnocchi.FrontEnd.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController()
        {
            userService = new UserService();
        }

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/Users
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                IEnumerable<object> users = userService.GetAll();
                return Ok(users);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        // GET: api/Users/1
        public IHttpActionResult GetUserById(int id)
        {
            try
            {
                var user = userService.GetbyId(id);
                return Ok(user);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }

        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (id < 1 || user == null)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
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
                if (!userService.UpdateById(token, id, user))
                {
                    return NotFound();
                }
                return StatusCode(HttpStatusCode.NoContent);
            }catch(Exception e)
            {
                return Ok(e.Message);
            }
            
        }

        // POST: api/Users        
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
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
                int idUser = userService.CreateUser(token, user);
                return CreatedAtRoute("DefaultApi", new { id = user.Id },
                    new { user.Token });
            }catch(Exception e)
            {
                return Ok(e.Message);
            }
            
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            string token = "";
            if (Request.Headers.Contains("oauth_token"))
            {
                token = Request.Headers.GetValues("oauth_token").First();
            }
            try
            {
                if (userService.DeleteById(token, id))
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage PostLogin(User userData)
        {
            HttpResponseMessage response = null;
            try
            {
                if (ModelState.IsValid)
                {
                    string token = "";

                    token = userService.Login(userData.UserName, userData.Password);
                    response = Request.CreateResponse(new { token });
                }
                else
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            }catch(Exception e)
            {
                return response = new HttpResponseMessage() { Content = new StringContent(e.Message) };
            }
            
        }
    }
}