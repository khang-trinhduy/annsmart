using System.Collections.Generic;

namespace BookingForm.Models
{
    public class AdminModal
    {
        public List<int> officials { get; set; }
        public Appoinment appoinment { get; set; }
        public  List<Appoinment> appoinments { get; set; }
    }
}
