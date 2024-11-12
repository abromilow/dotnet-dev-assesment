namespace DeveloperAssesment.Core.BlogPosts.Model
{
    public class BlogPostModel
    {
        public BlogPostModel()
        {
            BlogPosts = [];
        }

        public List<BlogPost> BlogPosts { get; set; }

    }

    public class BlogPost
    {
        public BlogPost()
        {
            Comments = [];
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string? Title { get; set; }

        public string? Image { get; set; }

        public string? HtmlContent { get; set; }

        public List<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public string? Name { get; set; }

        public DateTime Date { get; set; }

        public string? EmailAddress { get; set; }

        public string? Message { get; set; }
    }
}
