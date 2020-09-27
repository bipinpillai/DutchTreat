using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailservice;
        private readonly IDutchRepository _repository;
        //private readonly DutchContext _context;

        public AppController(IMailService mailservice, IDutchRepository repository)
        {
            _mailservice = mailservice;
            _repository = repository;
        }

        public IActionResult Index()
        {
            //var results = _context.Products.ToList();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            //throw new InvalidOperationException("Bad thing happened");
            return View();
        }
        
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("No errors in the form");
                _mailservice.SendMessage("abc@def.com", model.Subject, "This is a VALID contact message");
                ViewBag.UserMessage = "Valid message sent!";
                ModelState.Clear();
            }
            else
            {
                Console.WriteLine("Error in the form");
                _mailservice.SendMessage("xyz@def.com", "INVALID " + model.Subject, "This is a INVALID contact message");
                ViewBag.UserMessage = "Invalid message sent!";
            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About us";
            return View();
        }

        public IActionResult Shop()
        {
            //var result = from p in _context.Products
            //             orderby p.Category
            //             select p;

            var results = _repository.GetAllProducts();
            return View(results);
        }
    }
}