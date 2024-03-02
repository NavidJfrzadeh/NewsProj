using Entities;
using Infrastructure.EF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HW16.Controllers
{
    public class CommentController : Controller
    {
        CommentRepository CommentRepo = new CommentRepository();

        public IActionResult LikeComment(int id)
        {
            var comment = CommentRepo.Like(id);
            return RedirectToAction("NewsDetails", "Reporter", new { id = comment.NewsId });
        }

        public IActionResult DisLikeComment(int id)
        {
            var comment = CommentRepo.DisLike(id);
            return RedirectToAction("NewsDetails", "Reporter", new { id = comment.NewsId });
        }
    }
}
