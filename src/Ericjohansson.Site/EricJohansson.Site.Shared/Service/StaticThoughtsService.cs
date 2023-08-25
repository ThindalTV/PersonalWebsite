using EricJohansson.Site.Shared.Interfaces.Blog;
using EricJohansson.Site.Shared.Types.Blog;
using System.Runtime.CompilerServices;

namespace EricJohansson.Site.Shared.Service
{
    public class StaticThoughtsService : IThoughtsService
    {
        public async Task<FullThoughtDto?> GetFullThought(int year, string slug, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return new FullThoughtDto()
            {
                Slug = slug,
                Created = new DateTime(year, 09, 27),
                Posted = new DateOnly(year, 09, 27),
                Title = $"Static Thought - Single",
                Short = "This is a static Thought short",
                Content = "This is a static Thought content",
                ContentRaw = "{ text: 'This is a static Thought content'}",
                Tags = new string[] { "static", "test", "Thought" },
                ImageUrl = null
            };
        }

        public async IAsyncEnumerable<FullThoughtDto> GetThoughtsPage(int page, int pageSize, [EnumeratorCancellation] CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
        {
            for (int i = 0; i < pageSize; i++) {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return new FullThoughtDto()
                {
                    Slug = $"TestThought{i}",
                    Created = new DateTime(2022, 09, 27),
                    Posted = new DateOnly(2022, 09, 27),
                    Title = $"Static Thought {i}",
                    Short = "This is a static Thought short",
                    Content = "This is a static Thought content",
                    ContentRaw = "{ text: 'This is a static Thought content'}",
                    Tags = new string[] { "static", "test", "Thought" },
                    ImageUrl = null
                };

                await Task.CompletedTask;
            }
        }

        public async IAsyncEnumerable<FullThoughtDto> GetThoughts(int year, int month, [EnumeratorCancellation]CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
        {
            for (int i = 1; i < 11; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return new FullThoughtDto()
                {
                    Slug = $"TestThought{i}",
                    Created = new DateTime(year, month, i),
                    Posted = new DateOnly(year, month, i),
                    Title = $"Static Thought {i}",
                    Short = "This is a static Thought short",
                    Content = "This is a static Thought content",
                    ContentRaw = "{ text: 'This is a static Thought content'}",
                    Tags = new string[] { "static", "test", "Thought" },
                    ImageUrl = null
                };

                await Task.CompletedTask;
            }
        }

        public async IAsyncEnumerable<ThoughtsListEntryDto> GetLatestThoughts(int amount, [EnumeratorCancellation]CancellationToken token)
        {
            for(int i = 0; i < amount; i++)
            {
                if (token.IsCancellationRequested) yield break;
                string num = (i+1).ToString();
                string? imageUrl = null;
                if(i % 2 == 0)
                {
                    imageUrl = "https://via.placeholder.com/1500";
                }
                var postDate = DateOnly.FromDateTime(DateTime.Now);
                var slug = $"thought{i}";
                yield return new ThoughtsListEntryDto(
                        Id:num, 
                        Posted: postDate, 
                        Url: $"thoughts/{postDate.Year}/{slug}",
                        Slug: slug, 
                        ImageUrl: imageUrl, 
                        Title: $"Thought {num} title", 
                        Summary: $"Thought {num} summary");
            }
            await Task.CompletedTask;
        }
    }
}
