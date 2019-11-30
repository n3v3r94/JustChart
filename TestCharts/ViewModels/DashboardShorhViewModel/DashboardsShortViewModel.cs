using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCharts.ViewModels.DashboardShorhViewModel
{
    public class DashboardsShortViewModel
    {
        [JsonProperty("dashboard")]
        public List<DashboardShortViewModel> Dashboard { get; set; }
    }
}
