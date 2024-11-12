using DeveloperAssesment.Core.BlogPosts.Model;
using DeveloperAssesment.Core.BlogPosts.Services.Interface;
using DeveloperAssessment.Web.Models.CommentFormModel;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperAssessment.Web.Controllers
{
    public class CommentFormController : Controller
    {
        private readonly IBlogPostService _blogPostservice;

        public CommentFormController(IBlogPostService blogPostservice)
        {
            _blogPostservice = blogPostservice;
        }

        [HttpPost]
        public async Task<IActionResult> Submit(CommentFormSubmitModel submission)
        {

            var comment = new Comment()
            {
                Name = submission.Name,
                EmailAddress = submission.Email,
                Date = DateTime.Now,
                Message = submission.Message,
            };

            var success = await _blogPostservice.AddComment(submission.FormId, comment).ConfigureAwait(false);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
