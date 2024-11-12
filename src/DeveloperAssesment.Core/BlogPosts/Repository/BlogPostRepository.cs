using DeveloperAssesment.Core.BlogPosts.Model;
using DeveloperAssesment.Core.Caching.Services.Interfaces;
using System.Text.Json;

namespace DeveloperAssessment.Core.BlogPosts.Repository
{
    public class BlogPostRepository
    {
        private readonly ICacheService _cacheService;

        public BlogPostRepository(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<BlogPostModel?> GetBlogPosts()
        {
            return await _cacheService.GetOrCreateAsync<BlogPostModel?>("AllBlogs",
                async () =>
                {
                    var blogPostsPath = $"{Directory.GetCurrentDirectory()}\\App_Data\\Blog-Posts.json";

                    if (!File.Exists(blogPostsPath))
                    {
                        return null;
                    }

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    using FileStream fileStream = File.OpenRead(blogPostsPath);
                    var test = await JsonSerializer.DeserializeAsync<BlogPostModel>(fileStream, options);

                    return test;

                });
        }
    }
}
