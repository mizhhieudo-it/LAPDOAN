using DATNwebtintuc.Models.ModelEntity;
using DATNwebtintuc.Models.ModelRequest;
using DATNwebtintuc.Validator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNwebtintuc.Controllers
{
    public class PostController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();

        // GET: Post
        public ActionResult Index(bool? create,bool? update,bool? delete,int? page)
        {
            var thongtin = data.Posts.ToList();
            if (update == true) 
            {
                ViewBag.Messupdate = true;
            }
            if (create == true)
            {
                ViewBag.Messcreate = true;
            }
            if (delete == true)
            {
                ViewBag.Messdelete = true;
            }
            var pagesize = 5;
            if(page == null) 
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.OrderBy(x => x.post_id).Skip(paging ?? 1).Take(pagesize);
            var numberpage = 0;
            if(totall % pagesize == 0) 
            {
                numberpage = totall / pagesize;
            }
            else 
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpage"] = numberpage;
            return View(result.ToList());
        }
        [ValidateInput(false)]
        public ActionResult Viewcreate() 
        {
            ViewData["selectcategory"] = data.Categories.ToList();
            ViewData["selectseries"] = data.Seriess.ToList();
            return View();
        }
        [ValidateInput(false)]
        public ActionResult Create(PostRequest item , string IDSeries) 
        {
            ViewData["selectcategory"] = data.Categories.ToList();
            ViewData["selectseries"] = data.Seriess.ToList();
            PostRequestValidator validator = new PostRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid)
            {
                {
                    ViewData["checkvalidatepost"] = (result.Errors);
                    return View("Viewcreate");
                }
            }
            else
            {

                var entitypost = new Post();
                entitypost.post_review = item.post_review;
                entitypost.post_content = item.post_content;
                entitypost.post_slug = item.post_slug;
                entitypost.post_tag = item.post_tag;
                entitypost.IDcategory = item.IDcategory;
                entitypost.post_teaser = UploadPosttester(item.post_teaser);
                entitypost.post_title = item.post_title;
                entitypost.create_date = item.create_date;
                data.Posts.Add(entitypost);
                data.SaveChanges();
                var FindIdSeries = data.Seriess.Find(IDSeries);
                FindIdSeries.post_id = entitypost.post_id;
                data.Entry(FindIdSeries).State = EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index", new { create = true });
            }
        }
        [ValidateInput(false)]
        public ActionResult Viewupdate(string id) 
        {
            var update = data.Posts.Find(id);
            ViewData["selectcategory"] = data.Categories.ToList();
            return View(update);
        }
        [ValidateInput(false)]
        public ActionResult Update(PostRequest item) 
        {
            ViewData["selectcategory"] = data.Categories.ToList();
            PostRequestValidator validator = new PostRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid)
            {
                {
                    ViewData["checkvalidatepostupdate"] = (result.Errors);
                    return View("Viewcreate");
                }
            }
            else 
            {
                var entitypost = new Post();
                entitypost.post_id = item.post_id;
                entitypost.post_review = item.post_review;
                entitypost.post_content = item.post_content;
                entitypost.post_slug = item.post_slug;
                entitypost.post_tag = item.post_tag;
                entitypost.IDcategory = item.IDcategory;
                entitypost.post_teaser = UploadPosttester(item.post_teaser);
                entitypost.post_title = item.post_title;
                entitypost.create_date = item.create_date;
                entitypost.edit_date = item.edit_date;
                data.Entry(entitypost).State = EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index",new { update = true});
            }
        }
        public ActionResult Delete(string id) 
        {
            var delete = data.Posts.Find(id);
            data.Posts.Remove(delete);
            data.SaveChanges();
            return RedirectToAction("Index", new { delete = true });
        }
        public ActionResult Search(string search) 
        {
            var searchlower = search.ToLower();
            var result = data.Posts.Where(x => x.post_title.ToLower().Contains(searchlower)).ToList();
            return View(result);
        }
        public string UploadPosttester(HttpPostedFileBase file)
        {
            var filename = file.FileName;
            var getfile = "../UploadPost/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        public string UploadAvatarimg(HttpPostedFileBase file)
        {
            var filename = file.FileName;
            var getfile = "../UploadPostava/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        public ActionResult Detail(string id) 
        {
            var detail = data.Posts.Find(id);
            return View(detail);
        }
    }
}