using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCharts.Services;
using TestCharts.ViewModels;

namespace TestCharts.implementation
{
    public class ChartData : IHomeService
    {
        public ChartDataViewModel GetChartData()
        {
            ChartDataViewModel model = new ChartDataViewModel();

            model.Months =  @"January, February, March, April, May, June, July";
            model.Labels = "[0, 10, 5, 2, 20, 30, 45]";

            return model;
        }
    }
}
