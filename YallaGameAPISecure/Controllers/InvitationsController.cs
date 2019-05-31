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
    public class InvitationsController : ControllerBase
    {
        private readonly IModelRepositery<Invitation> context;

        public InvitationsController(IModelRepositery<Invitation> context)
        {
            this.context = context;
        }

        // GET: api/Users
        [HttpGet]
        public List<Invitation> GetUser()
        {
            List<Invitation> invitations = context.getAll();
            return invitations;
        }

        // GET: api/Invitations/5
        [HttpGet("{id}")]
        public IActionResult GetInvitation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invitation = context.getById(id);

            if (invitation == null)
            {
                return NotFound();
            }

            return Ok(invitation);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutUser([FromRoute] int id, [FromBody] Invitation invitation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invitation.InvitationId)
            {
                return BadRequest();
            }

            context.Update(invitation);

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
        public IActionResult PostUser([FromBody] Invitation invitation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Insert(invitation);
            context.Save();
            return CreatedAtAction("GetUser", new { id = invitation.InvitationId }, invitation);
        }

        // DELETE: api/invitations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInvitation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invitation = context.getById(id);
            if (invitation == null)
            {
                return NotFound();
            }

            context.Delete(id);
            context.Save();

            return Ok(invitation);
        }
    }
}