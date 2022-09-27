namespace EricJohansson.Site.Shared.Types.Blog
{
    public class Post
    {
        public string Slug { get; set; }
        public DateTime Posted { get; set; }
        public DateTime Created { get; set; }
        public string? ImageUrl { get; set; }
        public string Title { get; set; }
        public string Short { get; set; }
        public string Content { get; set; }
        public string ContentRaw { get; set; }
        public string[] Tags { get; set; }
    }
}
