using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        private readonly Context _context = new Context();

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            ViewBag.UserName = userName;
            var writerId = _context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId)
                .FirstOrDefault();
            var values = _writerManager.GetWriterById(writerId);
            return View(values);
        }
    }
}
