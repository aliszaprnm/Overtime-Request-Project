using OvertimeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.ViewModels
{
    public class UpdateProfileVM
    {
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ManagerId { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
    }
}
