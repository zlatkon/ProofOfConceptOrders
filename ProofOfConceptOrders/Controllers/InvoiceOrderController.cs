using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.InvoicingDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

namespace ProofOfConceptOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceOrderController : ControllerBase
    {
        private readonly InvoicingContext _invoicingContext;

        public InvoiceOrderController(InvoicingContext invoicingContext)
        {
            _invoicingContext = invoicingContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<InvoiceOrderModel>), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> GetAllOrders()
        //{
        //    var invoiceOrder = await _invoicingContext.InvoiceOrders.AsNoTracking()
        //        .Select(InvoiceOrderModel.Projection)
        //        .ToListAsync();

        //    return Ok(invoiceOrder);
        //}
    }
}