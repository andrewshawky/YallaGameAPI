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
    public class Games2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public Games2Controller()
        {

        }

        // GET: api/Users2
        [HttpGet]
        public IEnumerable<Game> GetGame()
        {
            return unit.GameManager.getAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetGame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var place = unit.GameManager.getById(id);

            if (place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutGame([FromRoute] int id, [FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.GameId)
            {
                return BadRequest();
            }


            bool test = true;
            try
            {
                test = unit.GameManager.Update(game);
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
        public IActionResult PostPlace([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Game g = unit.GameManager.Insert(game);
            return CreatedAtAction("GetGame", new { id = g.GameId }, g);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeletePlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = unit.GameManager.getById(id);
            if (game == null)
            {
                return NotFound();
            }

            unit.GameManager.Delete(game);


            return Ok(game);
        }
    }
}