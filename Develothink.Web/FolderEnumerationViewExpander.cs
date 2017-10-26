using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc.Razor;


namespace Develothink.Web
{
    public class FolderEnumerationViewExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            var locations = viewLocations.ToList();
            
            foreach (var directory in Directory.EnumerateDirectories("Views/Blog", "*", SearchOption.AllDirectories))
            {
                locations.Add($"/{directory.Replace("\\","/")}" + "/{0}.cshtml");
            }

            return locations.AsEnumerable();
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //nothing to do here.  
        }
    }
}