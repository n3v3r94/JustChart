using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCharts.ViewModels;

namespace TestCharts.Services
{
  public  interface IHomeService
    {

        ChartDataViewModel GetChartData();
        
    }
}
