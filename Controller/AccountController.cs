using Book_Store.Models;
using Book_Store.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
           
            _accountRepository = accountRepository;
        }




        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }


        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel UserModel)
        {
            if(ModelState.IsValid)
            {
                var result =await _accountRepository.CreateUserAsync(UserModel);
                if(!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(UserModel);
                }

                ModelState.Clear();
                return View();
            }
            return View(UserModel);
        }
    }
}
