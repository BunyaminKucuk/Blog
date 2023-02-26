using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		private BlogManager _blogManager = new BlogManager(new EfBlogRepository());

		public IViewComponentResult Invoke()
		{
			var values = _blogManager.GetBlogListByWriter(1);
			return View(values);
		}
	}
}
