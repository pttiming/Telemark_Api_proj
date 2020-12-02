using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        [HttpGet("races")]
        public IActionResult Races()
        {
            // Retrieve all messagess from db logic
            var races = _context.Races.ToList();
            var newJson = JsonConvert.SerializeObject(races);
            return Ok(newJson);
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
            string response;
            MessageToDB(message);
            if(message.Message.ToLower() == "races")
            {
                response = GetRaces();
            }
            else
            {
                response = "Sorry, I did not understand that.";
            }
            // Create message in db logic
            return Ok(response);
        }

        public void MessageToDB(SmsMessage message)
        {
            message.Recevied = DateTime.Now;
            _context.Add(message);
            _context.SaveChanges();
        }

        public string GetRaceInfo(string keyword)
        {
            string response;
            return response;
        }

        public string GetParticipantInfo(int id)
        {
            string response;
            return response;
        }

        public string SubscribeToAlerts()
        {
            string response;
            return response;
        }

        public bool CheckForTextUser()
        {
            if()
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateTextUser()
        {

        }

        public void SetPreviousUserAction()
        {

        }

        public void SubscribeForPushResult()
        {

        }

        public string ConvertPhoneNumber(string number)
        {
            string newNumber = number.Substring(2, 10);

            return newNumber;
        }

        public string GetRaces()
        {
            var races = _context.Races.Where(r => r.Keyword != null).ToList();
            string response = "";
            if (races.Count != 0)
            {
                foreach(Race r in races)
                {
                    response += $"Text {r.Keyword} for {r.name}" + System.Environment.NewLine;
                }
            }
            else
            {
                response = "There are currently no Races in the System.  Please Try again later.";
            }

            return response;
        }
    }
}