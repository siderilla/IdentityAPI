using Identity.Service;
using IdentityAPI.Model;
using IdentityAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _service;
        private readonly ILogger<RolesController> _logger;
        public RolesController(IRoleService service, ILogger<RolesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        //// GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            _logger.LogInformation("Fetching all roles from the database.");
            var roles = await _service.GetRoles();
            if (roles == null)
            {
                return NotFound();
            }
            return Ok(roles);
        }

        //// GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            _logger.LogInformation($"Fetching role with ID {id} from the database.");
            var role = await _service.GetRole(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        //// PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] Role role)
        {
            _logger.LogInformation($"Updating role with ID {id}.");
            var result = await _service.UpdateRole(id, role);
            if (result == null)
            {
                return BadRequest();
            }
            return NoContent();

        }

        //// POST: api/Roles
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Role>> PostRole(Role role)
        //{
        //    _context.Role.Add(role);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRole", new { id = role.Id }, role);
        //}

        //// DELETE: api/Roles/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRole(int id)
        //{
        //    var role = await _context.Role.FindAsync(id);
        //    if (role == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Role.Remove(role);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool RoleExists(int id)
        //{
        //    return _context.Role.Any(e => e.Id == id);
        //}
    }
}
