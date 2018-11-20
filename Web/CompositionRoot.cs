namespace Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

    public class CompositionRoot
    {
        public static IWebHostBuilder CreateHostBuilder()
        {
            var hostBuilder = new WebHostBuilder()
                .UseKestrel()
                .ConfigureLogging(lb => { })
                .ConfigureServices(
                    services =>
                    {
                        services
                            .AddMvc();
                    })
                .Configure(
                    app =>
                    {
                        var env = app.ApplicationServices.GetService<IHostingEnvironment>();

                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }

                        app
                            .UseMvc();

                    });

            return hostBuilder;
        }
    }
}