using DeveloperAssesment.Core.BlogPosts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperAssesment.Core.BlogPosts.Services.Interface
{
    public interface IBlogPostService
    {
        Task<BlogPostModel?> GetAllBlogPostsAsync();

        Task<BlogPost?> GetBlogPostByIdAsync(int id);

    }
}
