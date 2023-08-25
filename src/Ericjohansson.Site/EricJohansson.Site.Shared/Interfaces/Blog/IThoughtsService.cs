using EricJohansson.Site.Shared.Types.Blog;

namespace EricJohansson.Site.Shared.Interfaces.Blog;

public interface IThoughtsService
{
    IAsyncEnumerable<ThoughtsListEntryDto> GetLatestThoughts(int amount, CancellationToken token);
    IAsyncEnumerable<FullThoughtDto> GetThoughtsPage(int page, int pageSize, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null);
    IAsyncEnumerable<FullThoughtDto> GetThoughts(int year, int month, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null);
    Task<FullThoughtDto?> GetFullThought(int year, string slug, CancellationToken cancellationToken);
}
