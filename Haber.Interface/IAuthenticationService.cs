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
    public interface IAuthenticationService
    {
        [OperationContract]
        Returning Register(Register usermodel);

        [OperationContract]
        bool Login(Login usermodel);

        [OperationContract]
        void Logout();

        [OperationContract]
        List<Register> GetAllUsers();

        [OperationContract]
        Register GetCurrentUser();

        [OperationContract]
        Register GetUserById(string id);

        [OperationContract]
        void UpdateUser(Register user);
    }
}
