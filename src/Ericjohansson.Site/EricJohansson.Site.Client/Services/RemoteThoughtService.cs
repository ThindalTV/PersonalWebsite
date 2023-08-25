using EricJohansson.Site.Shared.Interfaces.Blog;
using EricJohansson.Site.Shared.Types.Blog;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace Ericjohansson.Site.Client.Services;

public class RemoteThoughtService : IThoughtsService
{
    private readonly HttpClient _httpClient;

    public RemoteThoughtService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("APIClient");
    }

    public async IAsyncEnumerable<ThoughtsListEntryDto> GetLatestThoughts(int amount, [EnumeratorCancellation] CancellationToken token)
    {
        var url = $"MusingsList/{amount}";
        var listReturn = await _httpClient.GetFromJsonAsync<IAsyncEnumerable<ThoughtsListEntryDto>>(url, token) ?? throw new HttpRequestException("Couldn't reach server");
        await foreach (var m in listReturn)
        {
            if(token.IsCancellationRequested)
            {
                yield break;
            }
            yield return m;
        }

    }

    public async Task<FullThoughtDto?> GetFullThought(int year, string slug, CancellationToken cancellationToken)
    {
        return await _httpClient.GetFromJsonAsync<FullThoughtDto>($"Musing/{year}/{slug}", cancellationToken);
    }

    public async IAsyncEnumerable<FullThoughtDto> GetThoughts(int year, int month, [EnumeratorCancellation] CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
    {
        await Task.CompletedTask;
        yield break;
    }

    public async IAsyncEnumerable<FullThoughtDto> GetThoughtsPage(int page, int pageSize, [EnumeratorCancellation]CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
    {
        await Task.CompletedTask;
        if(cancellationToken.IsCancellationRequested)
            yield break;
        yield return new FullThoughtDto();
    }
}
