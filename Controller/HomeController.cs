using Book_Store.Models;
using Book_Store.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Webgentle.BookStore.Service;

namespace Book_Store.Controllers
{
    public class HomeController:Controller
    {
        private readonly NewBookAlertConfig _newBookAlertconfiguration;
        private readonly NewBookAlertConfig _thirdPartyBookconfiguration;

        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;

        [ViewData]
        public string CustomProperty { get; set; }

        [ViewData]
        public string Title { get; set; }

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration,IMessageRepository messageRepository,
            IUserService userService)
        {
            _newBookAlertconfiguration = newBookAlertconfiguration.Get("InternalBook");
            _thirdPartyBookconfiguration = newBookAlertconfiguration.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
            _userService = userService;
        }


        public ViewResult Index()
        {

            var userId = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();

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
