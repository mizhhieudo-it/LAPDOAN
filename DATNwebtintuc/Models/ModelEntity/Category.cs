using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class Category
    {
        public Category()
        {
            this.IDcategory = Guid.NewGuid().ToString();
            TBL_Post = new HashSet<Post>();
    
        }
        [Key]
        public string IDcategory  { get; set; } 
        public string namecategory { get; set; }
        public virtual ICollection<Post> TBL_Post { get; set; }
    }
}