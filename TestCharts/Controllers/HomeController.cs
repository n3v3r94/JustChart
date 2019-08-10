﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using TestCharts.Models;
using TestCharts.Service;
using TestCharts.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace TestCharts.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {

            this.homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await homeService.GetDataJson();

            return View (model);
        }

        public async Task<IActionResult> GetJsonConfiguration()
        {
            var config = await homeService.GetDataJson();

            var test = config;
           var test2 = config;
            return Json(config);
        }

        public  IActionResult GetDataAPI()
        {
           

            List<ViewModelAPI> chartData = new List<ViewModelAPI>();
            chartData.Add(new ViewModelAPI
            {
                ChartId = "myChartAPI",
                Data = new List<int> { 12, 9, 3, 5, 3 },
                Labels = new List<string> { "Red", "Blue", "Yellow", "Green",  "Orange" },
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
