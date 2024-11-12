using DeveloperAssesment.Core.BlogPosts.Model;
using DeveloperAssesment.Core.BlogPosts.Services.Interface;
using DeveloperAssessment.Core.BlogPosts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperAssesment.Core.BlogPosts.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly BlogPostRepository _blogPostRepository;

        public BlogPostService(BlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
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
    }
}
