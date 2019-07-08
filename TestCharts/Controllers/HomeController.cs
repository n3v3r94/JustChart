using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using TestCharts.Models;
using TestCharts.Service;
using TestCharts.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace TestCharts.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public   IActionResult  Index()
        {
            //TODO get data from API 
            var test =    homeService.GetChartsConfiguration();
         
           
            return View (test);
        }

        public async Task<IActionResult> GetData()
        {
            //TODO get data from API 
            var test = await homeService.GetChartsConfiguration();


            return Json(test);
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
