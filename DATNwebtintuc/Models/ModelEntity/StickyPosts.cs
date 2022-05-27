using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class StickyPosts
    {
        public StickyPosts()
        {
            this.idStickyPost = Guid.NewGuid().ToString();
        }
        [Key]
        public string idStickyPost { get; set; }
        public int priority { get; set; }
        public virtual Post Post { get; set; }
    }
}