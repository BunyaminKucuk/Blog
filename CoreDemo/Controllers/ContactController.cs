﻿using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactManager _contactManager = new ContactManager(new EfContactRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.ContactStatus = true;
            _contactManager.TAdd(contact);
            return RedirectToAction("Index","Blog");
        }
    }
}
