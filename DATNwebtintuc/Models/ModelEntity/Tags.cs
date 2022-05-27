using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class Tags
    {
        public Tags()
        {
            this.TagID = Guid.NewGuid().ToString();
        }

        [Key]
        public string TagID { get; set; }
        public string TagName { get; set; }
        public virtual Post Post { get; set; }
    }
}