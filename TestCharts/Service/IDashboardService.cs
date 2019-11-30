using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCharts.ViewModels;
using TestCharts.ViewModels.DashboardInfoViewModel;
using TestCharts.ViewModels.DashboardShorhViewModel;

namespace TestCharts.Service
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboardById(string id);
        Task<DashboardShortJson> GetAllShortsDashboards();
        Task<DashboardShortViewModel> GetShortsDashboardById(string id);
        Task<DashletInfo> GetDashletInfo(string dashboardId, string dashletId);
        Task<DashletViewModel> GetDashboardDashletData(string dashboardId, string dashletId);
        Task<string> GetDataFromApiPost(DashletViewModel dashlet);
        Task<string> DataRetrievalResponse(string response, DashletViewModel dashlet);
    }
}
