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
        public async IAsyncEnumerable<Post> GetPostsAsync(int page, int pageSize, [EnumeratorCancellation] CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
        {
            for (int i = 0; i < pageSize; i++) {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return new Post()
                {
                    Slug = $"TestPost{i}",
                    Created = new DateTime(2022, 09, 27),
                    Posted = new DateTime(2022, 09, 27),
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
