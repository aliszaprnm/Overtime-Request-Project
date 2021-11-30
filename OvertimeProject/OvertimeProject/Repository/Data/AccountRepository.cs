using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OvertimeProject.Context;
using OvertimeProject.Handler;
using OvertimeProject.Models;
using OvertimeProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OvertimeProject.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        private readonly Hashing hashing = new Hashing();
        private readonly EmailHandler sendEmail = new EmailHandler();
        public IConfiguration _configuration;
        public AccountRepository(MyContext myContext, IConfiguration _configuration) : base(myContext)
        {
            this.myContext = myContext;
            this._configuration = _configuration;
        }
        public string GenerateToken(LoginVM login)
        {
            var search = myContext.Employees.SingleOrDefault(p => p.Email == login.Email);
            var searchRole = myContext.AccountRoles.SingleOrDefault(p => p.AccountId == search.NIK);
            var claims = new List<Claim>
            {
                new Claim("FirstName", search.FirstName),
                new Claim("LastName", search.LastName),
                new Claim("Email", search.Email),
                new Claim("NIK", search.NIK),
                //new Claim(ClaimTypes.Role, searchRole.Roles.RoleName)
                new Claim("Role", searchRole.Role.RoleName),
                new Claim("managerId", search.ManagerId)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                signingCredentials: signin, expires: DateTime.UtcNow.AddDays(1));
            var tokenwrite = new JwtSecurityTokenHandler().WriteToken(token);
            claims.Add(new Claim("TokenSecurity", tokenwrite.ToString()));
            return tokenwrite;
        }
        public String getThisYear()
        {
            return DateTime.Now.ToString("yyyy");
        }
        public int Register(RegisterVM register)
        {
            var result = 0;
            var check = myContext.Employees.FirstOrDefault(p => p.Email == register.Email);
            var cekNIK = myContext.Employees.Where(e => e.NIK.Contains(getThisYear())).ToList();
            var NIPEmployee = 0;
            if (cekNIK.Count > 0)
            {
                var splitted = cekNIK[cekNIK.Count - 1].NIK.Split(getThisYear());
                NIPEmployee = int.Parse(getThisYear() + (int.Parse(splitted[splitted.Length - 1]) + 1));
            }
            else
            {
                NIPEmployee = int.Parse(getThisYear() + 1);
            }
            if (check == null)
            {
                Employee employee = new Employee
                {
                    NIK = NIPEmployee.ToString(),
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Gender = register.Gender,
                    Salary = register.Salary,
                    Email = register.Email,
                    Phone = register.Phone,
                    DepartmentId = 2,
                    ManagerId = register.ManagerId,
                };
                myContext.Add(employee);
                result = myContext.SaveChanges();

                Account account = new Account
                {
                    AccountId = employee.NIK,
                    Password = Hashing.HashPassword(register.Password)
                };
                myContext.Add(account);
                result = myContext.SaveChanges();

                AccountRole accountRole = new AccountRole
                {
                    AccountId = account.AccountId,
                    RoleId = 1
                };
                myContext.Add(accountRole);
                result = myContext.SaveChanges();
            }
            return result;
        }
        public int Login(LoginVM login)
        {
            var res = 0;
            var check = myContext.Employees.FirstOrDefault(e => e.Email == login.Email);
            if (check != null && Hashing.ValidatePassword(login.Password, check.Account.Password))
            {
                res = 1;
            }
            else
                res = 0;
            return res;
        }
        public int ResetPassword(string email)
        {
            string resetCode = Guid.NewGuid().ToString();
            var getUser = myContext.Employees.Where(e => e.Email == email).FirstOrDefault();
            var getName = myContext.Employees.Where(n => n.FirstName == getUser.FirstName).FirstOrDefault();
           /* string firstName = getUser.FirstName;*/
            string name = getUser.FirstName + " " + getUser.LastName;
            var getAcount = myContext.Accounts.Where(a => a.AccountId == getUser.NIK).FirstOrDefault();
            if (getUser == null)
            {
                return 0;
            }
            else
            {
                var password = Hashing.HashPassword(resetCode);
                getAcount.Password = password;
                var result = myContext.SaveChanges();
                sendEmail.SendNotification(resetCode, email, name);
                return result;
            }
        }
        public IEnumerable<RegisterVM> GetAllProfile()
        {
            var all = (
                from e in myContext.Employees
                join a in myContext.Accounts on e.NIK equals a.AccountId
                join ar in myContext.AccountRoles on a.AccountId equals ar.AccountId
                select new RegisterVM
                {
                    NIK = e.NIK,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Gender = e.Gender,
                    Salary = e.Salary,
                    Email = e.Email,
                    Phone = e.Phone,
                    DepartmentId = e.DepartmentId,
                    ManagerId = e.ManagerId,
                    RoleId = ar.RoleId,
                    Password = ar.Account.Password
                }).ToList();
            return all;
        }

        //masih error
        public IEnumerable<RegisterVM> GetAllProfileByRole(int roleId)
        {
            var all = (
                from e in myContext.Employees
                join a in myContext.Accounts on e.NIK equals a.AccountId
                join ar in myContext.AccountRoles on a.AccountId equals ar.AccountId
                where ar.RoleId == roleId
                select new RegisterVM
                {
                    NIK = e.NIK,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Gender = e.Gender,
                    Salary = e.Salary,
                    Email = e.Email,
                    Phone = e.Phone,
                    DepartmentId = e.DepartmentId,
                    ManagerId = e.ManagerId,
                    RoleId = ar.RoleId,
                    Password = ar.Account.Password
                }).ToList();
            return all;
        }

        public RegisterVM GetProfileById(string NIK)
        {
            var get = (
                from e in myContext.Employees
                join a in myContext.Accounts on e.NIK equals a.AccountId
                join ar in myContext.AccountRoles on a.AccountId equals ar.AccountId
                select new RegisterVM
                {
                    NIK = e.NIK,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Gender = e.Gender,
                    Salary = e.Salary,
                    Email = e.Email,
                    Phone = e.Phone,
                    ManagerId = e.ManagerId,
                    RoleId = ar.RoleId,
                    Password = a.Password

                }).ToList();
            return get.FirstOrDefault(p => p.NIK == NIK); ;
        }
        public int ChangePassword(ChangePasswordVM changepasswordVM)
        {
            Account acc = myContext.Accounts.Where(a => a.Employee.NIK == changepasswordVM.NIK).FirstOrDefault();
            acc.Password = Hashing.HashPassword(changepasswordVM.NewPassword);
            var result = myContext.SaveChanges();
            return result;
        }
        public int DeleteProfile(string NIK)
        {
            var del = myContext.Employees.Find(NIK);
            if (del != null)
            {
                myContext.Remove(del);
                myContext.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int UpdateProfile(UpdateProfileVM update)
        {
            Employee employee = myContext.Employees.Find(update.NIK);
            employee.FirstName = update.FirstName;
            employee.LastName = update.LastName;
            employee.Phone = update.Phone;
            employee.Email = update.Email;
            employee.Gender = update.Gender;
            employee.DepartmentId = update.DepartmentId;
            employee.ManagerId = update.ManagerId;
            myContext.Update(employee);

            Account account = myContext.Accounts.Find(update.NIK);
            //account.Password = Hashing.HashPassword(register.Password.ToString()).ToString();
            myContext.Update(account);

            return myContext.SaveChanges();
        }
        public int updateRoles(RegisterVM register)
        {
            AccountRole accountRole = myContext.AccountRoles.First(p => p.AccountId == register.NIK);
            accountRole.RoleId = register.RoleId;
            myContext.Update(accountRole);
            return myContext.SaveChanges();
        }
    }
}
