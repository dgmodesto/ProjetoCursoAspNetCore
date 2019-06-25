﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Account;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.Models;
using StoreOfBuild.Web.ViewsModels;

namespace StoreOfBuild.Web.Controllers {
    public class AccountController : Controller {


        private readonly IAuthentication _authentication;
        public AccountController (IAuthentication authentication){
            _authentication = authentication;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            var result = await _authentication.Authenticate(viewModel.Email, viewModel.Password);

           if(result)
           {
               return Redirect("/");
           }
           else{
               ModelState.AddModelError(string.Empty, "Invalid login attempt");
               return View(viewModel);
           }
        }

        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return Redirect("/Account/Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}