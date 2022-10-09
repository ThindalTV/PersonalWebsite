using EricJohansson.Site.Shared.Types.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EricJohansson.Site.Shared.Interfaces.Blog
{
    public interface IPostService
    {
        public IAsyncEnumerable<Post> GetPostsPageAsync(int page, int pageSize, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null);
        public IAsyncEnumerable<Post> GetPostsAsync(int year, int month, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null);
        public Task<Post> GetPost(string id);
    }
}
