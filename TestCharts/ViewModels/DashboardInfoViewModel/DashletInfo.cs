using Newtonsoft.Json;

namespace TestCharts.ViewModels.DashboardInfoViewModel
{
    public class DashletInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parrentId")]
        public string ParrentId { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("column")]
        public int Column { get; set; }
        [JsonProperty("type")]
        public string  Type { get; set; }


    }
}
