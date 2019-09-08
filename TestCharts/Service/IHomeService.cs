using System.Threading.Tasks;
using TestCharts.ViewModels;

namespace TestCharts.Service
{
    public interface IHomeService
    {
        Task<HomePageConfig> GetDataJson();
        Task<string> GetDataFromApiPost(HomePageConfig homePage);
        Task<string> DataRetrievalResponse(string response, HomePageConfig homePage);
    }
}
