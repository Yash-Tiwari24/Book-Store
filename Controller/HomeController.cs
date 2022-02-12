using Book_Store.Models;
using Book_Store.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    public class HomeController:Controller
    {
        private readonly NewBookAlertConfig _newBookAlertconfiguration;
        private readonly NewBookAlertConfig _thirdPartyBookconfiguration;

        private readonly IMessageRepository _messageRepository;

        [ViewData]
        public string CustomProperty { get; set; }

        [ViewData]
        public string Title { get; set; }

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration,IMessageRepository messageRepository)
        {
            _newBookAlertconfiguration = newBookAlertconfiguration.Get("InternalBook");
            _thirdPartyBookconfiguration = newBookAlertconfiguration.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
        }


        public ViewResult Index()
        {

         

            bool isDisplay = _newBookAlertconfiguration.DisplayNewBookAlert;
            bool isDisplay1= _thirdPartyBookconfiguration.DisplayNewBookAlert;


            //var value = _messageRepository.GetName();

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
