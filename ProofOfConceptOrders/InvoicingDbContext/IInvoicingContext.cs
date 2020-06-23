using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Action = ProofOfConceptOrders.Model.Action;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public interface IInvoicingContext
    {
        DbSet<InvoiceOrder> InvoiceOrders { get; }
        DbSet<StockLine> StockLines { get; }
        DbSet<Property> Property { get; }
        DbSet<Action> Actions { get; }
    }
}
