using System;
using System.Collections.Generic;
using System.Text;
using BlackBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlackBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<InvoiceProductModel> InvoiceProducts { get; set; }
        public DbSet<InvoiceModel> Invoices { get; set; }
        public DbSet<BlackBook.Models.InvoiceCustomermodel> InvoiceCustomer { get; set; }
    }
}
