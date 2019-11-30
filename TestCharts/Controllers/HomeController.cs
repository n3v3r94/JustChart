using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TestCharts.Models;
using TestCharts.Services;
using TestCharts.ViewModels;
namespace TestCharts.Controllers
{
    public class HomeController : Controller
    {
       

        public  async Task<IActionResult> Index()
        {
            return  View();
        }

    
    }
}
