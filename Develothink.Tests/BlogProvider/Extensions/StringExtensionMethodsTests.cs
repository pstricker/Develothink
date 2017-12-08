using Develothink.BlogProvider.Extensions;
using System;
using Xunit;

namespace Develothink.Tests
{
    public class StringExtensionMethodsTests
    {
        [Fact]
        public void ConvertDashToPascalCase_CorrectFormat_ConvertsCorrectly()
        {
            Assert.Equal("ThisIsMyBlogPost", "this-is-my-blog-post".ConvertDashToPascalCase());
            Assert.Equal("ThisIsMyBlogPost", "THIS-IS-MY-BLOG-POST".ConvertDashToPascalCase());
        }
    }
}
