using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class Account
    {
        public Account()
        {
            this.IDaccount = Guid.NewGuid().ToString();
            TBL_Post = new HashSet<Post>();
        }
        [Key]
        public string IDaccount { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string Image { get; set;}
        public string userrole { get; set; } // quyen han nguoi dung
        public bool status { get; set; }// trang thai
        public virtual ICollection<Post> TBL_Post { get; set; }
    }
}