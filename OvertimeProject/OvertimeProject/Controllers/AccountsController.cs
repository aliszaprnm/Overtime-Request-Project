using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvertimeProject.Base;
using OvertimeProject.Models;
using OvertimeProject.Repository.Data;
using OvertimeProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        AccountRepository repo;
        public AccountsController(AccountRepository accountRepository) : base(accountRepository)
        {
            this.repo = accountRepository;
        }
        [HttpPost("{Register}")]
        public ActionResult Register(RegisterVM register)
        {
            var reg = repo.Register(register);
            if (reg > 0)
            {
                return Ok("Data Inserted");
            }
            else
            {
                return BadRequest("Email Duplicate, Try New Email");
            }
        }
        [HttpPost("Login")]
        //[Route("Login")]
        public ActionResult Login(LoginVM loginvm)
        {
            var login = repo.Login(loginvm);

            if (login == 404)
            {
                return BadRequest("Email Belum Terdaftar");
            }
            else if (login == 401)
            {
                return BadRequest("Password Salah");
            }
            else if (login == 1)
            {
                return Ok(new JWTokenVM
                {
                    Token = repo.GenerateToken(loginvm),
                    Message = "Login Sukses"
                });
            }
            else
                return BadRequest("Gagal Login");
        }
        [HttpPut("ResetPassword")]
        public ActionResult ResetPassword(RegisterVM register)
        {
            var data = repo.ResetPassword(register.Email);
            if (data > 0)
            {
                return Ok(new { message = "Email has been Sent, password changed", status = "Ok" });
            }
            else
                return NotFound(new { message = "Data not exist in our database, please register first", status = 404 });
        }
        [EnableCors("AllowOrigin")]
        //[Authorize(Roles = "ADD2")]
        [HttpGet("GetAllProfile")]
        public ActionResult GetAllProfile()
        {
            var get = repo.GetAllProfile();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data tidak Ada");
            }
        }

        //masih error
        [HttpGet("GetProfile")]
        public ActionResult GetAllProfileByRole([FromQuery(Name = "roleId")] string roleId)
        {
            var get = repo.GetAllProfileByRole(int.Parse(roleId));
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data tidak Ada");
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("GetProfileById/{NIK}")]
        public ActionResult GetProfileById(string NIK)
        {
            var get = repo.GetProfileById(NIK);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("No Record");
            }
        }
        [HttpPut("ChangePassword")]
        public ActionResult ChangePassword(ChangePasswordVM changePasswordVM)
        {
            var acc = repo.Get(changePasswordVM.NIK);
            if (acc != null)
            {
                var data = repo.ChangePassword(changePasswordVM);
                return Ok(data);
            }
            return NotFound();
        }
        //[EnableCors("AllowOrigin")]
        [HttpDelete("DeleteProfile/{NIK}")]
        public ActionResult DeleteProfile(string NIK)
        {
            var del = repo.DeleteProfile(NIK);
            if (del != 0)
            {
                return Ok("Delete Success");
            }
            else
            {
                return NotFound("No Record");
            }
        }
        [EnableCors("AllowOrigin")]
        [HttpPost("UpdateProfile")]
        public ActionResult UpdateProfile(UpdateProfileVM update)
        {
            var put = repo.UpdateProfile(update);
            if (put > 0)
            {
                return Ok("Record Changed");
            }
            else 
            {
                return NotFound("Record Not Match");
            }
        }
        [HttpPut("UpdateRoles")]
        public ActionResult UpdateRoles(RegisterVM register)
        {
            var put = repo.updateRoles(register);
            if (put > 0)
            {
                return Ok("Record Changed");
            }
            else
            {
                return NotFound("Record Not Match");
            }
        }
    }
}
