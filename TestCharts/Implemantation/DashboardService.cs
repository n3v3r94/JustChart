using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestCharts.Service;
using TestCharts.ViewModels;
using TestCharts.ViewModels.DashboardInfoViewModel;
using TestCharts.ViewModels.DashboardShorhViewModel;

namespace TestCharts.Implemantation
{
    public class DashboardService : IDashboardService
    {
        public async Task<string> GetDataFromApiPost(DashletViewModel dashlet)
        {
            string responseContent = null;
            switch (dashlet.RequestType)
            {
                case "POST":
                    {
                        string requestBody = dashlet.Parametars;

                        var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
                        using (var httpClient = new HttpClient())
                        {
                            // Do the actual request and await the response
                            var httpResponse = await httpClient.PostAsync(dashlet.DataSrc, httpContent);
                            // If the response contains content we want to read it!
                            if (httpResponse.Content != null)
                            {
                                responseContent = await httpResponse.Content.ReadAsStringAsync();
                            }
                        }
                    }
                    break;

                case "GET":
                    {
                        string requestBody = dashlet.Parametars;

                        var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
                        using (var httpClient = new HttpClient())
                        {
                            // Do the actual request and await the response
                            var httpResponse = await httpClient.GetAsync(dashlet.DataSrc);
                            // If the response contains content we want to read it!
                            if (httpResponse.Content != null)
                            {
                                responseContent = await httpResponse.Content.ReadAsStringAsync();
                            }
                        }
                    }
                    break;
            }

            return responseContent;

        }



        public async Task<string> DataRetrievalResponse(string response, DashletViewModel dashlet)
        {

            string root = String.Empty;
            if (dashlet.PathRoot == "")
            {
                response = $"{{'result' : {response} }}";
                root = "result";
            }
            else
            {
                root = dashlet.PathRoot;
            }

            JObject obj = JObject.Parse(response);
            JArray array = new JArray();

            foreach (JObject item in obj[root])
            {
                bool hasValue = false;
                var curentValue = item.SelectToken(dashlet.PathValue);

                foreach (var ar in array)
                {
                    var tempValue = string.IsNullOrWhiteSpace((string)curentValue) ? "no info" : curentValue;
                    if ((string)ar[dashlet.DataY] == (string)tempValue)
                    {
                        var tempCount = ar.Value<int>(dashlet.DataX);
                        tempCount++;
                        ar[dashlet.DataX] = tempCount;
                        hasValue = true;
                        continue;
                    }
                }
                if (hasValue)
                {
                    continue;
                }
                else
                {
                    JToken token = JToken.Parse(string.Format("{{\"{0}\":\"{1}\",\"{2}\":\"{3}\"}}", dashlet.DataY, string.IsNullOrWhiteSpace((string)curentValue) ? "no info" : curentValue, dashlet.DataX, 0));
                    array.Add(token);
                }
            }

            string chartData = JsonConvert.SerializeObject(array);
            return chartData;
        }


        public async Task<DashboardViewModel> GetDashboardById(string id)
        {
            string path = "./dashboards.json";
            DashboardsJson test = new DashboardsJson();
            using (StreamReader reader = new StreamReader(path))
            {
                var json = await reader.ReadToEndAsync();
                test = JsonConvert.DeserializeObject<DashboardsJson>(json);
            }

            return test?.dashboards?.Dashboard.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<DashboardShortJson> GetAllShortsDashboards()
        {
            string path = "./dashboards.json";
            DashboardShortJson dashboards = new DashboardShortJson();
            using (StreamReader reader = new StreamReader(path))
            {
                var dashboardJson = await reader.ReadToEndAsync();
                dashboards = JsonConvert.DeserializeObject<DashboardShortJson>(dashboardJson);
            }

            return dashboards;
        }


        public async Task<DashboardShortViewModel> GetShortsDashboardById(string id)
        {
            string path = "./dashboards.json";
            DashboardShortJson dashboards = new DashboardShortJson();
            using (StreamReader reader = new StreamReader(path))
            {
                var dashboardJson = await reader.ReadToEndAsync();
                dashboards = JsonConvert.DeserializeObject<DashboardShortJson>(dashboardJson);
            }

            return dashboards?.dashboards?.Dashboard?.FirstOrDefault(x => x.Id == id);
        }

        public async Task<DashletInfo> GetDashletInfo(string dashboardId, string dashletId)
        {
            string path = "./dashboards.json";
            DashboardsJson dashboards = new DashboardsJson();
            DashletInfo dashletInfo = new DashletInfo();
            using (StreamReader reader = new StreamReader(path))
            {
                var dashboardJson = await reader.ReadToEndAsync();
                dashboards = JsonConvert.DeserializeObject<DashboardsJson>(dashboardJson);

                var dashelt = dashboards?.dashboards?.Dashboard?
                      .FirstOrDefault(x => x.Id == dashboardId)
                      ?.Dashlets?.FirstOrDefault(x => x.Id == dashletId);
                dashletInfo.Id = dashelt.Id;
                dashletInfo.ParrentId = dashelt.ParrentId;
                dashletInfo.Type = dashelt.TypeOfChart;
                dashletInfo.Column = dashelt.Column;
                dashletInfo.Height = dashelt.Height;
                dashletInfo.Width = dashelt.Width;
            }

            return dashletInfo;
        }

        public async Task<DashletViewModel> GetDashboardDashletData(string dashboardId, string dashletId)
        {
            string path = "./dashboards.json";
            DashboardsJson dashboards = new DashboardsJson();
            DashletViewModel dashlet = new DashletViewModel();
            using (StreamReader reader = new StreamReader(path))
            {
                var dashboardJson = await reader.ReadToEndAsync();
                dashboards = JsonConvert.DeserializeObject<DashboardsJson>(dashboardJson);

                dashlet = dashboards?.dashboards?.Dashboard?
                      .FirstOrDefault(x => x.Id == dashboardId)
                      ?.Dashlets?.FirstOrDefault(x => x.Id == dashletId);
            }

            return dashlet;
        }

    }
}
