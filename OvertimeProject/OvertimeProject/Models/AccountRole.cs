using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.Models
{
    [Table("Tb_T_AccountRole")]
    public class AccountRole
    {
        [Key]
        public int AccountRoleId { get; set; }
        [Required]
        public string AccountId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
