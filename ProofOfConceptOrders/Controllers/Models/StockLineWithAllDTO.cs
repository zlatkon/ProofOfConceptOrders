using ProofOfConceptOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProofOfConceptOrders.Controllers.Models
{
    public class StockLineWithAllDTO
    {
        public Guid Id { get; set; }
        public string Product { get; set; }
        public int Pallets { get; set; }
        public Guid WmsStocklineId { get; set; }
        public Guid ArticleId { get; set; }
        public string HandlingUnits { get; set; }
        public string NetWeight { get; set; }
        public string GrossWeight { get; set; }
        public string Surface { get; set; }
        public string Volume { get; set; }
        public string Length { get; set; }
        public IEnumerable<PropertyModel> Properties { get; set; }
        public IEnumerable<StockLineActionModel> Actions { get; set; }
        public IEnumerable<StockLineQuantityDTO> StockLineQuantity { get; set; }
        public static Expression<Func<StockLine, StockLineWithAllDTO>> Projection
        {
            get
            {
                return x => new StockLineWithAllDTO
                {
                    Id = x.Id,
                    Product = x.Product,
                    ArticleId = x.ArticleId,
                    GrossWeight = x.GrossWeight,
                    HandlingUnits = x.HandlingUnits,
                    Length = x.Length,
                    NetWeight = x.NetWeight,
                    Pallets = x.Pallets,
                    Surface = x.Surface,
                    Volume = x.Volume,
                    WmsStocklineId = x.WmsStocklineId,
                    Properties = x.Properties.Select(prop => new PropertyModel()
                    {
                        Name = prop.Name,
                       Value = prop.Value
                    }),
                    Actions = x.StockLineActions.Select(action => new StockLineActionModel()
                    {
                        Name = action.ActionName,
                        Properties = action.Properties.Select(prop => new PropertyModel()
                        {
                            Name = prop.Name,
                            Value = prop.Value
                        })
                    }),
                    StockLineQuantity = x.StockLineQuantities.Select(slq => new StockLineQuantityDTO()
                    { 
                        Quantity = slq.Quantity.Quantity,
                        HandlingUnit = slq.Quantity.HandlingUnit,
                        Type = slq.Type
                    })
                };
            }
        }
    }
}