namespace Web.Tests
{
    using System;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;

    public class Sut
    {
        private static Lazy<Task<Sut>> lazyInstance = new Lazy<Task<Sut>>(async () =>
        {
            var applicationName = Assembly.GetEntryAssembly().GetName().Name;
            var httpService = CompositionRoot.CreateHostBuilder();

            var host = httpService.Build();

            await host.StartAsync();

            return new Sut(host);
        });

        private HttpClient httpClient;
        private IWebHost webHost;

        private Sut(IWebHost webHost)
        {
            var baseUrl = new Uri("http://localhost:5000");

            var handler = new HttpClientHandler { AllowAutoRedirect = false, UseCookies = false };
            this.httpClient = new HttpClient(handler);
            this.httpClient.BaseAddress = baseUrl;
            this.httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/23.0");
            this.httpClient.Timeout = TimeSpan.FromSeconds(3);

            this.webHost = webHost;
        }

        public static Task<Sut> AsyncInstance => lazyInstance.Value;

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return this.httpClient.SendAsync(request);
        }
    }
}