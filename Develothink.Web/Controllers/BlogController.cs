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
        private readonly IPostsMetaDataRepositry _postsMetaDataRepositry;

        public BlogController(IPostsMetaDataRepositry postsMetaDataRepositry)
        {
            _postsMetaDataRepositry = postsMetaDataRepositry;
        }

        public IActionResult Index()
        {
            return View(_postsMetaDataRepositry.GetAllPosts());
        }

        public IActionResult ReadArticle(string article)
        {
            return View(article.Replace("/","").ConvertDashToPascalCase());
        }

        public IActionResult Search(string term)
        {
            return View(_postsMetaDataRepositry.SearchBlogPosts(term));
        }
    }
}