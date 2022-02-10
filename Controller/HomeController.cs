using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    public class HomeController:Controller
    {
        [ViewData]
        public string CustomProperty { get; set; }

        [ViewData]
        public string Title { get; set; }
        
      


        public ViewResult Index()
        {
            CustomProperty = "Custom Value";
            Title = "Home Page From Controller";
           //ViewBag.Title = 123;
            return View();
        }

        public ViewResult AboutUs()
        {
            Title = "AboutUs Page From Controller";
            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "ContactUs Page From Controller";
            return View();
        }

    }
}
