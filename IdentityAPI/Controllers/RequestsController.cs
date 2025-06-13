﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Identity.Service;
using IdentityAPI.Model;
using IdentityAPI.Services.Interfaces;

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
       //[HttpGet]
       // public async Task<ActionResult<IEnumerable<Request>>> GetRequest()
       // {
       //     return await _context.Request.ToListAsync();
       // }

        //// GET: api/Requests/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Request>> GetRequest(int id)
        //{
        //    var request = await _context.Request.FindAsync(id);

        //    if (request == null)
        //    {
        //        return NotFound();
        //    }

        //    return request;
        //}

        //// PUT: api/Requests/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRequest(int id, Request request)
        //{
        //    if (id != request.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(request).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RequestExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Requests
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Request>> PostRequest(Request request)
        //{
        //    _context.Request.Add(request);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        //}

        //// DELETE: api/Requests/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRequest(int id)
        //{
        //    var request = await _context.Request.FindAsync(id);
        //    if (request == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Request.Remove(request);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

    }
}
