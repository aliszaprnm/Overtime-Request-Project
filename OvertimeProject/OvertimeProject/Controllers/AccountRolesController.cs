using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvertimeProject.Base;
using OvertimeProject.Models;
using OvertimeProject.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRolesController : BaseController<AccountRole, AccountRoleRepository, int>
    {
        public AccountRolesController(AccountRoleRepository accountrole) : base(accountrole)
        {
        }
    }
}
