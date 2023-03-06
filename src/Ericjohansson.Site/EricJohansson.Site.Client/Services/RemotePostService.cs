using EricJohansson.Site.Shared.Interfaces.Blog;
using EricJohansson.Site.Shared.Types.Blog;
using System.Net.Http.Json;

namespace Ericjohansson.Site.Client.Services;

public class RemotePostService : IPostService
{
    private readonly HttpClient _httpClient;

    public RemotePostService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Post> GetPost(string id, CancellationToken cancellationToken)
    {
        var ret = await _httpClient.GetFromJsonAsync<Post>($"Post/{id}");
        return ret;
    }

    public IAsyncEnumerable<Post> GetPostsAsync(int year, int month, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<Post> GetPostsPageAsync(int page, int pageSize, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
    {
        throw new NotImplementedException();
    }
}
