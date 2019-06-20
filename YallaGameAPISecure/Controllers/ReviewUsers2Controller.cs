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
    public class ReviewUsers2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public ReviewUsers2Controller()
        {

        }

        // GET: api/Users2
        [HttpGet]
        public IEnumerable<ReviewUser> GetReviewUser()
        {
            return unit.ReviewUserManager.getAll();
        }

        // GET: api/ReviewUsers/5
        [HttpGet("{id}")]
        public IActionResult GetReviewUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewuser = unit.ReviewUserManager.getById(id);

            if (reviewuser == null)
            {
                return NotFound();
            }

            return Ok(reviewuser);
        }

        // PUT: api/reviewusers/5
        [HttpPut("{id}")]
        public IActionResult PutreViewUser([FromRoute] int id, [FromBody] ReviewUser reviewuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reviewuser.ReviewId)
            {
                return BadRequest();
            }


            bool test = true;
            try
            {
                test = unit.ReviewUserManager.Update(reviewuser);
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
        public IActionResult PostReviewUser([FromBody] ReviewUser reviewuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ReviewUser ru = unit.ReviewUserManager.Insert(reviewuser);
            return Created("Getreviewuser", ru);
        }

        // DELETE: api/ReviewUsers/5
        [HttpDelete("{id}")]
        public IActionResult Deletereviewusers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewuser = unit.ReviewUserManager.getById(id);
            if (reviewuser == null)
            {
                return NotFound();
            }

            unit.ReviewUserManager.Delete(reviewuser);


            return Ok(reviewuser);
        }
    }
}