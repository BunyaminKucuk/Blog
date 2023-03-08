using System.Collections.Generic;
using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            var categoriesList = new List<CategoryModel>
            {
                new CategoryModel
                {
                    CategoryName = "Teknoloji",
                    CategoryCount = 10
                },
                new CategoryModel
                {
                    CategoryName = "Yazılım",
                    CategoryCount = 5
                },
                new CategoryModel
                {
                    CategoryName = "Spor",
                    CategoryCount = 16
                }
            };

            return Json(new { jsonlist = categoriesList });
        }
    }
}
