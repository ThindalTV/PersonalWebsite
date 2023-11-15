using System.Net;
using System.Text.Json;
using Azure;
using EricJohansson.Site.Shared.Interfaces.Blog;
using EricJohansson.Site.Shared.Types.Blog;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace EricJohansson.Site.Functions.Blog
{
    public class ThoughtsEndpoints
    {
        private readonly ILogger _logger;
        private readonly IThoughtsService _thoughtsService;

        public ThoughtsEndpoints(ILoggerFactory loggerFactory, IThoughtsService thoughtsService)
        {
            _logger = loggerFactory.CreateLogger<ThoughtsEndpoints>();
            _thoughtsService = thoughtsService;
        }

        [Function("GetThought")]
        public async Task<HttpResponseData> GetThought([HttpTrigger("get", Route= "Thought/{year:int}/{*slug}")] HttpRequestData req, int year, string slug, CancellationToken cancellationToken)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var thought = await _thoughtsService.GetFullThought(year, slug, cancellationToken);

            await response.WriteAsJsonAsync(thought);
            return response;
        }

        [Function("GetThoughts")]
        public async Task<HttpResponseData> GetThoughts([HttpTrigger("get", "Thoughts/{offset:int}/{count:int}")] HttpRequestData req, int offset, int count, CancellationToken cancellationToken)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var thoughts = _thoughtsService.GetThoughtsPage(offset, count, cancellationToken);

            var resp = req.CreateResponse(HttpStatusCode.OK);
            resp.Headers.Add("Content-Type", "application/json-data-stream; charset=utf-8");

            var streamWriter = new StreamWriter(resp.Body);
            await foreach (var thought in thoughts)
            {
                await streamWriter.WriteAsync(JsonSerializer.Serialize(thought));
            }
            await streamWriter.FlushAsync();

            return resp;
        }
    }
}
