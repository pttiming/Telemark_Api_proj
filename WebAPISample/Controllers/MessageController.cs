using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private ApplicationContext _context;
        public MessageController(ApplicationContext context)
        {
            _context = context;
        }
        // GET api/message
        [HttpGet]
        public IActionResult Get()
        {
            // Retrieve all messagess from db logic
            var messages = _context.Messages.ToList();
            return Ok(messages);
        }

        // GET api/message/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Retrieve message by id from db logic
            var message = _context.Messages.Where(m => m.id == id).SingleOrDefault();
            return Ok(message);
        }

        // POST api/message
        [HttpPost]
        public IActionResult Post([FromBody]SmsMessage message)
        {
            MessageToDB(message);
            // Create message in db logic
            return Ok(message.Message);
        }

        public void MessageToDB(SmsMessage message)
        {
            message.Recevied = DateTime.Now;
            _context.Add(message);
            _context.SaveChanges();
        }
    }
}