using DATNwebtintuc.MahoaMD5;
using DATNwebtintuc.Models.ModelEntity;
using DATNwebtintuc.Models.ModelRequest;
using DATNwebtintuc.Validator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DATNwebtintuc.Controllers
{
    public class AccountController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterRequest item)
        {
            RegisterRequestValidator validator = new RegisterRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid) 
            {
                {
                    ViewData["checkvalidatorregister"] = (result.Errors);
                    return View("Register");
                }
            }
            var checkUniqueEmail = data.Accounts.Where(x => x.Email == item.Email).Count();
            var checkUniqueUsername = data.Accounts.Where(x => x.Username == item.Username).Count();
            if(checkUniqueEmail > 0) 
            {
                ViewData["FailValidate"] = "Email Registed";
                return View("Register");
            }
            else if(checkUniqueUsername > 0) 
            {
                ViewData["FailValidate"] = "Username Register";
                return View("Register");
            }
            else 
            {
                item.password = Mahoapass.Mahoa(item.password);
                var entityAccount = new Account();
                entityAccount.Username = item.Username;
                entityAccount.Email = item.Email;
                entityAccount.password = item.password;
                if(item.Image == null) 
                {
                    entityAccount.Image = "../Uploadimg/Anhhanoi.jpg";
                }
                else 
                {
                    entityAccount.Image = Uploadimgregister(item.Image);
                }
                data.Accounts.Add(entityAccount);
                data.SaveChanges();
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginRequest item)
        {
            LoginRequestValidator validator = new LoginRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid) 
            {
                {
                    ViewData["checkvalidatorlogin"] = (result.Errors);
                    return View("Login");
                }
            }
            else 
            {
                var checkpass = Mahoapass.Mahoa(item.password);
                var rel = data.Accounts.Where(x => x.Username == item.Username && x.password == checkpass).FirstOrDefault();
                if(rel != null ) 
                {
                    FormsAuthentication.SetAuthCookie(item.Username, true);
                    Session["username"] = rel.Username;
                    Session["Avata"] = rel.Image;
                    return RedirectToAction("Index", "Category");
                }
                else 
                {
                    {
                        ViewData["checkfailllogin"] = "LOGIN UNSUCCESSFUL";
                        return View(item);
                    }
                }
            }
        }
        [HttpGet]
        public ActionResult Changepassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Changepassword(ChangePasswordRequest item)
        {
            ChangePasswordRequestValidator validator = new ChangePasswordRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid) 
            {
                {
                    ViewData["checkvalidatorchangepass"] = (result.Errors);
                    return View("Changepassword");
                }
            }
            else 
            {
                var find = data.Accounts.Where(x => x.Email == item.Email).FirstOrDefault();
                if(find != null) 
                {
                    var chagepass = item.oldpassword;
                    var mahoapasscu = Mahoapass.Mahoa(chagepass);
                    if(find.password == mahoapasscu) 
                    {
                        find.password = Mahoapass.Mahoa(item.password);
                        data.Entry(find).State = EntityState.Modified;
                        data.SaveChanges();
                        ViewData["checkvalidatorchangepasstrue"] = "Update success";
                        return View("Changepassword");
                    }
                    else 
                    {
                        ViewData["checkvalidatorchangepasstrue"] = "Password not found";
                        return View("Changepassword");
                    }
                }
                else
                {
                    ViewData["checkvalidatorchangepasstrue"] = "Email or Password does not exist";
                    return View("Changepassword");
                }
            }
        }
        [HttpGet]
        public ActionResult Resetpass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Resetpass(ResetPasswordRequest item)
        {
            ResetPasswordRequestValidator validator = new ResetPasswordRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid) 
            {
                {
                    ViewData["checkvalidatorreset"] = (result.Errors);
                    return View("Resetpass");
                }
            }
            else 
            {
                var resetpass = "hnnew123";
                var checkmail = data.Accounts.Where(x => x.Email == item.Email).FirstOrDefault();
                if(checkmail == null) 
                {
                    ViewData["checkmail"] = "Email does not exit";
                    return View("Resetpass");
                }
                else 
                {
                    checkmail.password = Mahoapass.Mahoa(resetpass);
                    data.Entry(checkmail).State = EntityState.Modified;
                    data.SaveChanges();
                    var createmail = new Maihelper();
                    createmail.SendMail(item.Email, "Your Password", "Password is" + resetpass.ToString());
                    return View();
                }
            }
        }
        public string Uploadimgregister(HttpPostedFileBase file) 
        {
            var filename = file.FileName;
            var getfile = "../Uploadimg/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
    }
}