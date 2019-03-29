using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingForm.Models
{
    public class Result
    {
        public int Id { get; set; }
        public List<Answer> Answer { get; set; }
        public Test Test { get; set; }
        public Guid SaleId { get; set; }
        public int TestId { get; set; }
    }
}
