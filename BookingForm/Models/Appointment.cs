using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingForm.Models
{
    public class Appointment
    {
        public Guid? PlanId { get; set; }
        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }
        public string IdType { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Avatar { get; set; }
        public string HouseholdPhoto { get; set; }
        [Display(Name = "View")]
        public string View { get; set; }
        [Display(Name = "Hướng")]
        public string Direction { get; set; }
        [Display(Name = "Tầng")]
        public int Floor { get; set; }
        [Display(Name = "Diện tích")]
        public double Acreage { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime Create { get; set; }
    }
}
