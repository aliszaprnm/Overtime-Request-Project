using OvertimeProject.Context;
using OvertimeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.Repository.Data
{
    public class UserRequestRepository : GeneralRepository<MyContext, UserRequest, int>
    {
        public UserRequestRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
