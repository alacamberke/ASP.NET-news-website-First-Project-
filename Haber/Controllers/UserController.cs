using Haber.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haber.Controllers
{
    public class UserController : Controller
    {
        private IAuthenticationService _authenticateService;
        public UserController(IAuthenticationService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        // GET: User
        public ActionResult Index()
        {
            var users = _authenticateService.GetAllUsers();
            return View(users);
        }
    }
}