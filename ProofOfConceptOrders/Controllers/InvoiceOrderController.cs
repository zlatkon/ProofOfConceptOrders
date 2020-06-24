﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.InvoicingDbContext;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Controllers
{
    [Route("api/invoice-orders")]
    [ApiController]
    public class InvoiceOrderController : ControllerBase
    {
        private readonly IInvoicingContext _invoicingContext;

        public InvoiceOrderController(IInvoicingContext invoicingContext)
        {
            _invoicingContext = invoicingContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InvoiceOrderModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllOrders()
        {
            var invoiceOrder = await _invoicingContext.InvoiceOrders.AsNoTracking()
                .Select(InvoiceOrderModel.Projection)
                .ToListAsync();

            return Ok(invoiceOrder);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        //{
        //    var order = Domain.AggregateModels.Orders.Order.Create(createOrderDto);
        //    _context.Add(order);

        //    await _context.SaveChangesAsync();

        //    return Created("", null);
        //}
    }
}