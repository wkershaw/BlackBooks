using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBook.Models
{
    public class InvoiceCustomermodel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int InvoiceId { get; set; }


        public CustomerModel Customer { get; set; }
        public InvoiceModel Invoice { get; set; }
    }
}
