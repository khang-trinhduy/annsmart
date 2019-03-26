using System;

namespace BookingForm.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Nationality { get; set; }
        public String Email { get; set; }
        public String MaritalStatus { get; set; }
        public DateTime DOB { get; set; }
        public String PhoneNumber { get; set; }
        public string Purpose { get; set; }
        public string Products { get; set; }
    }
}
