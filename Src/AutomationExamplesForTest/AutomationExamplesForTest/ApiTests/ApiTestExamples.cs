using System.Net;
using log4net;
using NUnit.Framework;
using RestSharp;

namespace AutomationExamplesForTest.ApiTests
{
    /// <summary>
    /// This represents a series of API based tests
    /// </summary>
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class ApiTestExamples : BaseApi
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ApiTestExamples));

        [Test]
        public void GetVerb()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(GetVerb)}' called");

            RestClient client = new RestClient("http://localhost:49080");
            Assert.IsNotNull(client);

            RestRequest request = new RestRequest("api/WeatherForecast", Method.Get)
            {
                RequestFormat = DataFormat.Json
            };

            RestResponse response = client.ExecuteAsync(request).Result;
            _logger.Debug(response);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(response.ContentLength);

#pragma warning disable CS8629 // Nullable value type may be null.
            Assert.NotZero(response.ContentLength.Value);
#pragma warning restore CS8629 // Nullable value type may be null.

            Assert.IsNotNull(response.Content);
        }
    }
}