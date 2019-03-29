using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingForm.Models
{
    public class Request : Loan
    {
        public Guid Id { get; set; }
        [Display(Name = "Yêu cầu")]
        public string RequestName { get; set; }
        [Display(Name = "Loại yêu cầu")]
        public string Subject { get; set; }
        [Display(Name = "Nội dung")]
        public string Contents { get; set; }
        [Display(Name = "Tình trạng")]
        public Status Status { get; set; }
        [Display(Name = "Người yêu cầu")]
        public Guid? OwnerId { get; set; }
        [ForeignKey(name: "OwnerId")]
        public Sale Owner { get; set; }
       
    }

    public enum Status
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3,
        Canceled = 4,
        Accepted = 5
    }
}
