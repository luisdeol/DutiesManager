using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DutiesManager_RESTfulAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Username can't contain more than 50 characters")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created_at { get; set; }
    }
}
