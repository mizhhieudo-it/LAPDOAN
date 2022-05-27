using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelRequest
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public HttpPostedFileBase Image { get; set; }

    }
}