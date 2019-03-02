using System;
using System.Web.Helpers;
using System.Web.Http;
using SensorAPI.Models;
using SensorAPI.Repositories;

namespace SensorAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("headsup/user/postuser/{userId}/{name}/{info}")]
        [HttpPost]
        public IHttpActionResult PostUser(string userId, string name, string info)
        {
            UserEntity model;
            try
            {
                model = _userRepository.InsertUser(userId, name, info);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
           return Ok(model);
        }  

        [Route("headsup/user/getuser/{userId}/{name}")]
        [HttpGet]
        public IHttpActionResult GetUser(string userId, string name)
        {
            var data = _userRepository.GetUser(userId, name);
            try
            {
                data = _userRepository.GetUser(userId, name);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Ok(data);
        }
    }
}