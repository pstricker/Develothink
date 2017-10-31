using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Develothink.BlogProvider.Extensions;
using Develothink.BlogProvider.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace Develothink.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostsRepositry _postsRepositry;

        public BlogController(IPostsRepositry postsRepositry)
        {
            _postsRepositry = postsRepositry;
        }

        public IActionResult Index()
        {
            return View(_postsRepositry.GetAllPosts());
        }

        public IActionResult ReadArticle(string article)
        {
            return View(article.Replace("/","").ConvertDashToPascalCase());
        }
    }
}