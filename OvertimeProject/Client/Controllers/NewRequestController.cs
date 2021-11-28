using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class NewRequestController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("JWToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;

            ViewBag.sessionNIK = tokenS.Claims.First(claim => claim.Type == "NIK").Value;
            ViewBag.sessionFName = tokenS.Claims.First(claim => claim.Type == "FirstName").Value;
            ViewBag.sessionLName = tokenS.Claims.First(claim => claim.Type == "LastName").Value;
            ViewBag.sessionRole = tokenS.Claims.First(claim => claim.Type == "Role").Value;
            ViewBag.sessionEmail = tokenS.Claims.First(claim => claim.Type == "Email").Value;
            return View();
        }
    }
}