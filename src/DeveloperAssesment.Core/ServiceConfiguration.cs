using DeveloperAssesment.Core.BlogPosts.Services;
using DeveloperAssesment.Core.BlogPosts.Services.Interface;
using DeveloperAssesment.Core.Caching.Services;
using DeveloperAssesment.Core.Caching.Services.Interfaces;
using DeveloperAssessment.Core.BlogPosts.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperAssesment.Core
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            return services.AddSingleton<ICacheService, CachingService>()
                .AddSingleton<BlogPostRepository>()
                .AddSingleton<IBlogPostService, BlogPostService>();
        }
    }
}
