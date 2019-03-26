using System;
using System.ComponentModel.DataAnnotations;

namespace BookingForm.Models
{
    public class Feedback
    {
        
        public Guid Id { get; set; }
        [Required]
        public string Content { get; set; }
        public Guid SaleId { get; set; }
    }
}
