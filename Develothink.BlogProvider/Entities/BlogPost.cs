using System;
using System.Collections.Generic;
using System.Text;

namespace Develothink.BlogProvider.Entities
{
    public class BlogPost
    {
        public BlogPost()
        {
            
        }

        public int Id { get; set; }
        public DateTime Posted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<string> Tags { get; set; }
        public string Route { get; set; }

    }
}
