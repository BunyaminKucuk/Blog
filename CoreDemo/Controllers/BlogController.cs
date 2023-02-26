
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private BlogManager _blogRepository = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = _blogRepository.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = _blogRepository.GetBlogById(id);
            return View(values);
        }
    }
}
