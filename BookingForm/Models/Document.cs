using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingForm.Models
{
    public class Document
    {
        public int Id { get; set; }
        public DateTime Create { get; set; }
        public int NumberOfDocuments { get; set; }
        public string Email { get; set; }


        public Document(DateTime create, int numberOfDocuments, string email)
        {
            Create = create;
            NumberOfDocuments = numberOfDocuments;
            Email = email;
        }
    }
}
