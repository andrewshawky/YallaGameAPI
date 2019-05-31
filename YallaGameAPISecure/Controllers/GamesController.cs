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
    public class GamesController : ControllerBase
    {
        private readonly IModelRepositery<Game> context;

        public GamesController(IModelRepositery<Game> context)
        {
            this.context = context;
        }

        // GET: api/Games
        [HttpGet]
        public List<Game> GetGame()
        {
            List<Game> games = context.getAll();
            return games;
        }

        // GET: api/games/5
        [HttpGet("{id}")]
        public IActionResult Getgame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = context.getById(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
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

            context.Update(game);

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

        // POST: api/Users
        [HttpPost]
        public IActionResult PostUser([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Insert(game);
            context.Save();
            return CreatedAtAction("GetUser", new { id = game.GameId }, game);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = context.getById(id);
            if (user == null)
            {
                return NotFound();
            }

            context.Delete(id);
            context.Save();

            return Ok(user);
        }
    }
}