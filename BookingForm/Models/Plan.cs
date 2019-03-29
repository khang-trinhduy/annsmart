using System;
using System.Collections.Generic;

namespace BookingForm.Models
{
    public class Plan
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public State State { get; set; }
        public ICollection<ProductPlan> ProductPlans { get; set; }
        public ICollection<Appoinment> Appointments { get; set; }
    }

    public enum State
    {
        OpenForSale = 1,
        NotOpenForSale = 2,
        Close = 3
    }
}
