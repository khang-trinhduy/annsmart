using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingForm.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Họ & tên*", Prompt = "Nguyễn Văn Minh")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "SĐT*")]
        public string Phone { get; set; }
        //[Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Note { get; set; }
        public string Condition { get; set; }
        public int CNumber { get; set; }
        public int PNumber { get; set; }
        public string Ch { get; set; }
        public double Price { get; set; }
        public string Policy { get; set; }
        public double Charges { get; set; }
        public double Totals { get; set; }
        public DateTime PDate { get; set; }
        public string q4a { get; set; }
        public bool q5a { get; set; }
        public bool q5b { get; set; }
        public bool q5c { get; set; }
        public bool q5d { get; set; }
        public bool q6a { get; set; }
        public bool q6b { get; set; }
        public bool q6c { get; set; }
        public bool q7a { get; set; }
        public bool q7b { get; set; }
        public bool q7c { get; set; }
        public bool q7d { get; set; }
        public bool q7e { get; set; }
        public bool q7f { get; set; }
        public bool q7g { get; set; }
        public bool q7h { get; set; }
        public bool q7i { get; set; }
        public bool q7j { get; set; }
        public bool q7k { get; set; }
        public bool q7l { get; set; }
        public bool q7m { get; set; }
        //public bool q7j { get; set; }
        public Guid? SupporterId { get; set; }
        [ForeignKey("SupporterId")]
        public Sale Supporter { get; set; }
        public Sale Provider { get; set; }
        public bool Signed { get; set; }
        public Guid? AppoinmentId { get; set; }
        [ForeignKey("AppoinmentId")]
        public Appoinment Appoinment { get; set; }

        
    }
}
