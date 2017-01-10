using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DutiesManager_RESTfulAPI.Models
{
    public class Duty
    {
        public int DutyId { get; set; }
        [Required, StringLength(50, ErrorMessage = "Your title should have up to 50 characters. ")]
        public string DutyTitle{ get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public string DueTime { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
