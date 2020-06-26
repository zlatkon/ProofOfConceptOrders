using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Controllers
{
    [Route("api/stock-lines")]
    [ApiController]
    public class StockLineController : ControllerBase
    {
        private readonly IGetStockLinesProvider _getStockLinesProvider;

        public StockLineController(IGetStockLinesProvider getStockLinesProvider)
        {
            _getStockLinesProvider = getStockLinesProvider;
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
    }
}