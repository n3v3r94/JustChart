using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestCharts.Service;
using TestCharts.ViewModels;

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
    }
}
