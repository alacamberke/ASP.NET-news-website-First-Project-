using Haber.DAL.Abstract.EntityFramework;
using Haber.Interface;
using Haber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Bll
{
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(CommentModel comment)
        {
            _commentDal.CommentAdd(comment);
        }

        public void CommentDelete(int id)
        {
            _commentDal.CommentDelete(id);
        }

        public List<CommentModel> GetAllComments()
        {
            return _commentDal.GetAllComments();
        }

        public CommentModel GetComment(int id)
        {
            return _commentDal.GetComment(id);
        }
    }
}
