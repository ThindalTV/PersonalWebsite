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
    public class StaticPostService : IPostService
    {
        public Task<Post> GetPost(string id, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Post()
            {
                Slug = $"TestPost-Single",
                Created = new DateTime(2022, 09, 27),
                Posted = new DateOnly(2022, 09, 27),
                Title = $"Static post - Single",
                Short = "This is a static post short",
                Content = "This is a static post content",
                ContentRaw = "{ text: 'This is a static post content'}",
                Tags = new string[] { "static", "test", "post" },
                ImageUrl = null
            });
        }

        public async IAsyncEnumerable<Post> GetPostsPageAsync(int page, int pageSize, [EnumeratorCancellation] CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
        {
            for (int i = 0; i < pageSize; i++) {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return new Post()
                {
                    Slug = $"TestPost{i}",
                    Created = new DateTime(2022, 09, 27),
                    Posted = new DateOnly(2022, 09, 27),
                    Title = $"Static post {i}",
                    Short = "This is a static post short",
                    Content = "This is a static post content",
                    ContentRaw = "{ text: 'This is a static post content'}",
                    Tags = new string[] { "static", "test", "post" },
                    ImageUrl = null
                };

                await Task.CompletedTask;
            }
        }

        public async IAsyncEnumerable<Post> GetPostsAsync(int year, int month, [EnumeratorCancellation]CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
        {
            for (int i = 1; i < 11; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return new Post()
                {
                    Slug = $"TestPost{i}",
                    Created = new DateTime(year, month, i),
                    Posted = new DateOnly(year, month, i),
                    Title = $"Static post {i}",
                    Short = "This is a static post short",
                    Content = "This is a static post content",
                    ContentRaw = "{ text: 'This is a static post content'}",
                    Tags = new string[] { "static", "test", "post" },
                    ImageUrl = null
                };

                await Task.CompletedTask;
            }
        }
    }
}
