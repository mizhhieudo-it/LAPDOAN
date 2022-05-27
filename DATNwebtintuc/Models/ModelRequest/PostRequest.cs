using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelRequest
{
    public class PostRequest
    {
        public string post_id { get; set; }
        public string post_title { get; set; } // tieu de bai dang
        public string post_slug { get; set; }//  them slug vao cho url
        public HttpPostedFileBase post_teaser { get; set; }// la 1 cai anh nho de quang cao bai dang day
        public string post_review { get; set; }// review bai viet
        public string post_content { get; set; }// noi dung cua bai dang
        public string post_tag { get; set; }// gan the bai viet
        public HttpPostedFileBase AvatarImage { get; set; } //anh bai dang
        public DateTime create_date { get; set; }//ngay tao
        public DateTime edit_date { get; set; }// ngay sua
        public string IDcategory { get; set; }
        
    }
}