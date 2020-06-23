using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.Model;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Testing
{
    [TestClass]
    public class InvoiceOrderControllerShould
    {
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

            //Settup InsertAsync(order1, order2);

            // WHEN
            var response = await Client.GetAsync("/api/invoice-orders?$count=true");

            // THEN
            response.StatusCode.Should().Be(HttpStatusCode.OK, response.Content.ReadAsStringAsync().Result);

            var result = JsonConvert.DeserializeObject<IEnumerable<InvoiceOrderModel>>(response.Content.ReadAsStringAsync().Result);
            using (new AssertionScope())
            {
                result.Meta.TotalCount.Should().Be(2);
                var orders = result.Data;
                orders.Should().HaveCount(2);
                result.Data.Should()
                    .ContainEquivalentOf(expected);
            }
        }
    }
}