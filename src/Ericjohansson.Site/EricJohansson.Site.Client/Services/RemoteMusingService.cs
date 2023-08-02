using EricJohansson.Site.Shared.Interfaces.Blog;
using EricJohansson.Site.Shared.Types.Blog;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace Ericjohansson.Site.Client.Services;

public class RemoteMusingService : IMusingService
{
    private readonly HttpClient _httpClient;

    public RemoteMusingService(IHttpClientFactory httpClientFactory)
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

    public async Task<FullMusingDto?> GetFullMusing(string id, CancellationToken cancellationToken)
    {
        var ret = await _httpClient.GetFromJsonAsync<FullMusingDto>($"Musing/{id}", cancellationToken);
        return ret;
    }

    public async IAsyncEnumerable<FullMusingDto> GetMusings(int year, int month, [EnumeratorCancellation] CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
    {
        await Task.CompletedTask;
        yield break;
    }

    public async IAsyncEnumerable<FullMusingDto> GetMusingsPage(int page, int pageSize, [EnumeratorCancellation]CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
    {
        await Task.CompletedTask;
        if(cancellationToken.IsCancellationRequested)
            yield break;
        yield return new FullMusingDto();
    }
}
