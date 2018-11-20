using System;

namespace Web.Tests
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Jil;
    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public async Task ShouldReturnBadRequest()
        {
            var itemIds = Enumerable.Repeat(string.Empty, 621).ToArray();
            var body = JSON.SerializeDynamic(new { ItemIds = itemIds });

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("/api/home?key=test", UriKind.Relative),
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };

            var sut = await Sut.AsyncInstance;
            var response = await sut.SendAsync(request);

            Assert.Equal(
                expected: HttpStatusCode.BadRequest,
                actual: response.StatusCode);
        }
    }
}