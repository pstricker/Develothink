using System;
using System.Collections.Generic;
using System.Text;
using Develothink.BlogProvider.Entities;

namespace Develothink.BlogProvider.Repositories
{
    public interface IPostsRepositry
    {
        ICollection<BlogPost> GetAllPosts();
        BlogPost GetPostById(int id);
        ICollection<BlogPost> GetPostsByTag(string tag);
        ICollection<BlogPost> GetPostsByYear(int year);
        ICollection<BlogPost> GetPostsByYearAndMonth(int year, int month);
    }
}
