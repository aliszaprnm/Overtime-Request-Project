using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvertimeProject.Models;
using OvertimeProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class LoginController : BaseController<Account, LoginRepository, string>
    {
        LoginRepository repository;
        public LoginController(LoginRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Auth(LoginVM loginVM)
        {
            var jwToken = await repository.Auth(loginVM);
            if (jwToken == null)
            {
                return RedirectToAction("Index", "Login");
            }
            HttpContext.Session.SetString("JWToken", jwToken.Token);
            return RedirectToAction("Index", "Dashboard");
        }
        [HttpPost]
        public async Task<HttpStatusCode> Register(RegisterVM registerVM)
        {
            var result = await repository.Register(registerVM);
            return result;
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
