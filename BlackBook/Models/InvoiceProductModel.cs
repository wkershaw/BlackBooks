using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBook.Models
{
    public class InvoiceProductModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public int qty { get; set; }


        public ProductModel Product { get; set; }
        public InvoiceModel Invoice { get; set; }
    }
}
