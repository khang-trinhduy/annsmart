using System.Collections.Generic;

namespace BookingForm.Models
{
    public class Home
    {
        public List<Request> Requests { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Appoinment> Appointments { get; set; }
    }
}
