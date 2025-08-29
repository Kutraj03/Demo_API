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
        private readonly ILogger<HomeController> _logger;
        private readonly string _apiBaseUrl;

        public HomeController(IConfiguration configuration,ILogger<HomeController> logger)
        {
            _apiBaseUrl = configuration["ApiSettings:BaseUrl"];
            _logger = logger;
            

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
