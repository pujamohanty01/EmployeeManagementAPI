using Microsoft.AspNetCore.Mvc;
using Employeemanagement.Service;
using Employeemanagement.Model;
using Employeemanagement.Data;

namespace Employeemanagement.Controller
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly JwtTokenHandler jwtTokenHandler;
        private readonly IUserService userService;
        public UserController(IUserService _userService, JwtTokenHandler _jwtTokenHandler)
        {
            userService = _userService;
            this.jwtTokenHandler = _jwtTokenHandler;
         
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
            if(data is null){
                return Unauthorized();
            }
            data.Password = jwtTokenHandler.GeneratJwtToken(data);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            bool IsUserExist = userService.CheckUserExists(user);
            if (!IsUserExist)
            {
                var data = userService.AddUser(user);
                return Created("", data);
            }
            //Status code 409 conflict
            return Conflict("User already exist");

        }
        [HttpPatch("Update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            User existingUser = userService.GetUserById(user.Id);
            if (existingUser is null)
            {
                return NotFound();
            }
            existingUser.EmailId = user.EmailId;
            existingUser.Name = user.Name;
            existingUser.Password = user.Password;
            existingUser.Role = user.Role;
            User result = userService.UpdateUser(existingUser);
            return Ok(result);
        }

        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteUserById(string Id)
        {
            int userId = Convert.ToInt16(Id);
            User existingUser = userService.GetUserById(userId);
            if (existingUser is null)
            {
                return NotFound();
            }
            User result = userService.DeleteUser(existingUser);
            return Ok(result);
        }
       

    }
}