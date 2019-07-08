using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCharts.ViewModels
{
    public class HomePageConfig
    {
        public string PageTitle { get; set; }
        public string Type { get; set; }
        public string Servicehandler { get; set; }
        public string IdChart {get;set;}
        public List<int> Data { get; set; }
    }
}
