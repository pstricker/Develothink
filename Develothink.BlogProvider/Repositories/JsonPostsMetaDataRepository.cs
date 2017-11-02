using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Develothink.BlogProvider.Entities;
using Develothink.BlogProvider.Extensions;
using Newtonsoft.Json;

namespace Develothink.BlogProvider.Repositories
{
    public class JsonPostsMetaDataRepository : IPostsMetaDataRepositry
    {
        private readonly ICollection<BlogPost> _blogPosts;

        public JsonPostsMetaDataRepository(string path)
        {
            _blogPosts = JsonConvert.DeserializeObject<ICollection<BlogPost>>(File.ReadAllText(path));
        }

        public ICollection<BlogPost> GetAllPosts()
        {
            return _blogPosts.OrderByDescending(p => p.Posted).ToArray();
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

        public ICollection<BlogPost> SearchBlogPosts(string searchTerm)
        {
            var posts = new List<BlogPost>();

            // Add an instance of a post each time it hits on a search term
            foreach (var term in searchTerm.ToSearchableStringArray())
            {
                posts.AddRange(_blogPosts.Where(p => p.Description.ToLower().Contains(term)));
                posts.AddRange(_blogPosts.Where(p => p.Title.ToLower().Contains(term)));
                posts.AddRange(_blogPosts.Where(p => p.Tags.Contains(term)));
            }

            var weightedResults = WeightedSearchResults(posts);

            return weightedResults.OrderByDescending(r => r.Value)
                                  .Select(result => _blogPosts.FirstOrDefault(p => p.Id == result.Key)).ToList();
        }

        private static Dictionary<int, int> WeightedSearchResults(IEnumerable<BlogPost> posts)
        {
            // Once we have our list of posts, there will likely be some duplicates since matches
            // can occur with more than one search term. We will use the number of times a post 
            // matched a search term to serve as a quick way to assign weight to a result
            var weightedResults = new Dictionary<int, int>();

            foreach (var post in posts)
            {
                if (weightedResults.ContainsKey(post.Id))
                {
                    weightedResults[post.Id]++;
                }
                else
                {
                    weightedResults.Add(post.Id, 1);
                }
            }

            return weightedResults;
        }
    }
}
