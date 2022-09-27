using EricJohansson.Site.Shared.Interfaces.Blog;
using EricJohansson.Site.Shared.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EricJohansson.Site.Shared
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection collection, string baseAdress)
        {
            collection.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAdress) });

            collection.AddScoped<IPostService, StaticPostService>();

            return collection;
        }
    }
}
