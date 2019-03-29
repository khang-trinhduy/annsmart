using System.Collections.Generic;

namespace BookingForm.Models
{
    public class AppModal
    {
        public Sale sale { get; set; }
        public List<Appoinment> appoinments { get; set; }
        public Appoinment appoinment { get; set; }
    }
}
