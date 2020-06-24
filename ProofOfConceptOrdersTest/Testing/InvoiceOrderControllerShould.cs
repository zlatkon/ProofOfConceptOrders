using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProofOfConceptOrdersTest.Testing
{
    [TestClass]
    public class InvoiceOrderControllerShould : SqlServerBaseApiTest
    {
        [TestMethod]
        public async Task ReturnAllInvoiceOrdersJson()
        {
            // GIVEN
            var order1 = InvoiceOrder.Create("Plato", Guid.NewGuid(), "ICLX000020", "TRP001");
            order1.UpdateCustomer(Guid.NewGuid(), "TestCustomer1");
            order1.UpdateOrderDate(new DateTime(2019, 03, 15));
            order1.UpdateOrderType("Inbound");
            order1.SetSite("Lb1227");

            var order2 = InvoiceOrder.Create("Plato", Guid.NewGuid(), "ICLX000020", "TRP002");
            order1.UpdateCustomer(Guid.NewGuid(), "TestCustomer1");
            order2.UpdateOrderDate(new DateTime(2019, 02, 15));
            order2.UpdateOrderType("Inbound");
            order2.SetSite("Lb1227");

            var action1 = order1.AddAction("Action1");
            var action2 = order1.AddAction("Action2");
            var action3 = order1.AddAction("Action3");
            var action4 = order2.AddAction("Action1");
            var action5 = order2.AddAction("Action2");
            var action6 = order2.AddAction("Action3");

            var property1 = order1.AddProperties("property1", "PropertyValue1");
            var property2 = order1.AddProperties("property2", "PropertyValue2");
            var property3 = order1.AddProperties("property3", "PropertyValue3");
            var property4 = order2.AddProperties("property1", "PropertyValue1");
            var property5 = order2.AddProperties("property2", "PropertyValue2");
            var property6 = order2.AddProperties("property3", "PropertyValue3");


            for (int i = 1; i <= 10; i++)
            {
                action1.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");
                action2.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");
                action3.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");

                action4.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");
                action5.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");
                action6.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");
            }
            order1.Json = JsonConvert.SerializeObject(order1);
            order2.Json = JsonConvert.SerializeObject(order2);
            await InsertAsync(order1);
            await InsertAsync(order2);

            // WHEN
            var response = await Client.GetAsync("/api/invoice-orders/AllOrdersJson");

            // THEN
            response.StatusCode.Should().Be(HttpStatusCode.OK, response.Content.ReadAsStringAsync().Result);

            var result = JsonConvert.DeserializeObject<IEnumerable<InvoiceOrder>>(response.Content.ReadAsStringAsync().Result);
            using (new AssertionScope())
            {
                result.Should().HaveCount(2);
            }
        }

        [TestMethod]
        public async Task ReturnAllInvoiceOrders()
        {
            // GIVEN
            var order1 = InvoiceOrder.Create("Plato", Guid.NewGuid(), "ICLX000020", "TRP001");
            order1.UpdateCustomer(Guid.NewGuid(), "TestCustomer1");
            order1.UpdateOrderDate(new DateTime(2019, 03, 15));
            order1.UpdateOrderType("Inbound");
            order1.SetSite("Lb1227");

            var order2 = InvoiceOrder.Create("Plato", Guid.NewGuid(), "ICLX000020", "TRP002");
            order1.UpdateCustomer(Guid.NewGuid(), "TestCustomer1");
            order2.UpdateOrderDate(new DateTime(2019, 02, 15));
            order2.UpdateOrderType("Inbound");
            order2.SetSite("Lb1227");

            var action1 = order1.AddAction("Action1");
            var action2 = order1.AddAction("Action2");
            var action3 = order1.AddAction("Action3");
            var action4 = order2.AddAction("Action1");
            var action5 = order2.AddAction("Action2");
            var action6 = order2.AddAction("Action3");

            var property1 = order1.AddProperties("property1", "PropertyValue1");
            var property2 = order1.AddProperties("property2", "PropertyValue2");
            var property3 = order1.AddProperties("property3", "PropertyValue3");
            var property4 = order2.AddProperties("property1", "PropertyValue1");
            var property5 = order2.AddProperties("property2", "PropertyValue2");
            var property6 = order2.AddProperties("property3", "PropertyValue3");

            for (int i = 1; i <= 10; i++)
            {
                action1.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");
                action2.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");
                action3.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");

                action4.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");
                action5.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");
                action6.AddProperty(Guid.NewGuid(), "string", $"name{i}", "$value{i}");
            }

            order1.Json = JsonConvert.SerializeObject(order1);
            order2.Json = JsonConvert.SerializeObject(order2);
            
            await InsertAsync(order1);
            await InsertAsync(order2);

            // WHEN
            var response = await Client.GetAsync("/api/invoice-orders/AllOrders");

            // THEN
            response.StatusCode.Should().Be(HttpStatusCode.OK, response.Content.ReadAsStringAsync().Result);

            var result = JsonConvert.DeserializeObject<IEnumerable<InvoiceOrderModel>>(response.Content.ReadAsStringAsync().Result);
            using (new AssertionScope())
            {
                result.Should().HaveCount(2);
            }
        }

        [TestMethod]
        public async Task CreateInvoiceOrders()
        {  // WHEN 
            var result = await Client.PostAsync($"/api/invoice-orders/Post", null);

            // THEN
           
            using (new AssertionScope())
            {
                result.StatusCode.Should().Be(HttpStatusCode.OK, result.Content.ReadAsStringAsync().Result);
            }
        }

        [TestMethod]
        public async Task CreateInvoiceOrdersJson()
        {  // WHEN 
            var result = await Client.PostAsync($"/api/invoice-orders/PostJson", null);

            // THEN

            using (new AssertionScope())
            {
                result.StatusCode.Should().Be(HttpStatusCode.OK, result.Content.ReadAsStringAsync().Result);
            }
        }

        [TestMethod]
        public async Task CreateInvoiceOrdersFromJson()
        {  // WHEN 
            var result = await Client.PostAsync($"/api/invoice-orders/PostJsonCreate", null);

            // THEN

            using (new AssertionScope())
            {
                result.StatusCode.Should().Be(HttpStatusCode.OK, result.Content.ReadAsStringAsync().Result);
            }
        }
    }
}