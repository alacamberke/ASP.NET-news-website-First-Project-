using Haber.Entities;
using Haber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Interface
{
    [ServiceContract]
    public interface IRoleService
    {
        [OperationContract]
        void RoleAdd(Roles role);

        [OperationContract]
        void RoleDelete(Roles role);

        [OperationContract]
        void AddToRole(string Role, string UserId);

        [OperationContract]
        void RemoveToRole(string Role, string UserId);

        [OperationContract]
        List<Roles> GetAll();

        [OperationContract]
        Roles Get(string roleid);

    }
}
