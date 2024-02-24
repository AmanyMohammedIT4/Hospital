using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace Hospital.ViewModels
{
    public class TimingViewModel
    {
        public int ID { get; set; }
        public ApplicationUser Doctor { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int MoringShiftStartTime { get; set; }
        public int MoringShiftEndTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        List<SelectListItem> moringShiftStart = new List<SelectListItem>();
        List<SelectListItem> moringShiftEnd = new List<SelectListItem>();
        List<SelectListItem> afternoonShiftEnd = new List<SelectListItem>();
        List<SelectListItem> afternoonShiftStart = new List<SelectListItem>();

        public TimingViewModel()
        {

        }
        public TimingViewModel(Timing model)
        {
            ID = model.ID;
            ScheduleDate = model.Date;
            MoringShiftEndTime = model.MoringShiftEndTime;
            MoringShiftStartTime = model.MoringShiftStartTime;
            AfternoonShiftEndTime = model.AfternoonShiftEndTime;
            AfternoonShiftStartTime = model.AfternoonShiftStartTime;
            Duration=model.Duration;    
            Status = model.Status;  
            Doctor=model.Doctor;
        }
        public Timing ConvertViewModel(TimingViewModel model)
        {
            return new Timing {
                ID = model.ID,
                Date = model.ScheduleDate,
                MoringShiftEndTime = model.MoringShiftEndTime,
                MoringShiftStartTime = model.MoringShiftStartTime,
                AfternoonShiftEndTime = model.AfternoonShiftEndTime,
                AfternoonShiftStartTime = model.AfternoonShiftStartTime,
                Duration = model.Duration,
                Status = model.Status,
                Doctor = model.Doctor
        };
        }
    }
}
