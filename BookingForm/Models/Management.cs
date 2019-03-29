using System.Collections.Generic;

namespace BookingForm.Models
{
    public class Management
    {
        public List<Sale> sales { get; set; }
        public Sale manager { get; set; }
        public List<Appoinment> appoinments { get; set; }
    }
}
