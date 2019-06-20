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
    public class UserInvitations2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public UserInvitations2Controller()
        {

        }

        // GET: api/UserInvitations
        [HttpGet]
        public IEnumerable<UserInvitation> GetUserInvitation()
        {
            return unit.UserInvitationManager.getAll();
        }

        // GET: api/UserInvitations/5/6
        [HttpGet("{invitationid}/{userid}")]
        public IActionResult GetUserInvitation([FromRoute] int invitationid, [FromRoute]int userid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UserInvitation = unit.UserInvitationManager.findbytwoid(invitationid, userid);

            if (UserInvitation == null)
            {
                return NotFound();
            }

            return Ok(UserInvitation);
        }

        // PUT: api/UserInvitations/5/6
        [HttpPut("{invitationid}/{userid}")]
        public IActionResult PutUserInvitation([FromRoute] int invitationid, [FromRoute] int userid, [FromBody] UserInvitation UserInvitation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (invitationid != UserInvitation.InvitationId || userid != UserInvitation.UserId)
            {
                return BadRequest();
            }
            UserInvitation.InvitationId = invitationid;
            UserInvitation.UserId = userid;

            bool test = true;
            try
            {
                test = unit.UserInvitationManager.Update(UserInvitation);
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

        // POST: api/UserInvitations/5/6
        [HttpPost("{invitationid}/{userid}")]
        public IActionResult PostUserInvitation([FromRoute] int invitationid, [FromRoute] int userid, [FromBody] UserInvitation UserInvitation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserInvitation.UserId = userid;
            UserInvitation.InvitationId = invitationid;
            UserInvitation g = unit.UserInvitationManager.Insert(UserInvitation);
            return Created("GetGameInPlace",  g);
        }

        // DELETE: api/UserInvitations/5/6
        [HttpDelete("{invitationid}/{userid}")]
        public IActionResult DeleteUserInvitation([FromRoute] int invitationid, [FromRoute] int userid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UserInvitation = unit.UserInvitationManager.findbytwoid(invitationid, userid);
            if (UserInvitation == null)
            {
                return NotFound();
            }

            unit.UserInvitationManager.Delete(UserInvitation);


            return Ok(UserInvitation);
        }
    }
}