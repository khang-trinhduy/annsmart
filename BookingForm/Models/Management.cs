using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingForm.Models
{
    public class Management
    {
        public List<Sale> sales { get; set; }
        public Sale manager { get; set; }
        public List<Appoinment> appoinments { get; set; }
    }
}
