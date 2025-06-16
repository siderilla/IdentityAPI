using Identity.Service;
using Identity.Service.Model;
using IdentityAPI.Model.DTOs;
using IdentityAPI.Model.ViewModels;
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
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _service;
        private readonly ILogger<RequestsController> _logger;

        public RequestsController(IRequestService service, ILogger<RequestsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        //GET: api/Requests
       [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestViewModel>>> GetRequest()
        {
            _logger.LogInformation("Fetching all requests from the database.");
            var requests = await _service.GetRequests();
            if (requests == null)
            {
                return NotFound();
            }
            return Ok(requests);
        }

        //// GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestViewModel>> GetRequest(int id)
        {
            _logger.LogInformation($"Fetching request with ID {id} from the database.");
            var request = await _service.GetRequest(id);
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        //// PUT: api/Requests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, [FromBody] RequestUpdateDTO request)
        {
            _logger.LogInformation($"Updating request with ID {id}.");
            var result = await _service.UpdateRequest(id, request);
            if (result == null)
            {
                return BadRequest("Request ID mismatch.");
            }
            return NoContent();
        }

        //// POST: api/Requests
        [HttpPost]
        public async Task<IActionResult> PostRequest([FromBody] RequestCreateDTO request)
        {
            _logger.LogInformation("Creating a new request.");
            if (request == null)
            {
                return BadRequest("Request data is null.");
            }
            var requestId = await _service.PostRequest(request);
            if (requestId == null)
            {
                return BadRequest("Invalid request data.");
            }
            return Created("api/Requests/" + requestId, request);
        }

        //// DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest([FromRoute] int id)
        {
            _logger.LogInformation($"Deleting request with ID {id}.");
            var result = await _service.DeleteRequest(id);
            if (result == null)
            {
                return BadRequest("Request not found.");
            }
            return Ok(result);
        }

    }
}
