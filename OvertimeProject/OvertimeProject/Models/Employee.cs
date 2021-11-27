using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.Models
{
    [Table("Tb_M_Employee")]
    public class Employee
    {
        [Key]
        public string NIK { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string ManagerId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        /*[JsonIgnore]
        public virtual Employee Manager { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }*/
        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Department Department { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRequest> UserRequests { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
