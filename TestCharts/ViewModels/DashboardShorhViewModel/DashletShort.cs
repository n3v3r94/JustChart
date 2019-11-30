using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCharts.ViewModels.DashboardShorhViewModel
{
    public class DashletShort
    {
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        //id of html elemet
        [JsonProperty("idChart")]
        public string IdChart { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

    }
}
