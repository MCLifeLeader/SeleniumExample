using System;
using System.Net;
using System.Threading.Tasks;
using AutomationExample.Tests.Api.Models;
using AutomationExample.Tests.Extensions;
using log4net;
using NUnit.Framework;
using RestSharp;

namespace AutomationExample.Tests.Api
{
    /// <summary>
    /// This represents a series of API based tests
    /// </summary>
    // Test Fixture attributes
    [TestFixture, Parallelizable(ParallelScope.All), Category("Api")]
    public class ApiTestExamples : BaseApi
    {
        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ApiTestExamples));
        private readonly string _portNumber = "46080";

        /// <summary>
        /// RESTful API test automation example
        /// </summary>
        /// <param name="arguments">Test data arguments</param>
        // Individual test case attribute and parallel threading behavior defined.
        [Test, Parallelizable(ParallelScope.All), Category("ApiTests")]
        // Inject data directly into the test case.
        // You can add additional parameters / test data.
        [TestCase("WorkItem", "000004", Category = "RestApiDev")]
        [TestCase("WorkItem", "000005", Category = "RestApiTest")]
        [TestCase("WorkItem", "000006", Category = "RestApiStage")]
        public async Task GetVerb(params object[] arguments)
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(GetVerb)}' called");

            // This is an example of how to inject data into the test based on the Category of test.
            _logger.Info($"Test Case Id: {arguments[1]}");

            // Setup a RestClient for a HTTP RESTful call
            RestClient client = new RestClient($"{BaseUrl}:{_portNumber}{BaseRoute}");
            Assert.IsNotNull(client);

            // Create the request that will be used
            RestRequest request = new RestRequest("api/Weather/WeatherForecast", Method.Get)
            {
                RequestFormat = DataFormat.Json
            };

            // Execute the Request and capture the response
            RestResponse response = await client.ExecuteAsync(request);

            // Validate the response from the web service
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(response.ContentLength);
            Assert.NotZero(response.ContentLength.Value);
            Assert.IsNotNull(response.Content);
        }

        /// <summary>
        /// RESTful API test automation example
        /// </summary>
        /// <param name="arguments">Test data arguments</param>
        // Individual test case attribute and parallel threading behavior defined.
        [Test, Parallelizable(ParallelScope.All), Category("ApiTests")]
        // Inject data directly into the test case.
        // You can add additional parameters / test data.
        [TestCase("WorkItem", "000007", Category = "RestApiTest")]
        public async Task PostVerb(params object[] arguments)
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(PostVerb)}' called");

            // This is an example of how to inject data into the test based on the Category of test.
            _logger.Info($"Test Case Id: {arguments[1]}");

            // Setup a RestClient for a HTTP RESTful call
            RestClient client = new RestClient($"{BaseUrl}:{_portNumber}{BaseRoute}");
            Assert.IsNotNull(client);

            // Create the request that will be used
            RestRequest request = new RestRequest("api/Weather/WeatherData", Method.Post)
            {
                RequestFormat = DataFormat.Json
            };

            Random random = new Random((int)DateTime.UtcNow.Ticks);
            WeatherData weatherData = new WeatherData()
            {
                Date = DateTime.UtcNow,
                Summary = "Test Data Post",
                Temprature = random.Next(-40, 50),
                WindDirection = random.Next(0, 360),
                WindSpeed = random.Next(0, 102),
                Units = "Metric"
            };

            _logger.Debug(await weatherData.ToJsonAsync());

            request.AddBody(weatherData);

            // Execute the Request and capture the response
            RestResponse response = await client.ExecuteAsync(request);

            // Validate the response from the web service
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(response.ContentLength);
            Assert.NotZero(response.ContentLength.Value);
            Assert.IsNotNull(response.Content);
        }
    }
}