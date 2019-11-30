using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCharts.ViewModels
{
    public class DashletViewModel
    {
        /// id of configuration  chart
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        public string ParrentId { get; set; }
        //id of html elemet
        [JsonProperty("idChart")]
        public string IdChart { get; set; }
        //data source
        [JsonProperty("dataSrc")]
        public string DataSrc { get; set; }
        //data x of chart
        [JsonProperty("dataX")]
        public string DataX { get; set; }
        //data y of chart
        [JsonProperty("dataY")]
        public string DataY { get; set; }
        //type of chart  example: pie, line
        [JsonProperty("typeOfChart")]
        public string TypeOfChart { get; set; }
        //Do you have data source pagination?
        [JsonProperty("isPagination")]
        public bool IsPagination { get; set; }
        [JsonProperty("pageStart")]
        public int PageStart { get; set; }
        [JsonProperty("pageEnd")]
        public int PageEnd { get; set; }
        [JsonProperty("pagePerDataSet")]
        public int PagePerDataSet { get; set; }
        [JsonProperty("pageParametarName")]
        public string PageParametarName { get; set; }
        [JsonProperty("requestType")]
        public string RequestType { get; set; }
        [JsonProperty("requestMode")]
        public string RequestMode { get; set; }
        [JsonProperty("request")]
        public string Request { get; set; }
        [JsonProperty("loopToExtract")]
        public string LoopToExtract { get; set; }
        [JsonProperty("loopParamInRequest")]
        public string LoopParamInRequest { get; set; }
        [JsonProperty("loopParamInRequestStep")]
        public string LoopParamInReqestStep { get; set; }
        [JsonProperty("parametars")]
        public string Parametars { get; set; }
        [JsonProperty("pathRoot")]
        public string PathRoot { get; set; }
        [JsonProperty("pathValue")]
        public string PathValue { get; set; }
        [JsonProperty("operationType")]
        public string OperationType { get; set; }
        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("column")]
        public int Column { get; set; }
    }
}
