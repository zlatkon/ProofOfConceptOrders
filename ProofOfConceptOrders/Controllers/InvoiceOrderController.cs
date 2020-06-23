using Microsoft.AspNetCore.Mvc;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.InvoicingDbContext;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceOrderController : ControllerBase
    {
        [HttpGet(Name = nameof(GetAllOrders))]
        [ProducesResponseType(typeof(IEnumerable<InvoiceOrderModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllOrders(InvoiceOrderModel model)
        {
            var invoiceOrder = await InvoicingContext

            return Ok(result);
        }
    }
}