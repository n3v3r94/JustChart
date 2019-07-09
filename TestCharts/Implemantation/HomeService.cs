using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestCharts.Service;
using TestCharts.ViewModels;

namespace TestCharts.Implemantation
{
    public class HomeService : IHomeService
    {
        public async Task<HomePageCharts> GetDataJson()
        {

            string path = @"./homePageChart.json";
            HomePageCharts  test = new HomePageCharts();
             using (StreamReader reader = new StreamReader(path))
            {
                var json =  await reader.ReadToEndAsync();
                test =  JsonConvert.DeserializeObject<HomePageCharts>(json);
            }

            return test;
        }
    }
}
