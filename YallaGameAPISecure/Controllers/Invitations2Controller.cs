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
    public class Invitations2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public Invitations2Controller()
        {

        }

        // GET: api/invitations2
        [HttpGet]
        public IEnumerable<Invitation> GetInvitation()
        {
            return unit.InvitationManager.getAll();
        }

        // GET: api/invitations/5
        [HttpGet("{id}")]
        public IActionResult GetInvitation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invitation = unit.InvitationManager.getById(id);

            if (invitation == null)
            {
                return NotFound();
            }

            return Ok(invitation);
        }

        // PUT: api/invitations/5
        [HttpPut("{id}")]
        public IActionResult PutInvitation([FromRoute] int id, [FromBody] Invitation invitation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invitation.InvitationId)
            {
                return BadRequest();
            }


            bool test = true;
            try
            {
                test = unit.InvitationManager.Update(invitation);
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

        // POST: api/invitations
        [HttpPost]
        public IActionResult PostPlace([FromBody] Invitation invitation)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Invitation i = unit.InvitationManager.Insert(invitation);
            return Created("GetInvitation",  i);
        }

        // DELETE: api/invitations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInvitation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invitation = unit.InvitationManager.getById(id);
            if (invitation == null)
            {
                return NotFound();
            }

            unit.InvitationManager.Delete(invitation);


            return Ok(invitation);
        }
    }
}