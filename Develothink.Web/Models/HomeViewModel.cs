using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Develothink.BlogProvider.Entities;
using Develothink.BlogProvider.Repositories;

namespace Develothink.Web.Models
{
    public class HomeViewModel
    {
        public string LatestBlogPostRoute { get; set; }
        public ICollection<BlogPost> LatestPosts { get; set; }
    }
}
