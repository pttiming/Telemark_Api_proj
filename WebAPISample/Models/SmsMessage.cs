using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISample.Models
{
    public class SmsMessage
    {
        [Key]
        public int id { get; set; }
        public string Number { get; set; }

        public string Message { get; set; }
        public DateTime Recevied { get; set; }
    }
}
