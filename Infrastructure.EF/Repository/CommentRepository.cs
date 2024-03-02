using Entities;
using Infrastructure.EF.DataBases;
using System.Runtime.InteropServices;

namespace Infrastructure.EF.Repository
{
    public class CommentRepository
    {
        AppDbContext Context = new AppDbContext();

        public Comment GetById(int id)
        {
            var comment = Context.Comments.FirstOrDefault(c => c.Id == id);
            return comment ?? null;
        }

        public Comment Like(int id)
        {
            var targetComment = GetById(id);
            if (targetComment != null)
            {
                targetComment.Likes += 1;
                Context.SaveChanges();
                return targetComment;
            }
            return targetComment;
        }

        public Comment DisLike(int id)
        {
            var targetComment = GetById(id);
            if (targetComment != null)
            {
                targetComment.Likes -= 1;
                Context.SaveChanges();
                return targetComment;
            }
            return targetComment;
        }
    }
}
