using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.Interfaces;
using ProofOfConceptOrders.InvoicingDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Controllers
{
    [Route("api/stock-lines")]
    [ApiController]
    public class StockLineController : ControllerBase
    {
        private readonly IInvoicingContext _invoicingContext;
        private readonly IGetStockLinesProvider _getStockLinesProvider;

        public StockLineController(IGetStockLinesProvider getStockLinesProvider, IInvoicingContext invoicingContext)
        {
            _getStockLinesProvider = getStockLinesProvider;
            _invoicingContext = invoicingContext;
        }

        [HttpGet("{invoiceOrderId}/GetPagedStockLines")]
        [ProducesResponseType(typeof(IEnumerable<StockLineDTO>), (int)HttpStatusCode.OK)]
        [EnableQuery]
        public async Task<IActionResult> GetPagedStockLines(Guid invoiceOrderID)
        {
            var stockLines = _getStockLinesProvider.GetStockLines(invoiceOrderID);

            return Ok(stockLines);
        }

        [HttpGet("{invoiceOrderId}/GetPagedStockLinesWithAll")]
        [ProducesResponseType(typeof(IEnumerable<StockLineWithAllDTO>), (int)HttpStatusCode.OK)]
        [EnableQuery]
        public async Task<IActionResult> GetPagedStockLinesWithAll(Guid invoiceOrderID)
        {
            var stockLines = _getStockLinesProvider.GetStockLinesIncludingEverything(invoiceOrderID);

            return Ok(stockLines);
        }

        [HttpGet("{invoiceOrderId}/GetPagedStockLinesWithProperties")]
        [ProducesResponseType(typeof(IEnumerable<StockLineWithPropertiesDTO>), (int)HttpStatusCode.OK)]
        [EnableQuery]
        public async Task<IActionResult> GetPagedStockLinesWithProperties(Guid invoiceOrderID)
        {
            var stockLines = _getStockLinesProvider.GetStockLinesIncludingProperties(invoiceOrderID);

            return Ok(stockLines);
        }


        [HttpGet("orders/{invoiceOrderId}/stockLine/{stockLineId}")]
        [ProducesResponseType(typeof(StockLineWithAllDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GeStockLineById(Guid invoiceOrderId , Guid stockLineId)
        {
            var invoiceOrder = await _invoicingContext.InvoiceOrders.AsNoTracking()
                .Where(x => x.Id == invoiceOrderId) 
                .AsQueryable()
                .ToListAsync();

            var stockline = invoiceOrder.Select(x => x.StockLines.First())
                .AsQueryable()
                .Where(x => x.Id == stockLineId)
                .Select(StockLineWithAllDTO.Projection);            

            return Ok(stockline);
        }
    }
}