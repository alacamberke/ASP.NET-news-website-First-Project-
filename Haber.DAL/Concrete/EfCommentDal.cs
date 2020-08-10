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
    public class EfCommentDal : ICommentDal
    {
        private HaberContext context = new HaberContext();
        private UserManager<ApplicationUser> _userManager;
        public EfCommentDal()
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationContext()));
        }
        public void CommentAdd(CommentModel comment)
        {
            Comment entity = new Comment();
            entity.CommentContent = comment.CommentContent;
            entity.CommentOwnerID = HttpContext.Current.User.Identity.GetUserId();
            entity.CommentOwner = _userManager.FindById(entity.CommentOwnerID).UserName;
            entity.HaberId = comment.HaberId;

            context.Comments.Add(entity);
            context.SaveChanges();
        }

        public void CommentDelete(int id)
        {
            var comment = context.Comments.Find(id);
            context.Comments.Remove(comment);
            context.SaveChanges();
        }

        public List<CommentModel> GetAllComments()
        {
            return context.Comments.Select(i=> new CommentModel() 
            {
                CommentContent = i.CommentContent,
                CommentID = i.CommentID,
                CommentOwnerId = i.CommentOwnerID,
                CommentOwner = i.CommentOwner,
                HaberId = i.HaberId
            }).ToList();
        }

        public CommentModel GetComment(int id)
        {
            var comment = context.Comments.Find(id);
            CommentModel model = new CommentModel();
            model.CommentContent = comment.CommentContent;
            model.CommentID = comment.CommentID;
            model.CommentOwner = comment.CommentOwner;
            model.HaberId = comment.HaberId;

            return model;
        }
    }
}
