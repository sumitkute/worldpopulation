using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using world.data;

namespace worldpopulation.Controllers
{
    public class OnlineRetailController : Controller
    {
        // GET: OnlineRetail
        public ActionResult Index()
        {
            var client = new RestClient();
            client.AddHandler("application/json", new JsonDeserializer());
            client.BaseUrl = new Uri(ConfigurationManager.AppSettings["ServiceURL"].ToString());
            var request = new RestRequest("/api/OnlineRetail", Method.GET);
            var response = client.Execute<List<Invoice>>(request);
            return View("Index", response.Data);
        }
    }
}