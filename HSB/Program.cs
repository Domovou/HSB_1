using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HSB.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HSB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            //var host = BuildWebHost(args);

            //using (var scope = host.Services.CreateScope())  
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var serviceProvider = services.GetRequiredService<IServiceProvider>();
            //        Seed.CreateRoles(serviceProvider).Wait();
            //    }
            //    catch (Exception exception)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(exception, "An error occurred while creating roles");
            //    }
            //}
            //host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
