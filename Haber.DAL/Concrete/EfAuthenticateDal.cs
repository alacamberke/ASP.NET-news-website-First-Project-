using Haber.DAL.Abstract.EntityFramework;
using Haber.Entities;
using Haber.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Haber.DAL.Concrete
{
    public class EfAuthenticateDal : IAuthenticationDal
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationContext context = new ApplicationContext();
        public EfAuthenticateDal()
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationContext()));
        }

        public bool Login(Login usermodel)
        {
            if (usermodel.Username == null && usermodel.Password == null)
            {
                return false;
            }

            var user = _userManager.Find(usermodel.Username, usermodel.Password);

            if (user != null)
            {
                IAuthenticationManager authManager = HttpContext.Current.Request.GetOwinContext().Authentication;
                var Identity = _userManager.CreateIdentity(user, "ApplicationCookie");
                var authProperties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                };

                authManager.SignOut();
                authManager.SignIn(authProperties, Identity);

                return true;
            }

            return false;
        }

        public void Logout()
        {
            IAuthenticationManager authManager = HttpContext.Current.Request.GetOwinContext().Authentication;
            authManager.SignOut();
        }

        public Returning Register(Register usermodel)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = usermodel.Username;
            user.Email = usermodel.Email;
            user.Role = usermodel.Role;
            
            var result = _userManager.Create(user, usermodel.Password);

            if (result.Succeeded)
            {
                return new Returning()
                {
                    Result = result,
                    TrueOrFalse = true
                };
            }
            else
            {
                return new Returning()
                {
                    Result = null,
                    TrueOrFalse = false
                };
            }
        }

        public List<Register> GetAllUsers()
        {
            return context.Users.Select(i=> new Register 
            {
                UserID = i.Id,
                Username = i.UserName,
                Email = i.Email,
                Role = i.Role
            }).ToList();
        }

        public Register GetCurrentUser()
        {
            var userid = HttpContext.Current.User.Identity.GetUserId();
            var currentUser = _userManager.FindById(userid);

            var usermodel = new Register();
            usermodel.UserID = currentUser.Id;
            usermodel.Email = currentUser.Email;
            usermodel.Username = currentUser.UserName;

            return usermodel;
        }

        public Register GetUserById(string id)
        {
            var user = _userManager.FindById(id);
            Register model = new Register();
            model.Username = user.UserName;
            model.Email = user.Email;

            return model;
        }

        public void UpdateUser(Register user)
        {
            var userid = HttpContext.Current.User.Identity.GetUserId();
            var userr = _userManager.FindById(userid);
            userr.UserName = user.Username;

            _userManager.Update(userr);
        }
    }
}
