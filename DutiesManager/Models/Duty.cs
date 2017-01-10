using System;

namespace DutiesManager.Models
{
    public class Duty
    {
        public int DutyId { get; set; }
        public string DutyTitle { get; set; }
        public string Description { get; set; }
        public string DueTime { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
    }
}
