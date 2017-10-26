using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Develothink.BlogProvider.Extensions;

namespace Develothink.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReadArticle(string article)
        {

            return View(article.ConvertDashToPascalCase());
        }
    }
}