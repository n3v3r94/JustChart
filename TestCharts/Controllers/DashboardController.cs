using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Threading.Tasks;
using TestCharts.Services;
using TestCharts.ViewModels;
using TestCharts.ViewModels.DashboardShorhViewModel;

namespace TestCharts.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {

            this.dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardById(string id)
        {
            var dasboard = await dashboardService.GetDashboardById(id);

            return Json(dasboard);
        }
        [HttpPost]
        public async Task<IActionResult> GetDashletData([FromBody]DashletViewModel dashlet)
        {
           var response = await dashboardService.GetDataFromApiPost(dashlet);
           var data = await dashboardService.DataRetrievalResponse(response,dashlet);
           
            return Json(data);
        }

        public async Task<IActionResult> GetAllDashboardShot()
        {
            var dashboards = await dashboardService.GetAllShortsDashboards();

            return new PartialViewResult
            {
                ViewName = "~/Views/Dashboards/Partials/_DashboardNavigation.cshtml",
                ViewData = new ViewDataDictionary<DashboardShortJson>(ViewData, dashboards)
            };
        }

        public async Task<IActionResult> GetShortDashboardById(string id)
        {
            var dashboard = await dashboardService.GetShortsDashboardById(id);

            return Json(dashboard);
        }

        public async Task<IActionResult> GetDashletInfo(string dashboardId, string dashletId)
        {
            var dashletInfo = await dashboardService.GetDashletInfo(dashboardId, dashletId);

            return Json(dashletInfo);
        }

        public async Task<IActionResult> GetDashboardDashletData(string dashboardId, string dashletId)
        {
            var dashletData =  await dashboardService.GetDashboardDashletData(dashboardId, dashletId);
            var response = await dashboardService.GetDataFromApiPost(dashletData);
            var data = await dashboardService.DataRetrievalResponse(response, dashletData);
            return Json(data);
        }
    }
}
