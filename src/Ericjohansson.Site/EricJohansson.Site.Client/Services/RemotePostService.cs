using EricJohansson.Site.Shared.Interfaces.Blog;
using EricJohansson.Site.Shared.Types.Blog;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace Ericjohansson.Site.Client.Services;

public class RemotePostService : IPostService
{
    private readonly HttpClient _httpClient;

    public RemotePostService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("APIClient");
    }

    public async IAsyncEnumerable<MusingListEntryDto> GetLatestMusings(int amount, [EnumeratorCancellation] CancellationToken token)
    {
        var url = $"MusingsList/{amount}";
        var listReturn = await _httpClient.GetFromJsonAsync<IAsyncEnumerable<MusingListEntryDto>>(url, token) ?? throw new HttpRequestException("Couldn't reach server");
        await foreach (var m in listReturn)
        {
            if(token.IsCancellationRequested)
            {
                yield break;
            }
            yield return m;
        }

    }

    public async Task<Post?> GetPost(string id, CancellationToken cancellationToken)
    {
        var ret = await _httpClient.GetFromJsonAsync<Post>($"Post/{id}", cancellationToken);
        return ret;
    }

    public async IAsyncEnumerable<Post> GetPostsAsync(int year, int month, [EnumeratorCancellation] CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
    {
        await Task.CompletedTask;
        yield break;
    }

    public async IAsyncEnumerable<Post> GetPostsPageAsync(int page, int pageSize, [EnumeratorCancellation]CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
    {
        await Task.CompletedTask;
        if(cancellationToken.IsCancellationRequested)
            yield break;
        yield return new Post();
    }
}
