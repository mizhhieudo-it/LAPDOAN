using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DATNwebtintuc.MahoaMD5
{
    public class Mahoapass
    {
        public static string Mahoa(string pass)
        {
            var Encrycode = FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "MD5");
            return Encrycode;
        }
    }
}