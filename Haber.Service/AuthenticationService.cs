using Haber.Bll;
using Haber.DAL.Concrete;
using Haber.Interface;
using Haber.Models;
using Haber.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Service
{
    public class AuthenticationService: IAuthenticationService
    {
        private AuthenticationManager _authenticateManager = new AuthenticationManager(new EfAuthenticateDal());

        public List<Register> GetAllUsers()
        {
            return _authenticateManager.GetAllUsers();
        }

        public Register GetCurrentUser()
        {
            return _authenticateManager.GetCurrentUser();
        }

        public Register GetUserById(string id)
        {
            return _authenticateManager.GetUserById(id);
        }

        public bool Login(Login usermodel)
        {
            return _authenticateManager.Login(usermodel);
        }

        public void Logout()
        {
            _authenticateManager.Logout();
        }

        public Returning Register(Register usermodel)
        {
            return _authenticateManager.Register(usermodel);
        }

        public void UpdateUser(Register user)
        {
            _authenticateManager.UpdateUser(user);
        }
    }
}
