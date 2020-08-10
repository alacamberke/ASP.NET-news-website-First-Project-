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
using System.Web;

namespace Haber.DAL.Concrete
{
    public class EfHaberDal : IHaberDal
    {
        HaberContext context = new HaberContext();
        private UserManager<ApplicationUser> _userManager;
        public EfHaberDal()
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationContext()));
        }
        public void Add(HaberModel model)
        {
            var haber = new Entities.Haber();
            haber.HaberTitle = model.HaberTitle;
            haber.HaberContent = model.HaberContent;
            haber.HaberSource = model.HaberSource;
            haber.KategoriId = model.KategoriId;
            haber.View = model.View;
            haber.HaberOwner = model.HaberOwner;

            List<string> adresses = new List<string>()
            { };

            
            haber.Users = adresses;
            List<Comment> comments = new List<Comment>();
            haber.Comments = comments;

            context.Haberler.Add(haber);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var haber = context.Haberler.Find(id);
            context.Haberler.Remove(haber);
            context.SaveChanges();

        }

        public HaberModel Get(int id)
        {
            var haber = context.Haberler.Find(id);

            HaberModel model = new HaberModel();
            model.HaberID = haber.HaberID;
            model.HaberTitle = haber.HaberTitle;
            model.HaberContent = haber.HaberContent;
            model.HaberOwner = haber.HaberOwner;
            model.HaberSource = haber.HaberSource;
            model.KategoriId = haber.KategoriId;
            model.View = haber.View;
            model.Users = haber.Users;
            if(haber.Comments == null)
            {
                List<Comment> comments = new List<Comment>();
                model.Comments = comments;
            }
            else
            {
                model.Comments = haber.Comments;
            }
            var user = _userManager.FindById(model.HaberOwner);
            model.HaberOwnerName = user.UserName;

            return model;
        }

        public List<HaberModel> GetAll()
        {
            return context.Haberler.Select(i => new HaberModel
            {
                HaberID = i.HaberID,
                HaberTitle = i.HaberTitle,
                KategoriName = i.Kategorisi.KategoriName,
                HaberContent = i.HaberContent,
                HaberOwner = i.HaberOwner,
                KategoriId = i.KategoriId,
                HaberSource = i.HaberSource,
                View = i.View,
                

            }).ToList();
        }

        public List<HaberModel> Listing(KategoriModel kategorimodel)
        {
            if(kategorimodel.Haberler == null)
            {
                kategorimodel.Haberler = new List<Entities.Haber>();
            }
            var haberlerk = kategorimodel.Haberler.Select(i => new HaberModel
            {
                HaberID = i.HaberID,
                HaberTitle = i.HaberTitle,
                HaberContent = i.HaberContent,
                HaberOwner = i.HaberOwner,
                HaberSource = i.HaberSource,
                KategoriId = i.KategoriId,
                View = i.View,
                KategoriName = i.Kategorisi.KategoriName,
            }).ToList();

            return haberlerk;
        }

        public HaberModel View(HaberModel haber)
        {
            var entity = context.Haberler.Find(haber.HaberID);
            entity.HaberContent = haber.HaberContent;
            entity.HaberOwner = haber.HaberOwner;
            entity.HaberSource = haber.HaberSource;
            entity.HaberTitle = haber.HaberTitle;
            entity.KategoriId = haber.KategoriId;
            entity.Users = haber.Users;
            entity.Comments = haber.Comments;

            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (entity.Users.Any(i => i == ip))
            {
                return haber;
            }
            else
            {
                IpAdresses adress = new IpAdresses();
                adress.ipadress = ip;

                if (context.ipadresses.Any(i => i.ipadress == ip) == false)
                {
                    context.ipadresses.Add(adress);
                }

                entity.Users.Add(ip);
                entity.View += 1;

                var model = new HaberModel();
                model.HaberContent = entity.HaberContent;
                model.HaberID = entity.HaberID;
                model.HaberOwner = entity.HaberOwner;
                model.HaberSource = entity.HaberSource;
                model.HaberTitle = entity.HaberTitle;
                model.KategoriId = entity.KategoriId;
                model.Users = entity.Users;
                model.View = entity.View;
                model.Comments = entity.Comments;

                var user = _userManager.FindById(model.HaberOwner);
                model.HaberOwnerName = user.UserName;

                context.SaveChanges();
                return model;
            }
        }
    }
}
