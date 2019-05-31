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
    public class OnlineUsers2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public OnlineUsers2Controller()
        {

        }

        // GET: api/OnlineUser
        [HttpGet]
        public IEnumerable<OnlineUsers> GetOnlineUser()
        {
            return unit.OnlineUserManager.getAll();
        }

        // GET: api/OnlineUsers/5
        [HttpGet("{id}")]
        public IActionResult GetOnlineUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var OnlineUser = unit.OnlineUserManager.getById(id);

            if (OnlineUser == null)
            {
                return NotFound();
            }

            return Ok(OnlineUser);
        }

        // PUT: api/OnlineUsers/5
        [HttpPut("{id}")]
        public IActionResult PutOnlineUser([FromRoute] int id, [FromBody] OnlineUsers onlineuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != onlineuser.OnlineId)
            {
                return BadRequest();
            }


            bool test = true;
            try
            {
                test = unit.OnlineUserManager.Update(onlineuser);
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

        // POST: api/OnlineUsers
        [HttpPost]
        public IActionResult PostOnlineUsers([FromBody] OnlineUsers onlineuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            OnlineUsers ou = unit.OnlineUserManager.Insert(onlineuser);
            return CreatedAtAction("GetOnlineUsers", new { id = ou.OnlineId }, ou);
        }

        // DELETE: api/OnlineUsers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOnlineUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var OnlineUsers = unit.OnlineUserManager.getById(id);
            if (OnlineUsers == null)
            {
                return NotFound();
            }

            unit.OnlineUserManager.Delete(OnlineUsers);


            return Ok(OnlineUsers);
        }
    }
}