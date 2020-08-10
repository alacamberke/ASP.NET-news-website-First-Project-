using Haber.Interface;
using Haber.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haber.DAL.Abstract.EntityFramework;
using Haber.Models;

namespace Haber.Bll
{
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public void AddToRole(string Role, string UserId)
        {
            _roleDal.AddToRole(Role,UserId);
        }

        public Roles Get(string roleid)
        {
            return _roleDal.Get(roleid);
        }

        public List<Roles> GetAll()
        {
            return _roleDal.GetAll();
        }

        public void RemoveToRole(string Role, string UserId)
        {
            _roleDal.RemoveToRole(Role,UserId);
        }

        public void RoleAdd(Roles role)
        {
            _roleDal.RoleAdd(role);
        }

        public void RoleDelete(Roles role)
        {
            _roleDal.RoleDelete(role);
        }
    }
}
