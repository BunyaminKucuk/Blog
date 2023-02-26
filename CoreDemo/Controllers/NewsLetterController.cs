using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NewsLetterController : Controller
    {
        private NewsLetterManager _newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            _newsLetterManager.AddNewsLetter(newsLetter);
            return PartialView();
        }
    }
}
