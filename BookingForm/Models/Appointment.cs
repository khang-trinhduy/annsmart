using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingForm.Models
{
    public class Appointment
    {
        public Guid? PlanId { get; set; }
        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }
        public string IdType { get; set; }
        //public DateTime DOB { get; set; }
        //public string Avatar { get; set; }
    }
}
