using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.unitofwork;

namespace YallaGameAPISecure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Places2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public Places2Controller()
        {
            
        }

        // GET: api/Users2
        [HttpGet]
        public IEnumerable<Place> GetPlace()
        {
            return unit.PlaceManager.getAll();
        }

        // GET: api/Users/5
        //send id of place and return specific data of this place  

        [HttpGet("{id}")]
        public IActionResult GetPlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var place = unit.PlaceManager.getPlaceDtoId(id);

            if (place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutPlace([FromRoute] int id, [FromBody] Place place)
        {
            place.PlaceId = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != place.PlaceId)
            {
                return BadRequest();
            }

           
            bool test = true;
            try
            {
                test = unit.PlaceManager.Updatev1(place);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (test == false)
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

        // POST: api/Users
        [HttpPost]
        public IActionResult PostPlace([FromBody] Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Place p = unit.PlaceManager.Insert(place);
            return Created("GetUser",  p);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeletePlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var place = unit.PlaceManager.getById(id);
            if (place == null)
            {
                return NotFound();
            }

            unit.PlaceManager.Delete(place);


            return Ok(place);
        }

        // GET: api/Users/cairo
        [HttpGet("[action]/{id}")]
        public IActionResult GetPlaces([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Place> places = unit.PlaceManager.GetByCity(id);

            if (places == null)
            {
                return NotFound();
            }

            return Ok(places);
        }
    }
}