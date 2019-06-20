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
    public class ReviewPlaces2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public ReviewPlaces2Controller()
        {

        }

        // GET: api/Users2
        [HttpGet]
        public IEnumerable<ReviewPlace> GetReviewPlace()
        {
            return unit.ReviewPlaceManager.getAll();
        }

        // GET: api/ReviewPlaces/5
        [HttpGet("{id}")]
        public IActionResult GetReviewPlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ReviewPlace = unit.ReviewPlaceManager.getById(id);

            if (ReviewPlace == null)
            {
                return NotFound();
            }

            return Ok(ReviewPlace);
        }


        // GET: api/ReviewPlaces/5
        //this usrl take place id and return reviews of this places
        [HttpGet("[action]/{id}")]
        public IActionResult GetReviewsByPlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ReviewPlace = unit.ReviewPlaceManager.GetReviewsByPlaceId(id);

            if (ReviewPlace == null)
            {
                return NotFound();
            }

            return Ok(ReviewPlace);
        }
        // PUT: api/ReviewPlaces/5
        [HttpPut("{id}")]
        public IActionResult PutReviewPlace([FromRoute] int id, [FromBody] ReviewPlace reviewplace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reviewplace.ReviewId)
            {
                return BadRequest();
            }


            bool test = true;
            try
            {
                test = unit.ReviewPlaceManager.Update(reviewplace);
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

        // POST: api/reviewplaces
        [HttpPost]
        public IActionResult Postreviewplaces([FromBody] ReviewPlace reviewplace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ReviewPlace rp = unit.ReviewPlaceManager.Insert(reviewplace);
            return CreatedAtAction("GetGame", new { id = rp.ReviewId }, rp);
        }

        // DELETE: api/reviewplaces/5
        [HttpDelete("{id}")]
        public IActionResult DeletePlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewplace = unit.ReviewPlaceManager.getById(id);
            if (reviewplace == null)
            {
                return NotFound();
            }

            unit.ReviewPlaceManager.Delete(reviewplace);


            return Ok(reviewplace);
        }
    }
}