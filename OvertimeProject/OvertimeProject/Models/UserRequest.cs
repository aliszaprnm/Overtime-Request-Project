using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.Models
{
    [Table("Tb_T_UserRequest")]
    public class UserRequest
    {
        [Key]
        public int UserRequestId { get; set; }
        [Required]
        public StatusRequest Status { get; set; }
        [Required]
        public string NIK { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int RequestId { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        public virtual Request Request { get; set; }

    }
    public enum StatusRequest
    {

        [Display(Name = "Pending")]
        Pending = 0,
        [Display(Name = "Approved By Manager")]
        ApproveByManager = 1,
        [Display(Name = "Approved By Finance")]
        ApproveByFinance = 2,
        [Display(Name = "Rejected")]
        Reject = 3
    }
}
