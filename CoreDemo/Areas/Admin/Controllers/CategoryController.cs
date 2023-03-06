using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index(int page = 1)
        {
            var categoryValues = _categoryManager.GetList().ToPagedList(page, 10);
            return View(categoryValues);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            var categoryValidator = new CategoryValidator();
            var result = categoryValidator.Validate(category);

            if (result.IsValid)
            {
                category.CategoryStatus = true;
                _categoryManager.TAdd(category);
                return RedirectToAction("Index", "Category");
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


        public IActionResult CategoryDelete(int id)
        {
            var categoryValue = _categoryManager.TGetByID(id);
            _categoryManager.TDelete(categoryValue);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            var categoryValue = _categoryManager.TGetByID(id);
            return View(categoryValue);
        }

        [HttpPost]
        public IActionResult CategoryEdit(Category category)
        {
            category.CategoryStatus = true;
            _categoryManager.TUpdate(category);
            return RedirectToAction("Index", "Category");
        }
    }
}
