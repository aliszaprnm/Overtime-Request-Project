using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.Models
{
    [Table("Tb_M_Request")]
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        [Required]
        public string OvertimeName { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [DisplayFormat(DataFormatString = "{HH:mm:ss}")]
        [Required]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{HH:mm:ss}")]
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public int Commission { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRequest> UserRequests { get; set; }
    }
}
