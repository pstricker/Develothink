using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Develothink.BlogProvider.Entities;
using Newtonsoft.Json;

namespace Develothink.BlogProvider.Repositories
{
    public class JsonPostsRepository : IPostsRepositry
    {
        private readonly ICollection<BlogPost> _blogPosts;

        public JsonPostsRepository(string path)
        {
            _blogPosts = JsonConvert.DeserializeObject<ICollection<BlogPost>>(File.ReadAllText(path));
        }

        public ICollection<BlogPost> GetAllPosts()
        {
            return _blogPosts;
        }

        public BlogPost GetPostById(int id)
        {
            return _blogPosts.FirstOrDefault(p => p.Id == id);
        }

        public ICollection<BlogPost> GetPostsByYear(int year)
        {
            return _blogPosts.Where(p => p.Posted.Year == year).ToList();
        }

        public ICollection<BlogPost> GetPostsByYearAndMonth(int year, int month)
        {
            return _blogPosts.Where(p => p.Posted.Year == year && p.Posted.Month == month).ToList();
        }

        public ICollection<BlogPost> GetPostsByTag(string tag)
        {
            return _blogPosts.Where(p => p.Tags.Contains(tag)).ToList();
        }
    }
}
