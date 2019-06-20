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
    public class Chats2Controller : ControllerBase
    {
        UnitOfWork unit = UnitOfWork.CreateInstance();

        public Chats2Controller()
        {

        }

        // GET: api/Chats2
        //[HttpGet]
        //public IEnumerable<Chat> GetChat()
        //{
        //    return unit.ChatManager.getAll();
        //}

        // GET: api/Chats/5
        [HttpGet("{id}")]
        public IActionResult GetChat([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chat = unit.ChatManager.GetAllChatOfUser(id);

            if (chat == null)
            {
                return NotFound();
            }

            return Ok(chat);
        }


        //////////return specific chat from two user
        ///

        [HttpGet("{FirstUserId}/{SecondUserId}")]
        public IActionResult SpecificChat([FromRoute] int FirstUserId, [FromRoute] int SecondUserId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chat = unit.ChatManager.GetChatOfUser(FirstUserId, SecondUserId);
            if (chat == null)
            {
                return NotFound();
            }


            return Ok(chat);
        }


        ///POST: api/Chats2
        [HttpPost]
        public IActionResult PostChat([FromBody] Chat chat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Chat ch = unit.ChatManager.Insert(chat);
            return Created("GetChat",  ch);
        }

        ////////delete
        [HttpDelete("{UserWantToDeleteId}/{PartnerId}")]
        public IActionResult DeleteChat([FromRoute] int UserWantToDeleteId, [FromRoute] int PartnerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chat = unit.ChatManager.GetChatOfUser(UserWantToDeleteId, PartnerId);
            if (chat == null)
            {
                return NotFound();
            }

            foreach(var item in chat)
            {
                item.IsDeleted = true;
                unit.ChatManager.Update(item);
            }
          
            
            return Ok(chat);
        }

        // PUT: api/Chats/5
        //[HttpPut("{id}")]
        //public IActionResult Putchat([FromRoute] int id, [FromBody] Chat chat)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != chat.ChatId)
        //    {
        //        return BadRequest();
        //    }


        //    bool test = true;
        //    try
        //    {
        //        test = unit.ChatManager.Update(chat);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (test == false)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // 

        // DELETE: api/Chats/5/1

    }
}