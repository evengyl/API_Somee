using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.Repository;
using ApiCoreForSomee.Services;
using Models = DAL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCoreForSomee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IApiControllerUse _apiController;
        public UserController(IApiControllerUse apiController)
        {
            _apiController = apiController;
        }
        

        // GET: api/<User>
        [HttpGet]
        public IEnumerable<Models.User> Get()
        {
            return _apiController.GetAll();
        }

        // POST api/user/verifyEmail
        [HttpPost("verifyEmail")]
        public int VerifyEmail([FromBody] Models.User user)
        {
            return _apiController.VerifyEmail(user.Email);
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public Models.User Get(int id)
        {
            return _apiController.Get(id);
        }

        // POST api/<User>
        [HttpPost]
        public void Post([FromBody] Models.User user)
        {
            _apiController.Create(user);
        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Models.User user)
        {
            user.UserId = id;
            _apiController.Update(user);
        }

        // DELETE api/<User>/desactivate/5
        [HttpGet("desactivate/{id}")]
        public void desactivate(int id)
        {
            _apiController.DesactivateUser(id);
        }


        // DELETE api/<User>/activate/5
        [HttpGet("activate/{id}")]
        public void activate(int id)
        {
            _apiController.ActivateUser(id);
        }
    }
}
