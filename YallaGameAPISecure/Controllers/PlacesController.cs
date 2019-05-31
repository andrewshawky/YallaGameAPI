using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Models.Repositories;

namespace YallaGameAPISecure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IModelRepositery<Place> context;

        public PlacesController(IModelRepositery<Place> context)
        {
            this.context = context;
        }

        // GET: api/Places
        [HttpGet]
        public List<Place> GetPlace()
        {
            List<Place> places = context.getAll();
            return places;
        }

        // GET: api/Places/5
        [HttpGet("{id}")]
        public IActionResult GetPlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var place = context.getById(id);

            if (place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutUser([FromRoute] int id, [FromBody] Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != place.PlaceId)
            {
                return BadRequest();
            }

            context.Update(place);

            try
            {
                context.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!context.ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/places
        [HttpPost]
        public IActionResult PostUser([FromBody] Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Insert(place);
            context.Save();
            return CreatedAtAction("GetUser", new { id = place.PlaceId }, place);
        }

        // DELETE: api/places/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var place = context.getById(id);
            if (place == null)
            {
                return NotFound();
            }

            context.Delete(id);
            context.Save();

            return Ok(place);
        }
    }
}