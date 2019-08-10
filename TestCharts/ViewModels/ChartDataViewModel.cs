﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCharts.ViewModels
{
    public class ChartDataModel
    {
        /// <summary>
        /// id of configuration  chart
        /// </summary>
        [JsonProperty]
        public int Id { get; set; }
        //id of html elemet
        [JsonProperty]
        public string IdChart { get; set; }
        //data source
        [JsonProperty]
        public string DataSrc { get; set; }
        //data x of chart
        [JsonProperty]
        public string DataX { get; set; }
        //data y of chart
        [JsonProperty]
        public string DataY { get; set; }
        //type of chart  example: pie, line
        [JsonProperty]
        public string TypeOfChart { get; set; }
        //Do you have data source pagination?
        [JsonProperty]
        public bool IsPagination { get; set; }
        [JsonProperty]
        public int PageStart { get; set; }
        [JsonProperty]
        public int PageEnd { get; set; }
        [JsonProperty]
        public int PagePerDataSet { get; set; }
        [JsonProperty]
        public string PageParametarName { get; set; }
    }
}
