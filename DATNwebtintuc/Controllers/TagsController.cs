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
    public class TagsController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();
        // GET: Tags
        public ActionResult Index(bool? create, bool? update, bool? delete)
        {
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
            var thongtin = data.Tagss.ToList();
            return View(thongtin);
        }
        public ActionResult Viewcreate() 
        {
            return View();
        }
        public ActionResult Create(TagsRequest item) 
        {
            TagsRequestValidator validator = new TagsRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid) 
            {
                {
                    ViewData["checkvalidatetag"] = (result.Errors);
                    return View("Viewcreate");
                }
            }
            else 
            {
                var entitytags = new Tags();
                entitytags.TagName = item.TagName;
                data.Tagss.Add(entitytags);
                data.SaveChanges();
                return RedirectToAction("Index", new { create = true });
            }
        }
        public ActionResult Delete(string id) 
        {
            var remove = data.Tagss.Find(id);
            data.Tagss.Remove(remove);
            data.SaveChanges();
            return RedirectToAction("Index", new { delete = true });
        }
        public ActionResult Viewupdate(string id) 
        {
            var update = data.Tagss.Find(id);
            return View(update);
        }
        public ActionResult Update(TagsRequest item) 
        {
            TagsRequestValidator validator = new TagsRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid)
            {
                {
                    ViewData["checkvalidatetag"] = (result.Errors);
                    return View("Viewupdate");
                }
            }
            else
            {
                var entitytags = new Tags();
                entitytags.TagID = item.TagID;
                entitytags.TagName = item.TagName;
                data.Entry(entitytags).State = EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index", new { update = true });
            }
        }
        public ActionResult Search(string search) 
        {
            var result = data.Tagss.Where(x => x.TagName.Contains(search)).Select(x => x).ToList();
            return View(result);
        }
    }
    }
