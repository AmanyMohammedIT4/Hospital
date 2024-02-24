using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Timing
    {
        public int ID { get; set; }
        public Guid DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }
        public DateTime Date { get; set; }
        public int MoringShiftStartTime { get; set; }
        public int MoringShiftEndTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
    }
}

namespace Hospital.Models
{
    public enum Status
    {
        Available,Pending,Confirm
    }
}