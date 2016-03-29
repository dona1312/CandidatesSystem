using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ITSystem.Enums;
using ITSystem.Models;

namespace ITSystem.ViewModels.Email
{
    public class EmailSendVM
    {
        public string Search { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public SearchEnum SearchType { get; set; }
        public List<Candidate> Recievers { get; set; }
    }
}