using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        private readonly WriterManager _writerManager = new WriterManager(new EfWriterRepository());

        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.UserMail = userMail;
            Context context = new Context();
            var writerName = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.WriterName = writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavBarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult WriterEditProfile()
        {
            Context _context = new Context();
            var userMail = User.Identity.Name;
            var writerId = _context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId)
                .FirstOrDefault();
            var writerValues = _writerManager.TGetByID(writerId);
            return PartialView(writerValues);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(writer);
            writer.WriterStatus = true;
            if (result.IsValid)
            {
                _writerManager.TUpdate(writer);
                return RedirectToAction("Index", "Dashboard");
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage addProfileImage)
        {
            var writer = new Writer();
            if (addProfileImage != null)
            {
                var extension = Path.GetExtension(addProfileImage.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterMail = addProfileImage.WriterMail;
            writer.WriterName = addProfileImage.WriterName;
            writer.WriterPassword = addProfileImage.WriterPassword;
            writer.WriterAbout = addProfileImage.WriterAbout;
            writer.WriterStatus = true;

            _writerManager.TAdd(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
