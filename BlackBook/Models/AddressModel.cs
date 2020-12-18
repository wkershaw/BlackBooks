using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBook.Models
{
    public class AddressModel
    {
        public int id { get; set; }
        public int CustomerId { get; set; }

        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public string ThirdLine { get; set; }
        public string Postcode { get; set; }
        public string County { get; set; }

        public CustomerModel Customer { get; set; }
    }
}
