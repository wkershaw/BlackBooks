using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackBook.Data;
using BlackBook.Models;
using Microsoft.Extensions.Logging;

namespace BlackBook.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public InvoicesController(ApplicationDbContext context, ILogger<InvoicesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            List<InvoiceViewModel> Invoices = new List<InvoiceViewModel>();
            foreach(InvoiceModel invoice in _context.Invoices.ToList())
            {
                InvoiceViewModel viewModel = new InvoiceViewModel();
                viewModel.Id = invoice.Id;

                viewModel.Customer = (await _context.InvoiceCustomer
                    .Include(Ic => Ic.Customer)
                    .FirstOrDefaultAsync(ic => ic.InvoiceId == invoice.Id)).Customer;


                viewModel.ProductIds = new List<int>();
                viewModel.Qtys = new List<int>();
                foreach(InvoiceProductModel invoiceProduct in _context.InvoiceProducts.Where(ip => ip.Invoice.Id == invoice.Id)){
                    viewModel.ProductIds.Add(invoiceProduct.ProductId);
                    viewModel.Qtys.Add(invoiceProduct.qty);
                }

                Invoices.Add(viewModel);
            }
            return View(Invoices);
        }

      
        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["Customers"] = new SelectList(_context.Customers, "Id", "Name");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId")] InvoiceViewModel invoiceView)
        {

            if (ModelState.IsValid)
            {
                InvoiceModel invoice = new InvoiceModel();
                _context.Add(invoice);
                await _context.SaveChangesAsync();

                InvoiceCustomermodel ic = new InvoiceCustomermodel()
                {
                    CustomerId = invoiceView.CustomerId,
                    InvoiceId = invoice.Id
                };

                _context.Add(ic);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(invoiceView);
        }       

        public async Task<IActionResult> Details(int Id)
        {
            InvoiceViewModel viewModel = new InvoiceViewModel();
            viewModel.Id = Id;

            viewModel.Customer = (await _context.InvoiceCustomer
                .Include(Ic => Ic.Customer)
                .FirstOrDefaultAsync(ic => ic.InvoiceId == Id)).Customer;


            viewModel.ProductIds = new List<int>();
            viewModel.Qtys = new List<int>();
            viewModel.Products = new List<InvoiceProductModel>();
            foreach (InvoiceProductModel invoiceProduct in _context.InvoiceProducts.Where(ip => ip.Invoice.Id == Id).Include(ip => ip.Product))
            {
                InvoiceProductModel ipModel = new InvoiceProductModel()
                {
                    ProductId = invoiceProduct.ProductId,
                    Product = invoiceProduct.Product,
                    qty = invoiceProduct.qty
                };
                viewModel.Products.Add(ipModel);
            }

            return View(viewModel);
        }
    }
}
