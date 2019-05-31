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
    public class GroupChats2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public GroupChats2Controller()
        {

        }

        // GET: api/GroupChats
        [HttpGet]
        public IEnumerable<GroupChat> GetGame()
        {
            return unit.GroupChatManager.getAll();
        }

        // GET: api/GroupChats/5
        [HttpGet("{id}")]
        public IActionResult GetGroupChats([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var GroupChats = unit.GroupChatManager.getById(id);

            if (GroupChats == null)
            {
                return NotFound();
            }

            return Ok(GroupChats);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutGroupChats([FromRoute] int id, [FromBody] GroupChat GroupChat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != GroupChat.GroupId)
            {
                return BadRequest();
            }


            bool test = true;
            try
            {
                test = unit.GroupChatManager.Update(GroupChat);
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

        // POST: api/GroupChats
        [HttpPost]
        public IActionResult PostGroupChat([FromBody] GroupChat GroupChat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            GroupChat gc = unit.GroupChatManager.Insert(GroupChat);
            return CreatedAtAction("GetGroupChat", new { id = gc.GroupId }, gc);
        }

        // DELETE: api/GroupChats/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGroupChat([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var GroupChat = unit.GroupChatManager.getById(id);
            if (GroupChat == null)
            {
                return NotFound();
            }

            unit.GroupChatManager.Delete(GroupChat);


            return Ok(GroupChat);
        }
    }
}