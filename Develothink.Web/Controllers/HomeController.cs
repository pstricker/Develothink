using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Develothink.BlogProvider.Repositories;
using Microsoft.AspNetCore.Mvc;
using Develothink.Web.Models;
using Develothink.BlogProvider.Extensions;

namespace Develothink.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostsMetaDataRepositry _postsMetaDataRepositry;

        public HomeController(IPostsMetaDataRepositry postsMetaDataRepositry)
        {
            _postsMetaDataRepositry = postsMetaDataRepositry;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel()
            {
                LatestBlogPostRoute = _postsMetaDataRepositry.GetLatestPost().Route.ConvertDashToPascalCase()
            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
