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
    public class Users2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();
        public Users2Controller()
        {
        }

        // GET: api/Users2
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return unit.UserManager.getAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = unit.UserManager.getById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }


            bool test=true ;
            try
            {
               test=  unit.UserManager.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (test==false)
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


        // PUT: api/Users/5
        [HttpPut("[action]/{id}/{currentloc}")]//tosara
        public IActionResult Putcurrentlocation([FromRoute] int id, [FromRoute] string currentloc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            currentloc = currentloc.ToLower();
            bool test = true;
            try
            {
                test = unit.UserManager.UpdateCity(id,currentloc);
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
        public IActionResult PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User u= unit.UserManager.Insert(user);
            return CreatedAtAction("GetUser", new { id = u.UserId }, u);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = unit.UserManager.getById(id);
            if (user == null)
            {
                return NotFound();
            }

             unit.UserManager.Delete(user);
            

            return Ok(user);
        }

        // GET: api/Users/cairo
        [HttpGet("{city:alpha}")]
        public IActionResult GetUsers([FromRoute] string city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<User> users = unit.UserManager.GetByCity(city);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }
    }
}