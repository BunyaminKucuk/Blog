using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        private readonly Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            //ilk önce blogları id göre sıralıyoruz ve en son eklenen blogun bsaslıgını alıyoruz
            ViewBag.blogTitle = _context.Blogs.OrderByDescending(x => x.BlogId).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.contactListCount = _context.Contacts.Count();
            ViewBag.commenttListCount = _context.Comments.Count();
            return View();
        }
    }
}
