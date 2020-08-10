using Haber.Interface;
using Haber.Models;
using Haber.MyFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Haber.Controllers
{
    [Action]
    public class AccountController : Controller
    {
        private IAuthenticationService _authenticateService;
        private IHaberService _haberService;
        public AccountController(IAuthenticationService authenticateService, IHaberService haberService)
        {
            _authenticateService = authenticateService;
            _haberService = haberService;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register usermodel)
        {
            usermodel.Role = "User";
            if (ModelState.IsValid && _authenticateService.Register(usermodel).TrueOrFalse)
            {
                return RedirectToAction("Login","Account");
            }
            else
            {
                foreach (var error in _authenticateService.Register(usermodel).Result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login loginmodel)
        {
            if (_authenticateService.Login(loginmodel))
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("Hata", "Lütfen bilgileri doğru giriniz.");
                return View();
            }
        }

        public ActionResult Logout()
        {
            return View();
        }

        [Authorize]
        public ActionResult LogoutPost()
        {
            _authenticateService.Logout();
            return RedirectToAction("Login","Account");
        }

        [HttpGet]
        [Authorize]
        public ActionResult MyProfile()
        {
            var currentUser = _authenticateService.GetCurrentUser();
            ViewBag.haberler = _haberService.GetAll().Where(i => i.HaberOwner == currentUser.UserID).ToList();
            return View(currentUser);
        }

        public ActionResult AnotherProfile(string userid)
        {
            var user = _authenticateService.GetUserById(userid);
            ViewBag.haberler = _haberService.GetAll().Where(i => i.HaberOwner == user.Username).ToList();
            return View(user);
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditSec()
        {
            var user = _authenticateService.GetCurrentUser();
            return View(user);
        }

        [HttpPost,ActionName("EditSec")]
        [Authorize]
        public ActionResult Edit(Register user)
        {
            _authenticateService.UpdateUser(user);
            return RedirectToAction("MyProfile", "Account");
        }

        public PartialViewResult User()
        {
            var currentUser = _authenticateService.GetCurrentUser();
            return PartialView(currentUser);
        }

        
    }
}