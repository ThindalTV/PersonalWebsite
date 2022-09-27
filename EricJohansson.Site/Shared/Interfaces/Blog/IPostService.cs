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
        public IAsyncEnumerable<Post> GetPostsAsync(int page, int pageSize, CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null);
    }
}
