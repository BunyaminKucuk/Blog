using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {

        public IViewComponentResult Invoke(int id)
        {
            var values = _commnetManager.GetList(id);
            return View(values);
        }
    }
}
