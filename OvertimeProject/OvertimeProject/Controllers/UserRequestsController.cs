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
    public class UserRequestsController : BaseController<UserRequest, UserRequestRepository, int>
    {
        public UserRequestsController(UserRequestRepository userRequest) : base(userRequest)
        {
        }
    }
}
