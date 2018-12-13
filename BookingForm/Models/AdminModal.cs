using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingForm.Models
{
    public class AdminModal
    {
        public List<int> officials { get; set; }
        public Admin admin { get; set; }
        public Appoinment appoinment { get; set; }
        public  List<Appoinment> appoinments { get; set; }
    }
}
