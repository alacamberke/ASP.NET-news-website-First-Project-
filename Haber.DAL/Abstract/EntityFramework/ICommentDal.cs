using Haber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.DAL.Abstract.EntityFramework
{
    public interface ICommentDal
    {
        void CommentAdd(CommentModel comment);
        List<CommentModel> GetAllComments();
        CommentModel GetComment(int id);
        void CommentDelete(int id);
    }
}
