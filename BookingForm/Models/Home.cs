using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingForm.Models
{
    public class Home
    {
        public List<Request> Requests { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Appoinment> Appointments { get; set; }
    }
}
