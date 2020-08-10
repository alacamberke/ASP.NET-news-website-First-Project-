using Haber.Bll;
using Haber.DAL.Concrete;
using Haber.Interface;
using Haber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Service
{
    public class CommentService : ICommentService
    {
        private CommentManager _commentManager = new CommentManager(new EfCommentDal());

        public void CommentAdd(CommentModel comment)
        {
            _commentManager.CommentAdd(comment);
        }

        public void CommentDelete(int id)
        {
            _commentManager.CommentDelete(id);
        }

        public List<CommentModel> GetAllComments()
        {
            return _commentManager.GetAllComments();
        }

        public CommentModel GetComment(int id)
        {
            return _commentManager.GetComment(id);
        }
    }
}
