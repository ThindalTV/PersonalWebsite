using EricJohansson.Site.Shared.Types.Blog;

namespace EricJohansson.Site.Shared.Interfaces.Blog;

public interface IMusingService
{
    IAsyncEnumerable<MusingListEntryDto> GetLatestMusings(int amount, CancellationToken token);
    IAsyncEnumerable<FullMusingDto> GetMusingsPage(int page, int pageSize, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null);
    IAsyncEnumerable<FullMusingDto> GetMusings(int year, int month, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null);
    Task<FullMusingDto?> GetFullMusing(string id, CancellationToken cancellationToken);
}
