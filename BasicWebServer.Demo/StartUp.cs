 using System;
using System.Text;
using System.Web;
using BasicWebServer.Demo.Controllers;
using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Demo
{

    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
            .MapControllers())
            .Start();

    }

}
