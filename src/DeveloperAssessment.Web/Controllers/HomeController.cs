using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DeveloperAssessment.Web.Models;
using DeveloperAssessment.Core.BlogPosts.Repository;

namespace DeveloperAssessment.Web.Controllers;

public class HomeController : Controller
{
    private const string ViewName = "~/Views/Home/index.cshtml";
    private readonly ILogger<HomeController> _logger;
    private readonly BlogPostRepository _blogPostRepository;

    public HomeController(ILogger<HomeController> logger, BlogPostRepository blogPostRepository)
    {
        _logger = logger;
        _blogPostRepository = blogPostRepository;
    }

    public async Task<IActionResult> Index()
    {
        var currentDirectory = await _blogPostRepository.GetBlogPosts().ConfigureAwait(false);
        return View(ViewName);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
