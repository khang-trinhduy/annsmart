using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
