using EricJohansson.Site.Shared.Types.Blog;

namespace EricJohansson.Site.Shared.Interfaces.Blog;

public interface IPostService
{
    IAsyncEnumerable<MusingListEntryDto> GetLatestMusings(int amount, CancellationToken token);
    IAsyncEnumerable<Post> GetPostsPageAsync(int page, int pageSize, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null);
    IAsyncEnumerable<Post> GetPostsAsync(int year, int month, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null);
    Task<Post?> GetPost(string id, CancellationToken cancellationToken);
}
