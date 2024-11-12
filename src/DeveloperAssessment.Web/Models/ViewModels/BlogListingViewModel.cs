using DeveloperAssesment.Core.BlogPosts.Model;

namespace DeveloperAssessment.Web.Models.ViewModels
{
    public class BlogListingViewModel
    {
        public BlogListingViewModel()
        {
            BlogPosts = new BlogPostModel();
        }

        public BlogPostModel BlogPosts { get; set; }
    }
}
