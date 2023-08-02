using System.Net;
using EricJohansson.Site.Shared.Types.Blog;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace EricJohansson.Site.Functions.Blog
{
    public class Musings
    {
        private readonly ILogger _logger;

        public Musings(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Musings>();
        }

        [Function("Musing/{id}")]
        public HttpResponseData GetMusing([HttpTrigger("get")] HttpRequestData req, string id)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            //response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            var musing = new FullMusingDto()
            {
                Content = "Musing with id " + id,
                Title = "Musing from function"
            };

            response.WriteAsJsonAsync(musing);
            return response;
        }

        [Function("Musings")]
        public HttpResponseData GetMusings([HttpTrigger("get")] HttpRequestData req, int offset, int count)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
