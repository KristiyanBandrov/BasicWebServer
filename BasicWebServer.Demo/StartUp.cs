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
            .MapGet<HomeController>("/", c => c.Index())
            .MapGet<HomeController>("/Redirect", c => c.Redirect())
            .MapGet<HomeController>("/HTML", c => c.Html())
            .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
            .MapGet<HomeController>("/Content", c => c.Content())
            .MapPost<HomeController>("/Content", c => c.DownloadContent())
            .MapGet<HomeController>("/Cookies", c => c.Cookies())
            .MapGet<HomeController>("/Session", c => c.Session()))
            //.MapGet("/Login", new HtmlResponse(StartUp.LoginForm))
            //.MapPost("/Login", new HtmlResponse("", StartUp.LoginAction))
            //.MapGet("/Logout", new HtmlResponse("", StartUp.LogoutAction))
            //.MapGet("/UserProfile", new HtmlResponse("", StartUp.GetUserDataAction)))
            .Start();

        private static void LoginAction(Request request, Response response)
        {
            request.Session.Clear();

            var bodyText = "";

            //var usernameMathces = request.Form["Username"] == StartUp.Username;
            //var passwordMatches = request.Form["Password"] == StartUp.Password;

            //if (usernameMathces && passwordMatches)
            //{
            //request.Session[Session.SessionUserKey] = "MyUserId";
            //response.Cookies.Add(Session.SessionCookieName,
            //request.Session.Id);

            //bodyText = "<h3>Logged successfully!</h3>";
            //}
            //else
            //{
            //bodyText = StartUp.LoginForm;
            //}

            response.Body = "";
            response.Body += bodyText;
        }

        private static void LogoutAction(Request request, Response response)
        {
            request.Session.Clear();

            response.Body = "";
            response.Body += "<h3>Logged out successfully!</h3>";
        }

        //private static void GetUserDataAction(Request request, Response response)
        //{
        //if (request.Session.ContainsKey(Session.SessionUserKey))
        //{
        //response.Body = "";
        //response.Body += $"<h3>Currently logged-in user " +
        //$"is with username '{Username}'</h3>";
        //}
        //else
        //{
        //response.Body = "";
        //response.Body += "<h3>You should first log in " +
        //"- <a href ='/Login'>Login</a></h3>>";
        //}
        //}
    }

}
