namespace EricJohansson.Site.Shared.Types.Blog
{
    public record FullThoughtDto
    {
        public required string Id { get; init; }
        public required string Slug { get; init; }
        public required DateOnly? Posted { get; init; }
        public required DateTime Created { get; init; }
        public required string? ImageUrl { get; init; }
        public required string Title { get; init; }
        public required string Short { get; init; }
        public required string? ShortRaw { get; init; }
        public required string Content { get; init; }
        public required string? ContentRaw { get; init; }
        public required string[]? Tags { get; init; }
    }
}
