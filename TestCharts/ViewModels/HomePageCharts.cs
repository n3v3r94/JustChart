using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCharts.ViewModels
{
    public class HomePageCharts
    {
        public HomePageCharts()
        {
            this.configs = new List<HomePageConfig>();
        }

        public List<HomePageConfig> configs { get; set; }
    }
}
