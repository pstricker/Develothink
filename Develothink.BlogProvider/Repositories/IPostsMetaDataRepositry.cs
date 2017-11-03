using System;
using System.Collections.Generic;
using System.Text;
using Develothink.BlogProvider.Entities;

namespace Develothink.BlogProvider.Repositories
{
    public interface IPostsMetaDataRepositry
    {
        ICollection<BlogPost> GetAllPosts();
        BlogPost GetPostById(int id);
        BlogPost GetLatestPost();
        ICollection<BlogPost> GetPostsByTag(string tag);
        ICollection<BlogPost> GetPostsByYear(int year);
        ICollection<BlogPost> GetPostsByYearAndMonth(int year, int month);
        ICollection<BlogPost> SearchBlogPosts(string searchTerms);
    }
}
