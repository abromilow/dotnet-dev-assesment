using DeveloperAssesment.Core.BlogPosts.Model;
using DeveloperAssesment.Core.BlogPosts.Services.Interface;
using DeveloperAssesment.Core.Caching.Services.Interfaces;
using DeveloperAssessment.Core.BlogPosts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeveloperAssesment.Core.BlogPosts.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly BlogPostRepository _blogPostRepository;
        private readonly ICacheService _cacheService;
        public BlogPostService(BlogPostRepository blogPostRepository, ICacheService cacheService)
        {
            _blogPostRepository = blogPostRepository;
            _cacheService = cacheService;
        }

        public async Task<BlogPostModel?> GetAllBlogPostsAsync()
        {
            return await _blogPostRepository.GetBlogPosts().ConfigureAwait(false);
        }

        public async Task<BlogPost?> GetBlogPostByIdAsync(int id)
        {
            var allBlogs = await _blogPostRepository.GetBlogPosts().ConfigureAwait(false);

            if (allBlogs == null)
            {
                return null;
            }

            return allBlogs.BlogPosts.FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> AddComment(int formId, Comment comment)
        {
            var allBlogs = await _blogPostRepository.GetBlogPosts().ConfigureAwait(false);

            if (allBlogs == null)
            {
                return false;
            }

            var requiredForm = allBlogs.BlogPosts.FirstOrDefault(x => x.Id == formId);

            if (requiredForm == null)
            {
                return false;
            }

            requiredForm.Comments.Add(comment);

            return await UpdateBlogsJson(allBlogs).ConfigureAwait(false);
        }

        private async Task<bool> UpdateBlogsJson(BlogPostModel blogPosts)
        {
            try
            {
                var blogsPath = $"{Directory.GetCurrentDirectory()}\\App_Data\\Blog-Posts.json";

                var blogsJson = JsonSerializer.Serialize(blogPosts, new JsonSerializerOptions { WriteIndented = true });

                await File.WriteAllTextAsync(blogsPath, blogsJson).ConfigureAwait(false);

                _cacheService.DeleteCache("AllBlogs");
            }
            catch
            {
                return false;
            }

            return true;
        }

    }
}
