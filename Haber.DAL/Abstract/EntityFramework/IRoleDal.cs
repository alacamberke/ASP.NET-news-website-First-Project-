using Haber.Entities;
using Haber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.DAL.Abstract.EntityFramework
{
    public interface IRoleDal
    {
        void RoleAdd(Roles role);
        void RoleDelete(Roles role);
        void AddToRole(string Role, string UserId);
        void RemoveToRole(string Role, string UserId);
        List<Roles> GetAll();
        Roles Get(string roleid);
    }
}
