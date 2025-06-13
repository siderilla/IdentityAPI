using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Identity.Service;
using Identity.Service.Model;
using IdentityAPI.Services.Interfaces;
using IdentityAPI.Model.DTOs;
using IdentityAPI.Model.ViewModels;

namespace IdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService service, ILogger<UsersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            _logger.LogInformation("Fetching all users from the database.");
            var users = await _service.GetUsers();
            if (users == null || !users.Any())
            {
                return NotFound();
            }
            return Ok(users);

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            _logger.LogInformation($"Fetching user with ID {id} from the database.");
            var user = await _service.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //PUT (update): api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO user)
        {
            _logger.LogInformation($"Updating user with ID {id}.");
            var result = await _service.UpdateUser(id, user);
            if (result == null)
            {
                return BadRequest("User ID mismatch or user not found.");
            }
            return NoContent();

        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserCreateDTO user)
        {
            _logger.LogInformation("Creating a new user.");
            var userId = await _service.PostUser(user);
            if (userId == null)
            {
                return BadRequest("Invalid user data.");
            }
            return Created("api/Users/" + userId, userId);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            _logger.LogInformation($"Deleting user with ID {id}.");
            int? result = await _service.DeleteUser(id);
            if (result == null)
            {
                return BadRequest("The user doesn't exist");
            }
            return Ok(result);
        }
    }
}
