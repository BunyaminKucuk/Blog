using System.Linq;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        private readonly Context _context = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.adminName = _context.Admins.Where(x => x.AdminId == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.adminImg = _context.Admins.Where(x => x.AdminId == 1).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.adminDescription = _context.Admins.Where(x => x.AdminId == 1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
