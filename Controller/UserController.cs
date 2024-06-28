using Microsoft.AspNetCore.Mvc;
using Employeemanagement.Service;
using Employeemanagement.Model;

namespace Employeemanagement.Controller
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers()
        {
            var data = userService.GetAllUsers();
            return Ok(data);
        }

        [HttpGet("GetUserById/{Id}")]
        public IActionResult GetUserById(string Id)
        {
            int userId = Convert.ToInt16(Id);
            var data = userService.GetUserById(userId);
            return Ok(data);
        }

        [HttpGet("LogIn/{userName}/{password}")]
        public IActionResult LogIn(string userName, string password)
        {
            var data = userService.VerifyCredential(userName, password);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            bool IsUserExist = userService.CheckUserExists(user);
            if(!IsUserExist)
            {
                var data = userService.AddUser(user);
                return Created("", data);
            }
            //Status code 409 conflict
            return Conflict("User already exist");

        }

    }
}