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
    public class SeriesController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();
        // GET: Series
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
            var thongtin = data.Seriess.ToList();
            return View(thongtin);
        }
        public ActionResult Viewcreate() 
        {
            return View();
        }
        public ActionResult Create(SeriesRequest item) 
        {
            {
                SeriesRequestValidator validator = new SeriesRequestValidator();
                var result = validator.Validate(item);
                if (!result.IsValid)
                {
                    {
                        ViewData["checkvalidateseries"] = (result.Errors);
                        return View("Viewcreate");
                    }
                }
                else
                {
                    var entityseries = new Series();
                    entityseries.seriesName = item.seriesName;
                    data.Seriess.Add(entityseries);
                    data.SaveChanges();
                    return RedirectToAction("Index", new { create = true });
                }
            }
        }
        public ActionResult Viewupdate(string id) 
        {
            var update = data.Seriess.Find(id);
            return View(update);
        }
        public ActionResult Update(SeriesRequest item) 
        {
            {
                {
                    SeriesRequestValidator validator = new SeriesRequestValidator();
                    var result = validator.Validate(item);
                    if (!result.IsValid)
                    {
                        {
                            ViewData["checkvalidateseries"] = (result.Errors);
                            return View("Viewupdate");
                        }
                    }
                    else
                    {
                        var entityseries = new Series();
                        entityseries.seriesID = item.seriesID;
                        entityseries.seriesName = item.seriesName;
                        data.Entry(entityseries).State = EntityState.Modified;
                        data.SaveChanges();
                        return RedirectToAction("Index", new { update = true });
                    }
                }
            }
        }
        public ActionResult Delete(string id) 
        {
            var delete = data.Seriess.Find(id);
            data.Seriess.Remove(delete);
            data.SaveChanges();
            return RedirectToAction("Index",new { delete = true });
        }
        public ActionResult Search(string search) 
        {
            var result = data.Seriess.Where(x => x.seriesName.Contains(search)).Select(x => x).ToList();
            return View(result);
        }
    }
}