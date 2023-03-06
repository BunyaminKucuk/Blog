using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        private readonly Message2Manager _message2Manager = new Message2Manager(new EfMessage2Repository());

        [AllowAnonymous]
        public IActionResult Inbox()
        {
            int id = 2;
            var values = _message2Manager.GetInboxListByWriter(2);
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult MessageDetails(int id)
        {
            var messageValue = _message2Manager.TGetByID(id);
            return View(messageValue);
        }

    }
}
