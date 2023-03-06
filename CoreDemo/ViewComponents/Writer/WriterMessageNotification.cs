using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly Message2Manager _message2Manager = new Message2Manager(new EfMessage2Repository());

        public IViewComponentResult Invoke()
        {
            int id = 2;
            var values = _message2Manager.GetInboxListByWriter(id);
            return View(values);
        }
    }
}
