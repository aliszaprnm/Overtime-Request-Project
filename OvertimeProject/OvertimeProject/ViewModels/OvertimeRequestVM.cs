using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.ViewModels
{
    public class OvertimeRequestVM
    {
        public string NIK { get; set; }
        public string Email { get; set; }
        public string AccountId { get; set; }
        public int Status { get; set; }
        public int RequestId { get; set; }
        public int RoleId { get; set; }
    }
}
