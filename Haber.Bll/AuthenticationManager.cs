using Haber.DAL.Abstract.EntityFramework;
using Haber.Interface;
using Haber.Models;
using Haber.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Bll
{
    public class AuthenticationManager : IAuthenticationService
    {
        private IAuthenticationDal _authenticateDal;
        public AuthenticationManager(IAuthenticationDal authenticateDal)
        {
            _authenticateDal = authenticateDal;
        }

        public List<Register> GetAllUsers()
        {
            return _authenticateDal.GetAllUsers();
        }

        public Register GetCurrentUser()
        {
            return _authenticateDal.GetCurrentUser();
        }

        public Register GetUserById(string id)
        {
            return _authenticateDal.GetUserById(id);
        }

        public bool Login(Login usermodel)
        {
            return _authenticateDal.Login(usermodel);
        }

        public void Logout()
        {
            _authenticateDal.Logout();
        }

        public Returning Register(Register usermodel)
        {
            return _authenticateDal.Register(usermodel);
        }

        public void UpdateUser(Register user)
        {
            _authenticateDal.UpdateUser(user);
        }
    }
}
