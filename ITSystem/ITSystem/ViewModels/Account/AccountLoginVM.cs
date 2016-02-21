using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.ViewModels.Account
{
    public class AccountLoginVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RedirectUrl { get; set; }
    }
}