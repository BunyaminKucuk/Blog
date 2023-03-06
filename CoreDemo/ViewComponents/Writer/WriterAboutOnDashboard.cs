using System.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        private readonly Context _context = new Context();

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            var writerId = _context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId)
                .FirstOrDefault();
            var values = _writerManager.GetWriterById(writerId);
            return View(values);
        }
    }
}
