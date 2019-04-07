using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TestCharts.Models;
using TestCharts.Services;
using TestCharts.ViewModels;

namespace TestCharts.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public IActionResult Index()
        {

            string path = @"C:\Users\Dell T7500\source\repos\TestCharts\TestCharts\homePageChart.json";
            HomePageCharts test = new HomePageCharts();
            using (StreamReader r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
               test  =  JsonConvert.DeserializeObject<HomePageCharts> (json);

               

            }

           ChartDataViewModel dataChart =  homeService.GetChartData();

            return View(test);
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
