using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBook.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public InvoiceCustomermodel Customer { get; set; }
        public IEnumerable<InvoiceProductModel> Products { get; set; }
        
    }
}
