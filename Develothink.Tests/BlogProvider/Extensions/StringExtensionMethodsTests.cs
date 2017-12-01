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
            Assert.Equal("this-is-my-blog-post".ConvertDashToPascalCase(), "ThisIsMyBlogPost");
            Assert.Equal("THIS-IS-MY-BLOG-POST".ConvertDashToPascalCase(), "ThisIsMyBlogPost");
        }
    }
}
