using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class Series
    {
        public Series() 
        {
            this.seriesID = Guid.NewGuid().ToString();
        }
        [Key]
        public string seriesID { get; set; }
        public string seriesName { get; set; }
        public virtual Post Post { get; set; }
    }
}