using Haber.Entities;
using Haber.Interface;
using Haber.Models;
using Haber.MyFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haber.Controllers
{
    [Action]
    public class RoleController : Controller
    {
        private IRoleService _roleService;
        private IAuthenticationService _authenticateService;
        public RoleController(IRoleService roleService, IAuthenticationService authenticateService)
        {
            _roleService = roleService;
            _authenticateService = authenticateService;
        }

        public ActionResult Index()
        {
            var roles = _roleService.GetAll();
            return View(roles);
        }

        [HttpGet]
        public ActionResult RoleAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RoleAdd(Roles role)
        {
            _roleService.RoleAdd(role);
            return RedirectToAction("Index", "Role");
        }

        public ActionResult RoleDelete(Roles role)
        {
            if (role != null)
            {
                _roleService.RoleDelete(role);
                return RedirectToAction("Index", "Role");
            }

            return null;
        }

        [HttpGet]
        public ActionResult AddToRole()
        {
            ViewBag.users = new SelectList(_authenticateService.GetAllUsers(), "UserID", "Username");
            ViewBag.roles = new SelectList(_roleService.GetAll(), "RoleName", "RoleName");
            return View();
        }

        [HttpPost]
        public ActionResult AddToRole(string role, string userid)
        {
            ViewBag.users = new SelectList(_authenticateService.GetAllUsers(), "UserID", "Username",userid);
            ViewBag.roles = new SelectList(_roleService.GetAll(), "RoleName", "RoleName", role);

            _roleService.AddToRole(role, userid);

            return RedirectToAction("Index", "Role");
        }

        public ActionResult Delete(string roleid)
        {
            var viewRole = _roleService.Get(roleid);
            return View(viewRole);
        }

        public ActionResult DeleteConfirmed(string roleid)
        {
            var deletedRole = _roleService.Get(roleid);

            _roleService.RoleDelete(deletedRole);

            return RedirectToAction("Index", "Role");
        }

        public ActionResult Details(string roleid)
        {
            var role = _roleService.Get(roleid);
            var users = _authenticateService.GetAllUsers().Where(i => i.Role == role.RoleName).ToList();
            ViewBag.users = users;
            return View(role);
        }


    }
}