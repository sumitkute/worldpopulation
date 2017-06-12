using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace worldpopulation.Controllers
{
    public class HomeController : Controller
    {
        string authority = ConfigurationManager.AppSettings["authority"];
        string clientId = ConfigurationManager.AppSettings["clientId"];
        string clientSecret = ConfigurationManager.AppSettings["clientSecret"];
        string resource = ConfigurationManager.AppSettings["resource"];
        string serviceURL = ConfigurationManager.AppSettings["serviceURL"];
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var token = GetS2SAccessTokenAsync(authority, resource, clientId, clientSecret);
            ViewBag.Token = token.AccessToken;
            HttpClient client = new HttpClient();
            var result = client.GetAsync($"{resource}/api/values/5").Result;
            ViewBag.Result = result.Content.ToString();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private AuthenticationResult GetS2SAccessTokenAsync(string authority, string resource, string clientId, string clientSecret)
        {
            var clientCredential = new ClientCredential(clientId, clientSecret);
            AuthenticationContext context = new AuthenticationContext(authority);
            var authenticationResult = context.AcquireTokenAsync(resource,
                clientCredential).Result;
            return authenticationResult;
        }
    }
}