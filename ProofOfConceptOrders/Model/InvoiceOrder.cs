using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ProofOfConceptOrders.Model
{
    public class InvoiceOrder
    {
        private readonly List<StockLine> _stockLines;
        private readonly List<Action> _actions;
        private readonly List<Property> _properties;
        private string _extendedData;

        private InvoiceOrder()
        {
            Application = string.Empty;
            Customer = string.Empty;
            OrderNumber = string.Empty;
            TransportNumber = string.Empty;
            Customer = string.Empty;
            Haulier = string.Empty;
            Site = string.Empty;

            _stockLines = new List<StockLine>();
            _actions = new List<Action>();
            _properties = new List<Property>();
        }

        public static InvoiceOrder Create(string application, Guid wmsOrderId, string orderNumber, string transportNumber)
        {
            var invoiceOrder = new InvoiceOrder
            {
                Id = Guid.NewGuid(),
                Application = application,
                WmsOrderId = wmsOrderId,
                OrderNumber = orderNumber,
                TransportNumber = transportNumber
            };
            AddCancelProperty(invoiceOrder);

            return invoiceOrder;
        }

        public Guid Id { get; private set; }
        public string Application { get; private set; }
        public Guid WmsOrderId { get; private set; }

        public string OrderType
        {
            get
            {
                return "Order";
            }
        }

        public string OrderNumber { get; private set; }
        public string TransportNumber { get; private set; }
        public Guid CustomerId { get; private set; }
        public string Customer { get; private set; }
        public string Haulier { get; private set; }
        public DateTime? Date { get; private set; }
        public DateTime? ArrivalDate { get; private set; }
        public bool IsAutomaticInvoicingAllowed { get; private set; }
        public bool IsInvoiced { get; private set; }
        public bool IsCancelled { get; private set; }
        public string CountryOfArrival { get; private set; }
        public string CountryOfDeparture { get; private set; }
        public string Site { get; private set; }
        public ICollection<StockLine> StockLines => _stockLines;
        public IReadOnlyCollection<Action> Actions => _actions;
        public IReadOnlyCollection<Property> Properties => _properties;

        public JObject ExtendedData
        {
            get
            {
                return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(_extendedData) ? "{}" : _extendedData);
            }
            set
            {
                _extendedData = value.ToString();
            }
        }

        public Property AddProperties(string name, string value)
        {
            var property = Property.Create(name, value);
            _properties.Add(property);

            return property;
        }

        public StockLine AddStockLine(string product)
        {
            var stockLine = StockLine.Create(product);
            _stockLines.Add(stockLine);

            return stockLine;
        }

        public StockLine AddStockline(Guid wmsStocklineId, Guid articleId)
        {
            var stockLine = StockLine.Create(wmsStocklineId, articleId);
            _stockLines.Add(stockLine);

            return stockLine;
        }

        public Action AddAction(string name)
        {
            var action = Action.Create(name);
            _actions.Add(action);

            return action;
        }

        public Action AddAction(Guid wmsActionId)
        {
            var action = Action.Create(wmsActionId);
            _actions.Add(action);

            return action;
        }

        public void UpdateCustomer(Guid customerId, string customer)
        {
            CustomerId = customerId;
            Customer = customer;
        }

        public void UpdateCustomer(string customer)
        {
            CustomerId = Guid.NewGuid();
            Customer = customer;
        }

        public void SetAutomaticInvoicingAllowed()
        {
            if (IsAutomaticInvoicingAllowed)
                return;

            IsAutomaticInvoicingAllowed = true;
        }

        public void SetCancelled(DateTime dateCancelled)
        {
            if (IsCancelled)
                return;

            IsCancelled = true;
        }

        public void SetInvoiced()
        {
            if (IsInvoiced)
                return;

            IsInvoiced = true;
        }

        public void UndoSetInvoiced()
        {
            if (!IsInvoiced)
                return;

            IsInvoiced = false;
        }

        public void SetProperty(Property property)
        {
            _properties.Add(property);
        }

        public void UpdateOrderType(string orderType)
        {
            var property = Property.Create("Order Type", orderType);
            SetProperty(property);
        }

        public void UpdateHaulier(string haulier)
        {
            Haulier = haulier;
        }

        public void UpdateCountryOfArrival(string countryOfArrival)
        {
            CountryOfArrival = countryOfArrival;
        }

        public void UpdateCountryOfDeparture(string countryOfDeparture)
        {
            CountryOfDeparture = countryOfDeparture;
        }

        public void UpdateOrderDate(DateTime? orderDate)
        {
            Date = ArrivalDate ?? orderDate;
        }

        public void SetArrived(DateTime dateArrived)
        {
            Date = dateArrived;
            ArrivalDate = dateArrived;
        }

        public void SetSite(string site)
        {
            Site = site;
            AddSiteProperty(site);
        }

        private static void AddCancelProperty(InvoiceOrder invoiceOrder)
        {
            var property = Property.Create("Cancel", "false");
            invoiceOrder.SetProperty(property);
        }

        private void AddSiteProperty(string site)
        {
            var property = Property.Create("Site", site);
            SetProperty(property);
        }
    }
}