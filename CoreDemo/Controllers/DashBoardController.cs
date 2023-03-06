using System.Linq;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            Context context = new Context();
            ViewBag.TotalBlogs = context.Blogs.Count().ToString();
            ViewBag.TotalBlogsById = context.Blogs.Count(x => x.WriterId == 1);
            ViewBag.TotalCategory = context.Categories.Count();
            return View();
        }
    }
}
