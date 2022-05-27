using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelRequest
{
    public class ChangePasswordRequest
    {
        public string Email { get; set; }
        public string password { get; set; }
        public string oldpassword { get; set; }
    }
}