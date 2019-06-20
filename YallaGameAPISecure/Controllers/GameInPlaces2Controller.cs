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
    public class GameInPlaces2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public GameInPlaces2Controller()
        {

        }

        // GET: api/GameInPlaces
        [HttpGet]
        public IEnumerable<GameInPlace> GetGameInPlace()
        {
            return unit.GameInPlaceManager.getAll();
        }

        // GET: api/GameInPlaces/5/6
        [HttpGet("{placeid}/{gameid}")]
        public IActionResult GetGameInPlace([FromRoute] int placeid, [FromRoute]int gameid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var GameInPlaces = unit.GameInPlaceManager.findbytwoid(placeid,gameid);

            if (GameInPlaces == null)
            {
                return NotFound();
            }

            return Ok(GameInPlaces);
        }


        // GET: api/GameInPlaces/5/6
        [HttpGet("[action]/{placeid}")]
        public IActionResult findByGame([FromRoute] int placeid)//tosara
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var GameInPlaces = unit.GameInPlaceManager.findByPlaceId(placeid);

            if (GameInPlaces == null)
            {
                return NotFound();
            }

            return Ok(GameInPlaces);
        }
        // PUT: api/GameInPlaces/5/6
        [HttpPut("{placeid}/{gameid}")]
        public IActionResult PutGame([FromRoute] int placeid, [FromRoute] int gameid, [FromBody] GameInPlace GameInPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (placeid != GameInPlace.GameId || gameid != GameInPlace.GameId)
            {
                return BadRequest();
            }
            GameInPlace.GameId = gameid;
            GameInPlace.PlaceId = placeid;

            bool test = true;
            try
            {
                test = unit.GameInPlaceManager.Update(GameInPlace);
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

        // POST: api/GameInPlaces/5/6
        [HttpPost("{placeid}/{gameid}")]
        public IActionResult PostPlace([FromRoute] int placeid, [FromRoute] int gameid,[FromBody] GameInPlace GameInPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            GameInPlace.PlaceId = placeid;
            GameInPlace.GameId = gameid;
            GameInPlace g = unit.GameInPlaceManager.Insert(GameInPlace);
            return Created("GetGameInPlace", g);
        }

        // DELETE: api/GameInPlaces/5/6
        [HttpDelete("{placeid}/{gameid}")]
        public IActionResult DeletePlace([FromRoute] int placeid, [FromRoute] int gameid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = unit.GameInPlaceManager.findbytwoid(placeid,gameid);
            if (game == null)
            {
                return NotFound();
            }

            unit.GameInPlaceManager.Delete(game);


            return Ok(game);
        }
    }
}