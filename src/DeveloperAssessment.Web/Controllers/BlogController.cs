using DeveloperAssesment.Core.BlogPosts.Services.Interface;
using DeveloperAssessment.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperAssessment.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public BlogController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public async Task<IActionResult> Index()
        {
            var viewName = "~/Views/BlogPosts/index.cshtml";
            var vm = new BlogListingViewModel();

            var blogPosts = await _blogPostService.GetAllBlogPostsAsync().ConfigureAwait(false);

            if (blogPosts == null)
            {
                return Content(string.Empty);
            }

            vm.BlogPosts = blogPosts;

            return View(viewName, vm);
        }

        public async Task<IActionResult> SingleBlog(int id)
        {
            var viewName = "~/Views/BlogPosts/SingleBlog.cshtml";

            var vm = new SingleBlogViewModel();

            var blogPost = await _blogPostService.GetBlogPostByIdAsync(id).ConfigureAwait(false);

            if (blogPost == null)
            {
                return Content(string.Empty);
            }

            vm.BlogPost = blogPost;

            return View(viewName, vm);
        }
    }
}
