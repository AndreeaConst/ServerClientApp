using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace   PersonService
{
    public class Program
    {


        //const int Port = 5001;

        //public static void Main(string[] args)
        //{
        //    Server server = new Server
        //    {
        //        Services = { Bookstore.BindService(new Services.BookService()) },
        //        Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
        //    };
        //    server.Start();

        //    Console.WriteLine("Bookstore server listening on port " + Port);
        //    Console.WriteLine("Press any key to stop the server...");
        //    Console.ReadKey();

        //    server.ShutdownAsync().Wait();
        //}


        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}