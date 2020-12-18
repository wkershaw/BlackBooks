using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBook.Models
{

    public enum Status { Due, Overdue, Paid, Cancelled}
    public class InvoiceModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public InvoiceCustomermodel Customer { get; set; }
        public IEnumerable<InvoiceProductModel> Products { get; set; }
        
    }
}
