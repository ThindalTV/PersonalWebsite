using EricJohansson.Site.Shared.Interfaces.Blog;
using EricJohansson.Site.Shared.Types.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EricJohansson.Site.Shared.Service
{
    public class StaticMusingService : IMusingService
    {
        public async Task<FullMusingDto?> GetFullMusing(string id, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return new FullMusingDto()
            {
                Slug = $"TestMusing-Single",
                Created = new DateTime(2022, 09, 27),
                Posted = new DateOnly(2022, 09, 27),
                Title = $"Static Musing - Single",
                Short = "This is a static musing short",
                Content = "This is a static musing content",
                ContentRaw = "{ text: 'This is a static musing content'}",
                Tags = new string[] { "static", "test", "musing" },
                ImageUrl = null
            };
        }

        public async IAsyncEnumerable<FullMusingDto> GetMusingsPage(int page, int pageSize, [EnumeratorCancellation] CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
        {
            for (int i = 0; i < pageSize; i++) {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return new FullMusingDto()
                {
                    Slug = $"TestMusing{i}",
                    Created = new DateTime(2022, 09, 27),
                    Posted = new DateOnly(2022, 09, 27),
                    Title = $"Static musing {i}",
                    Short = "This is a static musing short",
                    Content = "This is a static musing content",
                    ContentRaw = "{ text: 'This is a static musing content'}",
                    Tags = new string[] { "static", "test", "musing" },
                    ImageUrl = null
                };

                await Task.CompletedTask;
            }
        }

        public async IAsyncEnumerable<FullMusingDto> GetMusings(int year, int month, [EnumeratorCancellation]CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
        {
            for (int i = 1; i < 11; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return new FullMusingDto()
                {
                    Slug = $"TestMusing{i}",
                    Created = new DateTime(year, month, i),
                    Posted = new DateOnly(year, month, i),
                    Title = $"Static musing {i}",
                    Short = "This is a static musing short",
                    Content = "This is a static musing content",
                    ContentRaw = "{ text: 'This is a static musing content'}",
                    Tags = new string[] { "static", "test", "musing" },
                    ImageUrl = null
                };

                await Task.CompletedTask;
            }
        }

        public async IAsyncEnumerable<MusingListEntryDto> GetLatestMusings(int amount, [EnumeratorCancellation]CancellationToken token)
        {
            for(int i = 0; i < amount; i++)
            {
                if (token.IsCancellationRequested) yield break;
                string num = (i+1).ToString();
                yield return new MusingListEntryDto(num, DateOnly.FromDateTime(DateTime.Now), $"Musings{num}", null, $"Musings {num} title", $"Musings {num} summary");
            }
            await Task.CompletedTask;
        }
    }
}
