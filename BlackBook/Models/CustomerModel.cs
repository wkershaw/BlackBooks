using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBook.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressModel Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
