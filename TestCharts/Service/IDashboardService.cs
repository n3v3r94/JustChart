using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCharts.ViewModels;

namespace TestCharts.Service
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboardById(string id);
        Task<string> GetDataFromApiPost(DashletViewModel dashlet);
        Task<string> DataRetrievalResponse(string response, DashletViewModel dashlet);
    }
}
