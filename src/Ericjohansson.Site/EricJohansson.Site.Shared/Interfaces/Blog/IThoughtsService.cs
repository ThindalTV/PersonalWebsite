using EricJohansson.Site.Shared.Types.Blog;

namespace EricJohansson.Site.Shared.Interfaces.Blog;

public interface IThoughtsService
{
    Task<int> GetThoughtCount(CancellationToken cancellationToken);
    IAsyncEnumerable<ThoughtsListEntryDto> GetLatestThoughts(int amount, CancellationToken cancellationToken);
    IAsyncEnumerable<FullThoughtDto> GetThoughtsPage(int page, int pageSize, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null);
    IAsyncEnumerable<FullThoughtDto> GetThoughts(int startIndex, int count, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null);
    Task<FullThoughtDto?> GetFullThought(int year, string slug, CancellationToken cancellationToken);

    Task<ThoughtsListEntryDto?> GetPreviousThought(string currentThoughtId, CancellationToken cancellationToken);
    Task<ThoughtsListEntryDto?> GetNextThought(string currentThoughtId, CancellationToken cancellationToken);
}
