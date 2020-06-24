using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.InvoicingDbContext;
using ProofOfConceptOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Action = ProofOfConceptOrders.Model.Action;

namespace ProofOfConceptOrders.Controllers
{
    [Route("api/invoice-orders/")]
    [ApiController]
    public class InvoiceOrderController : ControllerBase
    {
        private readonly IInvoicingContext _invoicingContext;
        private const int  row =  10;
        public InvoiceOrderController(IInvoicingContext invoicingContext)
        {
            _invoicingContext = invoicingContext;
        }

        [HttpGet("AllOrders")]
        [ProducesResponseType(typeof(IEnumerable<InvoiceOrderModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllOrders()
        {
            var invoiceOrder = await _invoicingContext.InvoiceOrders.AsNoTracking()
                .Select(InvoiceOrderModel.Projection)
                .ToListAsync();

            return Ok(invoiceOrder);
        }
         
        [HttpGet("AllOrdersJson")]
        [ProducesResponseType(typeof(IEnumerable<InvoiceOrder>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllOrdersFromJson()
        {
            var listInvoiceOrder = new List<InvoiceOrder>();

            //foreach (var invoiceOrder in _invoicingContext.InvoiceOrders)
            //{
            //    var order = JsonConvert.DeserializeObject<InvoiceOrder>(invoiceOrder.Json);
            //}
            return Ok(listInvoiceOrder);
        }

        [HttpPost("PostJson")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> PostJson()
        {
            var order = InvoiceOrder.Create("ProffOFConcept", Guid.NewGuid(), "OrderNumber", "TransportNumber");
                order.SetSite("Site");
                order.SetArrived(DateTime.Now.Date);
                order.SetAutomaticInvoicingAllowed();
                order.UpdateCountryOfArrival("MKD");
                order.UpdateCountryOfDeparture("BE");
                order.UpdateCustomer("KTN");
                order.UpdateHaulier("DHL");
                order.UpdateOrderDate(DateTime.Now.Date);

                AddProperty(order);
                AddStockline(order);
                AddAction(order);              
          
            _invoicingContext.InvoiceOrders.Add(order);

            await _invoicingContext.SaveChangesAsync();

            return Ok();
        }
        
        [HttpPost("Post")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post()
        {
            var order = InvoiceOrder.Create("ProffOFConcept", Guid.NewGuid(), "OrderNumber", "TransportNumber");
                order.SetSite("Site");
                order.SetArrived(DateTime.Now.Date);
                order.SetAutomaticInvoicingAllowed();
                order.UpdateCountryOfArrival("MKD");
                order.UpdateCountryOfDeparture("BE");
                order.UpdateCustomer("KTN");
                order.UpdateHaulier("DHL");
                order.UpdateOrderDate(DateTime.Now.Date);

                AddProperty(order);
                AddStockline(order);
                AddAction(order);
               
            
            _invoicingContext.InvoiceOrders.Add(order);

            await _invoicingContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("PostJsonCreate")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> PostJsonCreate()
        {
            var order = InvoiceOrder.Create("ProffOFConcept", Guid.NewGuid(), "OrderNumber", "TransportNumber"); order.SetSite("Site");
            order.SetArrived(DateTime.Now.Date);
            order.SetAutomaticInvoicingAllowed();
            order.UpdateCountryOfArrival("MKD");
            order.UpdateCountryOfDeparture("BE");
            order.UpdateCustomer("KTN");
            order.UpdateHaulier("DHL");
            order.UpdateOrderDate(DateTime.Now.Date);

            AddProperty(order);
            AddStockline(order);
            AddAction(order);  
            _invoicingContext.InvoiceOrders.Add(order);

            await _invoicingContext.SaveChangesAsync();

            return Ok();
        }


        private void AddProperty(InvoiceOrder order)
        {
            for (int i = 0; i < row; i++)
            {
                var property = Property.Create($"name{i.ToString()}", $"Value{i.ToString()}");
                order.SetProperty(property);
            }
        }

        private void AddAction(InvoiceOrder order)
        {
            for (int i = 0; i < row; i++)
            {
                var action = Action.Create($"prodict{i.ToString()}");
                AddActionProperty(action);
                order.AddAction(action);
            }
        }

        private void AddActionProperty(Action sction)
        {
            for (int i = 0; i < row; i++)
            {
                var actionProperty = ActionProperty.Create($"name{i.ToString()}", $"value{i.ToString()}");
                sction.AddActionProperty(actionProperty);
            }
        }

        private void AddStockline(InvoiceOrder order)
        {
            for (int i = 0; i < row; i++)
            {
                var stockLine = StockLine.Create($"prodict{i.ToString()}");
                AddStockLineProperty(stockLine);
                AddStockLineAction(stockLine);
                order.AddStockLine(stockLine);
            }
        }

        private void AddStockLineAction(StockLine stockLine)
        {
            for (int i = 0; i < row; i++)
            {
                var stockLineAction = StockLineAction.Create($"name{i.ToString()}");
                AddStockLineActionProperty(stockLineAction);
                stockLine.AddStockLineAction(stockLineAction);
            }
        }

        private void AddStockLineActionProperty(StockLineAction stockLineAction)
        {
            for (int i = 0; i < row; i++)
            {
                var stockLineActionProperty = StockLineActionProperty.Create($"name{i.ToString()}", $"value{i.ToString()}");
                stockLineAction.AddStockLineActionProperty(stockLineActionProperty);
            }
        }

        private void AddStockLineProperty(StockLine stockLine)
        {
            for (int i = 0; i < row; i++)
            {
                var stockLineProperty = StockLineProperty.Create($"name{i.ToString()}", $"value{i.ToString()}");
                stockLine.AddStockLineProperty(stockLineProperty);
            }
        }
    }
}