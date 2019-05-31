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
    public class ImageOfPlaces2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public ImageOfPlaces2Controller()
        {

        }

        // GET: api/ImageOfPlaces
        [HttpGet]
        public IEnumerable<ImageOfPlace> GetImageOfPlace()
        {
            return unit.ImageOfPlaceManager.getAll();
        }

        // GET: api/ImageOfPlaces/5/6
        [HttpGet("{imageofplaceid}/{placeid}")]
        public IActionResult GetImageOfPlace([FromRoute] int imageofplaceid, [FromRoute]int placeid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ImageOfPlace = unit.ImageOfPlaceManager.findbytwoid(imageofplaceid, placeid);

            if (ImageOfPlace == null)
            {
                return NotFound();
            }

            return Ok(ImageOfPlace);
        }

        // PUT: api/ImageOfPlaces/5/6
        [HttpPut("{imageofplaceid}/{placeid}")]
        public IActionResult PutGame([FromRoute] int imageofplaceid, [FromRoute] int placeid, [FromBody] ImageOfPlace ImageOfPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (imageofplaceid != ImageOfPlace.ImageOfPlaceId || placeid != ImageOfPlace.PlaceId)
            {
                return BadRequest();
            }
            ImageOfPlace.ImageOfPlaceId = imageofplaceid;
            ImageOfPlace.PlaceId = placeid;

            bool test = true;
            try
            {
                test = unit.ImageOfPlaceManager.Update(ImageOfPlace);
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

        // POST: api/ImageOfPlaces/5/6
        [HttpPost("{imageofplaceid}/{placeid}")]
        public IActionResult PostImageOfPlace([FromRoute] int imageofplaceid, [FromRoute] int placeid, [FromBody] ImageOfPlace ImageOfPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ImageOfPlace.PlaceId = placeid;
            ImageOfPlace.ImageOfPlaceId = imageofplaceid;
            ImageOfPlace g = unit.ImageOfPlaceManager.Insert(ImageOfPlace);
            return CreatedAtAction("GetGameInPlace", new { placeid, imageofplaceid }, g);
        }

        // DELETE: api/ImageOfPlaces/5/6
        [HttpDelete("{imageofplaceid}/{placeid}")]
        public IActionResult DeleteImageOfPlace([FromRoute] int imageofplaceid, [FromRoute] int placeid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ImageOfPlace = unit.ImageOfPlaceManager.findbytwoid(imageofplaceid, placeid);
            if (ImageOfPlace == null)
            {
                return NotFound();
            }

            unit.ImageOfPlaceManager.Delete(ImageOfPlace);


            return Ok(ImageOfPlace);
        }
    }
}