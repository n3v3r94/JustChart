using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCharts.ViewModels.DashboardShorhViewModel
{
    public class DashboardShortViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("dashlets")]
        public List<DashletShort> Dashlets { get; set; }
    }
}
