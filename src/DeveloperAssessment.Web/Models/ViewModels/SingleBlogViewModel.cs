using DeveloperAssesment.Core.BlogPosts.Model;

namespace DeveloperAssessment.Web.Models.ViewModels
{
    public class SingleBlogViewModel
    {
        public SingleBlogViewModel()
        {
            BlogPost = new BlogPost();
        }
        public BlogPost BlogPost { get; set; }
    }
}
