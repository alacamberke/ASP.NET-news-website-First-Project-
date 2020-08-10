using Haber.Interface;
using Haber.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haber.Bll;
using Haber.DAL.Concrete;
using Haber.Models;

namespace Haber.Service
{
    public class RoleService : IRoleService
    {
        private RoleManager _roleManager = new RoleManager(new EfRoleDal());
        public void AddToRole(string Role, string UserId)
        {
            _roleManager.AddToRole(Role, UserId);
        }

        public Roles Get(string roleid)
        {
            return _roleManager.Get(roleid);
        }

        public List<Roles> GetAll()
        {
            return _roleManager.GetAll();
        }

        public void RemoveToRole(string Role, string UserId)
        {
            _roleManager.RemoveToRole(Role, UserId);
        }

        public void RoleAdd(Roles role)
        {
            _roleManager.RoleAdd(role);
        }

        public void RoleDelete(Roles role)
        {
            _roleManager.RoleDelete(role);
        }
    }
}
