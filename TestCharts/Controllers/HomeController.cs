using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TestCharts.Models;
using TestCharts.Service;
using TestCharts.ViewModels;
namespace TestCharts.Controllers
{
    public class HomeController : Controller
    {
       

        public async Task<IActionResult> Index()
        {
       
           

            return View();
        }

        //public async Task<string> GetDataChart()
        //{
        //    //var jsonConfig = await homeService.GetDataJson();
        //    //var response = await homeService.GetDataFromApiPost(jsonConfig);
        //    //var data = await homeService.DataRetrievalResponse(response,jsonConfig);
        //    //return data;
        //}

        //public async Task<IActionResult> GetJsonConfiguration()
        //{
        //    //var config = await homeService.GetDataJson();

        //    //var test = config;
        //    //var test2 = config;
        //    /return Json(config);
        //}

        public IActionResult GetDataAPI()
        {


            List<ViewModelAPI> chartData = new List<ViewModelAPI>();
            chartData.Add(new ViewModelAPI
            {
                ChartId = "myChartAPI",
                Data = new List<int> { 12, 9, 3, 5, 3 },
                Labels = new List<string> { "Red", "Blue", "Yellow", "Green", "Orange" },
                LabelTitle = "Test"
            });

            return Json(chartData);
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
