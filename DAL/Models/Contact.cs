using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Contact
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
