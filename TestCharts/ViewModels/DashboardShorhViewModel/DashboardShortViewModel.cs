using Newtonsoft.Json;
using System.Collections.Generic;

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
