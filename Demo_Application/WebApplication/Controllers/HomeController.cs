using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.Model;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly string _apiBaseUrl;

        public HomeController(IConfiguration configuration)
        {
            _apiBaseUrl = configuration["ApiSettings:BaseUrl"];
           
            

        }

        public async Task<IActionResult> Index()
        {

            using (WebClient client = new WebClient())
            {
                try
                {
                    string json = client.DownloadString(_apiBaseUrl);
                    var urls = JsonConvert.DeserializeObject<List<URL_tblViewModel>>(json);

                   
                    var activeUrls = urls.Where(u => u.Active==true).ToList();

                    return View(activeUrls);
                }
                catch
                {
                    ViewBag.Error = "API call failed.";
                    return View(new List<URL_tblViewModel>());
                }
            }

            return View();
        }

       
    }
}
