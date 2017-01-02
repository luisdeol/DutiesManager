using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutiesManager.Models
{
    public class Duty
    {
        public int DutyId { get; set; }
        public string DutyTitle { get; set; }
        public string Description { get; set; }
        public DateTime DueTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
    }
}
