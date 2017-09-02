using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactDemo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> _comments;

        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Lojza" + DateTime.Now.ToString(),
                    Text = "Alois"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Pepa",
                    Text = "JoseF"
                }
            };
        }

        // GET: /<controller>/
        public ActionResult Index()
        {
            return View();
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }

        [Route("comments/new")]
        
        public ActionResult AddComment(CommentModel comment)
        {
            comment.Id = _comments.Count() + 1;
            _comments.Add(comment);
            return Content("Success :)");
        }
    }
}
