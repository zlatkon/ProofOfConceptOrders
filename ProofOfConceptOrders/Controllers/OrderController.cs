using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.InvoicingDbContext;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IInvoicingContext _invoicingContext;

        public OrderController(IInvoicingContext invoicingContext)
        {
            _invoicingContext = invoicingContext;
        }

        [HttpGet("{invoiceOrderId}")]
        [ProducesResponseType(typeof(OrderModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetInvoiceOrder(Guid invoiceOrderId)
        {
            var invoiceOrder = await _invoicingContext.Orders.AsNoTracking()
                .Select(OrderModel.Projection)
                .SingleOrDefaultAsync(x => x.Id == invoiceOrderId);

            return Ok(invoiceOrder);
        }
    }
}