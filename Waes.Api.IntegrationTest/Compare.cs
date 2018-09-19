using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using Waes.Api.Models;

namespace Waes.Api.IntegrationTest
{
    [Collection("SystemCollection")]
    public class Compare
    {
        readonly string encodedJson;
        readonly Encoding encoding;
        readonly string contentType;
        readonly TestContext context;

        public Compare()
        {
            encoding = Encoding.UTF8;
            encodedJson = "\"aHR0cDovL296bWVobWV0LmNvbQ==\"";
            contentType = "application/json";
            context = new TestContext();
        }

        [Fact]
        public async Task TestAll()
        {
            var requestContent = new StringContent(encodedJson, encoding, contentType);

            var responseLeft = await context.Client.PostAsync("v1/diff/1/left", requestContent);
            Assert.Equal(HttpStatusCode.OK, responseLeft.StatusCode);

            var responseRight = await context.Client.PostAsync("v1/diff/1/right", requestContent);
            Assert.Equal(HttpStatusCode.OK, responseRight.StatusCode);

            var response = await context.Client.GetAsync("v1/diff/1");

            //TODO refactor this implementation
            /*
            var responseContent = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
            int start = responseContent.ToString().IndexOf("result") + 10;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("The compared strings are equal", responseContent.ToString().Substring(start, 30));
        */
        }
    }
}
