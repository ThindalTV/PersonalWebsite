using EricJohansson.Site.Shared.Interfaces.Blog;
using EricJohansson.Site.Shared.Interfaces.Schedule;
using EricJohansson.Site.Shared.Service;
using Microsoft.Extensions.DependencyInjection;

namespace EricJohansson.Site.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection collection, string baseAdress)
    {
        collection.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAdress) });

        collection.AddScoped<IThoughtsService, StaticThoughtsService>();
        collection.AddScoped<IAppearanceService, StaticAppearanceService>();

        return collection;
    }
}
