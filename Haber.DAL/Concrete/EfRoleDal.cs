using Haber.DAL.Abstract.EntityFramework;
using Haber.Entities;
using Haber.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.DAL.Concrete
{
    public class EfRoleDal : IRoleDal
    {
        private RoleManager<ApplicationRoles> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        public EfRoleDal()
        {
            _roleManager = new RoleManager<ApplicationRoles>(new RoleStore<ApplicationRoles>(new ApplicationContext()));
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationContext()));
        }
        public void AddToRole(string Role, string UserId)
        {
            _userManager.AddToRole(UserId,Role);
            var user = _userManager.FindById(UserId);
            user.Role = Role;
            _userManager.Update(user);
        }

        public void RemoveToRole(string Role, string UserId)
        {
            var user = _userManager.FindById(UserId);
            if(user.Role == "Misafir")
                {
                }
            else
            {
                _userManager.RemoveFromRole(UserId, Role);
                _userManager.AddToRole(UserId,"Misafir");
                user.Role = "Misafir";
            }
            
            _userManager.Update(user);
        }

        public void RoleAdd(Roles role)
        {
            ApplicationRoles entity = new ApplicationRoles();
            entity.Name = role.RoleName;
            _roleManager.Create(entity);
        }

        public void RoleDelete(Roles role)
        {
            var users = _userManager.Users.Where(i => i.Role == role.RoleName).ToList();

            foreach (var user in users)
            {
                _userManager.RemoveFromRole(user.Id,role.RoleName);
                user.Role = "Misafir";
                _userManager.Update(user);
            }

            var entity = _roleManager.FindByName(role.RoleName);
            _roleManager.Delete(entity);
        }

        public List<Roles> GetAll()
        {
            return _roleManager.Roles.Select(i => new Roles
            {
                RoleName = i.Name,
                RoleID = i.Id
            }).ToList();
        }

        public Roles Get(string roleid)
        {
            var role = _roleManager.FindById(roleid);
            Roles model = new Roles();
            model.RoleID = role.Id;
            model.RoleName = role.Name;

            return model;
        }
    }
}
