using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingForm.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<ProductPlan> ProductPlans { get; set; }
    }

    public class ProductPlan
    {
        public Guid Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual Plan Plan { get; set; }
    }
}
