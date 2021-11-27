using OvertimeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.ViewModels
{
    public class OvertimeResponseVM
    {
        public int RequestId { get; set; }
        public string OvertimeName { get; set; }
        public DateTime RequestDate { get; set; }
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        public string AccountId { get; set; }
        //public int RoleId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Task { get; set; }
        public int Commission { get; set; }
        public StatusRequest Status { get; set; }
    }
}
