using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBook.Models
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }
        public List<int> ProductIds { get; set; }
        public List<int> Qtys { get; set; }
        public List<InvoiceProductModel> Products{get;set;}
    }
}