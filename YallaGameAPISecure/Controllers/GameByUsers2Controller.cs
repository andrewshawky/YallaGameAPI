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
    public class GameByUsers2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public GameByUsers2Controller()
        {

        }

        // GET: api/GameByUsers
        [HttpGet]
        public IEnumerable<GameByUser> GetGameInPlace()
        {
            return unit.GameByUserManager.getAll();
        }

        // GET: api/GameByUsers/5/6
        [HttpGet("{gameid}/{userid}")]
        public IActionResult GetGameInPlace([FromRoute] int gameid, [FromRoute]int userid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var GameByUser = unit.GameByUserManager.findbytwoid(gameid, userid);

            if (GameByUser == null)
            {
                return NotFound();
            }

            return Ok(GameByUser);
        }

        // PUT: api/GameByUsers/5/6
        [HttpPut("{gameid}/{userid}")]
        public IActionResult PutGame([FromRoute] int gameid, [FromRoute] int userid, [FromBody] GameByUser GameByUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (gameid != GameByUser.GameId || userid != GameByUser.UserId)
            {
                return BadRequest();
            }
            GameByUser.GameId = gameid;
            GameByUser.UserId = userid;

            bool test = true;
            try
            {
                test = unit.GameByUserManager.Update(GameByUser);
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

        // POST: api/GameByUsers/5/6
        [HttpPost("{gameid}/{userid}")]
        public IActionResult PostPlace([FromRoute] int gameid, [FromRoute] int userid, [FromBody] GameByUser GameByUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            GameByUser.UserId = userid;
            GameByUser.GameId = gameid;
            GameByUser g = unit.GameByUserManager.Insert(GameByUser);
            return Created("GetGameInPlace",  g);
        }

        // DELETE: api/GameByUsers/5/6
        [HttpDelete("{gameid}/{userid}")]
        public IActionResult DeletePlace([FromRoute] int gameid, [FromRoute] int userid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var GameByUser = unit.GameByUserManager.findbytwoid(gameid, userid);
            if (GameByUser == null)
            {
                return NotFound();
            }

            unit.GameByUserManager.Delete(GameByUser);


            return Ok(GameByUser);
        }
    }
}