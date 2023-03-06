using System.Net;
using EricJohansson.Site.Shared.Types.Blog;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace EricJohansson.Site.Functions.Blog
{
    public class Posts
    {
        private readonly ILogger _logger;

        public Posts(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Posts>();
        }

        [Function("Post/{id}")]
        public HttpResponseData GetPost([HttpTrigger("get")] HttpRequestData req, string id)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            //response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            var post = new Post()
            {
                Content = "Post with id " + id,
                Title = "Post from function"
            };

            response.WriteAsJsonAsync(post);
            return response;
        }

        [Function("Posts")]
        public HttpResponseData GetPosts([HttpTrigger("get")] HttpRequestData req, int offset, int count)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
