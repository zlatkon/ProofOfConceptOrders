using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.Interfaces;
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
    [Route("api/invoice-orders")]
    [ApiController]
    public class InvoiceOrderController : ControllerBase
    {
        private readonly IInvoicingContext _invoicingContext;
        private readonly IGetInvoiceOrderProvider _getInvoiceOrderProvider;
        private const int row = 20;
        private const int orderNumber = 200;

        public InvoiceOrderController(IInvoicingContext invoicingContext, IGetInvoiceOrderProvider getInvoiceOrderProvider)
        {
            _invoicingContext = invoicingContext;
            _getInvoiceOrderProvider = getInvoiceOrderProvider;
        }

        [HttpGet("/AllOrders")]
        [ProducesResponseType(typeof(IEnumerable<InvoiceOrderModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllOrders(Guid invoiceOrderId)
        {
            var invoiceOrder = await _invoicingContext.InvoiceOrders.AsNoTracking()
                .Where(x => x.Id == invoiceOrderId)
                .Select(InvoiceOrderModel.Projection)
                .ToListAsync();

            return Ok(invoiceOrder);
        }

        [HttpGet("{invoiceOrderId}/BuildInvoiceLines")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> BuildInvoiceLines(Guid invoiceOrderId)
        {
            var invoiceOrder = await _getInvoiceOrderProvider.GetInvoiceOrder(invoiceOrderId);

            return Ok(invoiceOrder + " Milliseconds");
        }

        [HttpGet("AllOrdersJson")]
        [ProducesResponseType(typeof(IEnumerable<InvoiceOrder>), (int)HttpStatusCode.OK)]
        [EnableQuery]
        public async Task<IActionResult> GetAllOrdersFromJson()
        {
            var invoiceOrders = _invoicingContext.InvoiceOrders
                .FromSqlRaw(@"SELECT [Id]
                    ,[Application]
                    ,[WmsOrderId]
                    ,[OrderNumber]
                    ,[TransportNumber]
                    ,[CustomerId]
                    ,[Customer]
                    ,[Haulier]
                    ,[Date]
                    ,[ArrivalDate]
                    ,[IsAutomaticInvoicingAllowed]
                    ,[IsInvoiced]
                    ,[IsCancelled]
                    ,[CountryOfArrival]
                    ,[CountryOfDeparture]
                    ,[Site]
                    ,null as Actions
                    ,null as Properties
                    ,null as Stocklines
                FROM [InvoiceOrders]");

            return Ok(invoiceOrders);
        }

        [HttpGet("{invoiceOrderId}/GetById")]
        [ProducesResponseType(typeof(IEnumerable<InvoiceOrder>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(Guid invoiceOrderId)
        {
            var invoiceOrders = _invoicingContext.InvoiceOrders
                .FromSqlRaw(@"SELECT [Id]
                    ,[Application]
                    ,[WmsOrderId]
                    ,[OrderNumber]
                    ,[TransportNumber]
                    ,[CustomerId]
                    ,[Customer]
                    ,[Haulier]
                    ,[Date]
                    ,[ArrivalDate]
                    ,[IsAutomaticInvoicingAllowed]
                    ,[IsInvoiced]
                    ,[IsCancelled]
                    ,[CountryOfArrival]
                    ,[CountryOfDeparture]
                    ,[Site]
                    ,[Actions] as Actions
                    ,Properties as Properties
                    ,Stocklines as Stocklines
                FROM [InvoiceOrders]
                Where Id = ({0})", invoiceOrderId);

            return Ok(invoiceOrders);
        }

        [HttpPost("PostJson")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> PostJson()
        {
            for (int i = 0; i < orderNumber; i++)
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

                AddProperties(order);
                AddStockLines(order);
                AddActions(order);

                _invoicingContext.InvoiceOrders.Add(order);

                await _invoicingContext.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPost("CreateFromJson")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateFromJson(CreateInvoiceOrderModel createInvoiceOrderModel)
        {
            var propertyTypes = await GetPropertyTypes(createInvoiceOrderModel);
            var order = ToEntity(createInvoiceOrderModel, propertyTypes);

            _invoicingContext.InvoiceOrders.Add(order);

            await _invoicingContext.SaveChangesAsync();

            return Ok();
        }

        private void AddProperties(InvoiceOrder order)
        {
            for (int i = 0; i < row; i++)
            {
                var property = Property.Create($"name{i}", $"Value{i}");
                order.SetProperty(property);
            }
        }

        private void AddActions(InvoiceOrder order)
        {
            for (int i = 0; i < row; i++)
            {
                var action = Action.Create($"prodict{i}");
                AddActionProperty(action);
                order.AddAction(action);
            }
        }

        private void AddActionProperty(Action sction)
        {
            for (int i = 0; i < row; i++)
            {
                var actionProperty = ActionProperty.Create($"name{i}", $"value{i}");
                sction.AddActionProperty(actionProperty);
            }
        }

        private void AddStockLines(InvoiceOrder order)
        {
            for (int i = 0; i < 20; i++)
            {
                var stockLine = StockLine.Create($"prodict{i}");
                AddStockLineProperty(stockLine);
                AddStockLineAction(stockLine);
                order.AddStockLine(stockLine);
            }
        }

        private void AddStockLineAction(StockLine stockLine)
        {
            for (int i = 0; i < row; i++)
            {
                var stockLineAction = StockLineAction.Create($"name{i}");
                AddStockLineActionProperty(stockLineAction);
                stockLine.AddStockLineAction(stockLineAction);
            }
        }

        private void AddStockLineActionProperty(StockLineAction stockLineAction)
        {
            for (int i = 0; i < row; i++)
            {
                var stockLineActionProperty = StockLineActionProperty.Create($"name{i}", $"value{i}");
                stockLineAction.AddStockLineActionProperty(stockLineActionProperty);
            }
        }

        private void AddStockLineProperty(StockLine stockLine)
        {
            for (int i = 0; i < row; i++)
            {
                var stockLineProperty = StockLineProperty.Create($"name{i}", $"value{i}");
                stockLine.AddStockLineProperty(stockLineProperty);
            }
        }

        private async Task<IEnumerable<PropertyType>> GetPropertyTypes(CreateInvoiceOrderModel createInvoiceOrderModel)
        {
            var propertyTypes = await _invoicingContext.PropertyTypes.AsNoTracking().
                Where(x =>
                    x.Application.ToUpper() == createInvoiceOrderModel.Application.ToUpper())
                .ToListAsync();
            return propertyTypes;
        }

        private InvoiceOrder ToEntity(CreateInvoiceOrderModel createInvoiceOrderModel, IEnumerable<PropertyType> propertyTypes)
        {
            var order = InvoiceOrder.Create(createInvoiceOrderModel.Application, Guid.Empty, createInvoiceOrderModel.OrderNumber, createInvoiceOrderModel.TransportNumber);
            order.UpdateOrderType(createInvoiceOrderModel.OrderType);
            order.UpdateCustomer(createInvoiceOrderModel.CustomerId, createInvoiceOrderModel.CustomerCode);
            order.UpdateOrderDate(createInvoiceOrderModel.Date);
            order.SetSite(createInvoiceOrderModel.Site);
            AddActions(order);
            AddStockLines(order);
            AddProperties(order);

            return order;
        }
    }
}