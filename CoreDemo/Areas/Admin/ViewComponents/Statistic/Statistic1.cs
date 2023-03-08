using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        private readonly BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        private readonly Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.blogListCount = _blogManager.GetList().Count();
            ViewBag.contactListCount = _context.Contacts.Count();
            ViewBag.commenttListCount = _context.Comments.Count();


            const string weatherApi = "b3b05132525e83744e4d89dc5f9e63b9";
            const string connection = "https://api.openweathermap.org/data/2.5/weather?q=gaziantep&mode=xml&lang=tr&units=metric&appid=" + weatherApi;

            var document = XDocument.Load(connection);
            ViewBag.temperature = document.Descendants("temperature").ElementAt(0).Attribute("value")?.Value;
            return View();
        }
    }
}
