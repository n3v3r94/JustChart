using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestCharts.Service;
using TestCharts.ViewModels;

namespace TestCharts.Implemantation
{
    public class HomeService : IHomeService
    {
        public async Task<string> DataRetrievalResponse(string response, HomePageConfig homePage)
        {
            JObject obj = JObject.Parse(response);

            JArray array = new JArray();

            foreach (JObject item in obj[homePage.config.PathRoot])
            {
                bool hasValue = false;
                var curentValue = item.SelectToken(homePage.config.PathValue);

                foreach (var ar in array)
                {
                    var tempValue = string.IsNullOrWhiteSpace((string)curentValue) ? "no info" : curentValue;
                    if ((string)ar[homePage.config.DataY] == (string)tempValue)
                    {

                        var tempCount = ar.Value<int>(homePage.config.DataX);
                        tempCount++;
                        ar[homePage.config.DataX] = tempCount;
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
                    JToken token = JToken.Parse(string.Format("{{\"{0}\":\"{1}\",\"{2}\":\"{3}\"}}",homePage.config.DataY , string.IsNullOrWhiteSpace((string)curentValue) ? "no info" : curentValue,homePage.config.DataX, 0));
                    array.Add(token);
                }

            }

            string chartData = JsonConvert.SerializeObject(array);
            return chartData;
        }

        public async Task<string> GetDataFromApiPost(HomePageConfig homePage)
        {
            string responseContent = null;
            switch (homePage.config.RequestType)
            {
                case "POST":
                    {
                        string requestBody = homePage.config.Parametars;

                        var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
                        using (var httpClient = new HttpClient())
                        {
                            // Do the actual request and await the response
                            var httpResponse = httpClient.PostAsync(homePage.config.DataSrc, httpContent).Result;
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
                        //TODO implementation
                    }
                    break;
            }

            return responseContent;

        }

        public async Task<HomePageConfig> GetDataJson()
        {
            string path = "./homePageChart.json";
            HomePageConfig test = new HomePageConfig();
            using (StreamReader reader = new StreamReader(path))
            {
                var json = await reader.ReadToEndAsync();
                test = JsonConvert.DeserializeObject<HomePageConfig>(json);
            }
            return test;
        }
    }
}
