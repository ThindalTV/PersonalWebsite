using EricJohansson.Site.Shared.Interfaces.Blog;
using EricJohansson.Site.Shared.Types.Blog;
using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace EricJohansson.Site.Shared.Service
{
    public class StaticThoughtsService : IThoughtsService
    {
        private readonly List<FullThoughtDto> _thoughts;
        public StaticThoughtsService()
        {
            _thoughts = new List<FullThoughtDto>();

            int year = 2023;

            for( int i = 1; i < 501; i++)
            {
                _thoughts.Add(new FullThoughtDto()
                {
                    Id = i.ToString(),
                    Slug = $"TestThought{i}",
                    Created = DateTime.Now,
                    Posted = DateOnly.FromDateTime(DateTime.Now).AddDays(i),
                    Title = $"Static Thought - Single #{i}",
                    Short = $"This is a static Thought short #{i}",
                    Content = $"This is a static Thought content #{i}",
                    ContentRaw = $"{{ text: 'This is a static Thought content #{i}'}}",
                    Tags = new string[] { "static", "test", "Thought" },
                    ImageUrl = null
                });
            }
        }
        public async Task<int> GetThoughtCount(CancellationToken cancellationToken)
        {
            return await Task.FromResult(4);
        }

        public async Task<FullThoughtDto?> GetFullThought(int year, string slug, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return _thoughts.FirstOrDefault(t => t.Posted != null && t.Posted?.Year == year && t.Slug.ToLowerInvariant() == slug.ToLowerInvariant());
        }

        public async IAsyncEnumerable<FullThoughtDto> GetThoughtsPage(int page, int pageSize, [EnumeratorCancellation] CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
        {
            for (int i = 0; i < pageSize && i < _thoughts.Count; i++) {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return _thoughts[i];

                await Task.CompletedTask;
            }
        }

        public async IAsyncEnumerable<FullThoughtDto> GetThoughts(int startIndex, int count, [EnumeratorCancellation]CancellationToken cancellationToken, string? searchTerms = null, string[]? tags = null)
        {
            if (startIndex + count > _thoughts.Count)
                count = _thoughts.Count - startIndex;

            var matches = _thoughts.Where(t => t.Posted != null).OrderBy(t => t.Posted).Skip(startIndex).Take(count);

            foreach( var thought in matches) { 
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return thought;

            }
            await Task.CompletedTask;
        }

        public async IAsyncEnumerable<ThoughtsListEntryDto> GetLatestThoughts(int amount, [EnumeratorCancellation]CancellationToken token)
        {
            var reversedThoughts = _thoughts.Where(t=>t.Posted != null).OrderBy(t=>t.Posted).ToList();
            for( int i = 0; i < amount && i < reversedThoughts.Count; i++)
            {
                yield return new ThoughtsListEntryDto(Id: reversedThoughts[i].Id, 
                           Posted: reversedThoughts[i].Posted ?? DateOnly.FromDateTime(DateTime.Now), 
                           Url: $"thoughts/{reversedThoughts[i].Posted?.Year}/{reversedThoughts[i].Slug}", 
                           Slug: reversedThoughts[i].Slug, 
                           ImageUrl: reversedThoughts[i].ImageUrl, 
                           Title: reversedThoughts[i].Title, 
                           Summary: reversedThoughts[i].Short);
            }
        }

        public async Task<ThoughtsListEntryDto?> GetPreviousThought(string currentThoughtId, CancellationToken cancellationToken)
        {
            var currentThought = _thoughts.FirstOrDefault(t => t.Id == currentThoughtId);
            if (currentThought == null)
                return null;

            var previousThought = _thoughts.Where(t=>t.Posted != null).OrderBy(t=>t.Posted).LastOrDefault(t => t.Posted < currentThought.Posted);
            if(previousThought == null)
                return null;

            return new ThoughtsListEntryDto(Id: previousThought.Id, 
                       Posted: previousThought.Posted, 
                       Url: $"Thought/{previousThought.Posted?.Year}/{previousThought.Slug}", 
                       Slug: previousThought.Slug, 
                       ImageUrl: previousThought.ImageUrl, 
                       Title: previousThought.Title, 
                       Summary: previousThought.Short);
        }

        public async Task<ThoughtsListEntryDto?> GetNextThought(string currentThoughtId, CancellationToken cancellationToken)
        {
            var currentThought = _thoughts.FirstOrDefault(t => t.Id == currentThoughtId);
            if (currentThought == null)
                return null;

            var nextThought = _thoughts.OrderByDescending(t=>t.Posted).LastOrDefault(t => t.Posted > currentThought.Posted);
            if(nextThought == null)
                return null;

            return new ThoughtsListEntryDto(Id: nextThought.Id, 
                       Posted: nextThought.Posted, 
                       Url: $"Thought/{nextThought.Posted?.Year}/{nextThought.Slug}", 
                       Slug: nextThought.Slug, 
                       ImageUrl: nextThought.ImageUrl, 
                       Title: nextThought.Title, 
                       Summary: nextThought.Short);
        }

        public async Task<bool> IsFirstThought(string thoughtId, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return _thoughts.IndexOf(_thoughts.FirstOrDefault(t => t.Id == thoughtId)) == 0;
        }

        public async Task<bool> IsLastThought(string thoughtId, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return _thoughts.IndexOf(_thoughts.FirstOrDefault(t => t.Id == thoughtId)) == _thoughts.Count - 1;
        }
    }
}
