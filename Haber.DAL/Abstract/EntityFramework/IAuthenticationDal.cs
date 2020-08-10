using Haber.Entities;
using Haber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.DAL.Abstract.EntityFramework
{
    public interface IAuthenticationDal
    {
        Returning Register(Register usermodel);
        bool Login(Login usermodel);
        void Logout();
        List<Register> GetAllUsers();
        Register GetCurrentUser();
        Register GetUserById(string id);
        void UpdateUser(Register user);
    }
}
