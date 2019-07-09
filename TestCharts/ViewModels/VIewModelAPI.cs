using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCharts.ViewModels
{
    public class ViewModelAPI
    {
        public string ChartId { get; set; } 
        public string LabelTitle { get; set; }
        public List<string> Labels { get; set; } = new List<string>();
        public List<int> Data { get; set; } = new List<int>();
    }
}
