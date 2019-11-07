using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCharts.ViewModels
{
    public class DashboardsViewModels
    {
        [JsonProperty("dashboard")]
        public List<DashboardViewModel> Dashboard { get; set; }
    }
}
