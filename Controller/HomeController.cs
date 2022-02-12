using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    public class HomeController:Controller
    {
        private readonly IConfiguration configuration;

        [ViewData]
        public string CustomProperty { get; set; }

        [ViewData]
        public string Title { get; set; }

        public HomeController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }


        public ViewResult Index()
        {

            var newBookAlert = new NewBookAlertConfig();
            configuration.Bind("NewBookAlert", newBookAlert);

            bool isDisplay = newBookAlert.DisplayNewBookAlert;

            //var newbook = configuration.GetSection("NewBookAlert");
            //var result = newbook.GetValue<bool>("DisplayNewBookAlert");
            //var bookName = newbook.GetValue<string>("BookName");


            //var result = configuration["AppName"];
            //var key1 = configuration["infoObj:key1"];
            //var key2 = configuration["infoObj:key2"];
            //var key3 = configuration["infoObj:key3:key3obj1"];
            //CustomProperty = "Custom Value";
            //Title = "Home Page From Controller";
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
