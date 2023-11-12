namespace EricJohansson.Site.Shared.Types.Blog
{
    public record FullThoughtDto
    {
        public required string Id { get; init; }
        public required string Slug { get; init; }
        public DateOnly? Posted { get; init; }
        public DateTime Created { get; init; }
        public string? ImageUrl { get; init; }
        public string? Title { get; init; }
        public string? Short { get; init; }
        public string? ShortRaw { get; init; }
        public string? Content { get; init; }
        public string? ContentRaw { get; init; }
        public string[]? Tags { get; init; }
    }
}
