using Haber.Bll;
using Haber.DAL.Abstract.EntityFramework;
using Haber.DAL.Concrete;
using Haber.Interface;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Haber.Infastructure
{
    class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBllBindings();
        }
        private void AddBllBindings()
        {
            _ninjectKernel.Bind<IHaberService>().To<HaberManager>()
                .WithConstructorArgument("haberDal", new EfHaberDal());

            _ninjectKernel.Bind<IKategoriService>().To<KategoriManager>()
                .WithConstructorArgument("kategoriDal", new EfKategoriDal());

            _ninjectKernel.Bind<IAuthenticationService>().To<AuthenticationManager>()
                .WithConstructorArgument("authenticateDal", new EfAuthenticateDal());

            _ninjectKernel.Bind<IRoleService>().To<RoleManager>()
                .WithConstructorArgument("roleDal", new EfRoleDal());

            _ninjectKernel.Bind<ICommentService>().To<CommentManager>()
                .WithConstructorArgument("commentDal", new EfCommentDal());

        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)
                _ninjectKernel.Get(controllerType);
        }
    }
}