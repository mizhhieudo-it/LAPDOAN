using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class Post
    {
        public Post()
        {
            TBL_Tags = new HashSet<Tags>();
            TBL_StickyPosts = new HashSet<StickyPosts>();
            Tbl_Series = new HashSet<Series>();
            this.post_id=  Guid.NewGuid().ToString();
        }
        [Key]
        public string post_id { get; set; }
        public string post_title { get; set; } // tieu de bai dang
        public string post_slug { get; set; }//  them slug vao cho url
        public string post_teaser { get; set; }// la 1 cai anh nho de quang cao bai dang day
        public string post_review { get; set; }// review bai viet
        public string post_content { get; set; }// noi dung cua bai dang
        public string post_tag { get; set; }// gan the bai viet
        public DateTime? create_date { get; set; }//ngay tao
        public DateTime? edit_date { get; set; }// ngay sua
        public int ViewCount { get; set; }// so luong nguoi xem
        public int Rated { get; set; }// so luong xem
        public string AvatarImage { get; set; } //anh bai dang
        public bool status { get; set; } // trang thai bai dang
        public virtual Account Account { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Tags> TBL_Tags { get; set; }
        public virtual ICollection<StickyPosts> TBL_StickyPosts { get; set; }
        public virtual ICollection<Series> Tbl_Series { get; set; }
    }
}