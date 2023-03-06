
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Concrete;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManager _blogRepository = new BlogManager(new EfBlogRepository());
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        private readonly Context _context = new Context();


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

        public IActionResult BlogListByWriter()
        {
            var userMail = User.Identity.Name;
            var writerId = _context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId)
                .FirstOrDefault();
            var values = _blogRepository.GetListWithCategoryByWriter(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in _categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var blogValidator = new BlogValidator();
            var result = blogValidator.Validate(blog);
            if (result.IsValid)
            {
                var userMail = User.Identity.Name;
                var writerId = _context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId)
                    .FirstOrDefault();
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerId;
                _blogRepository.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogValue = _blogRepository.TGetByID(id);
            _blogRepository.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogValue = _blogRepository.TGetByID(id);
            List<SelectListItem> categoryValues = (from x in _categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var userMail = User.Identity.Name;
            var writerId = _context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId)
                .FirstOrDefault();
            blog.WriterId = writerId;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            _blogRepository.TUpdate(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
