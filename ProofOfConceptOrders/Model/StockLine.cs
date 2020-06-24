using ProofOfConceptOrders.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConceptOrders.Model
{
    public class StockLine
    { 
        private readonly List<StockLineProperty> _properties;
        private readonly List<StockLineAction> _stockLineActions;

        private StockLine()
        { 
            _properties = new List<StockLineProperty>();
            _stockLineActions = new List<StockLineAction>();
            NetWeight = NetWeight;
            GrossWeight = GrossWeight;
            Volume = Volume;
            Surface = Surface;
            Length = Length;
        }

        public static StockLine Create(string product)
        {
            return new StockLine()
            {
                Id = Guid.NewGuid(),
                Product = product
            };
        }

        public static StockLine Create(Guid wmsStocklineId, Guid articleId)
        {
            return new StockLine()
            {
                Id = Guid.NewGuid(),
                WmsStocklineId = wmsStocklineId,
                ArticleId = articleId
            };
        }

        public Guid Id { get; private set; }
        public Guid WmsStocklineId { get; set; }
        public Guid ArticleId { get; set; }
        public string Product { get; private set; } 
        public IReadOnlyCollection<StockLineProperty> Properties => _properties;
        public IReadOnlyCollection<StockLineAction> StockLineActions => _stockLineActions;
        public int Pallets => 12;
        public string HandlingUnits => GetStockLineQuantity("Unit");
        public string NetWeight { get; private set; }
        public string GrossWeight { get; private set; }
        public string Surface { get; private set; }
        public string Volume { get; private set; }
        public string Length { get; private set; }

        private string GetStockLineQuantity(string type)
        {
            return type;
        }

        public void AddProperty(string name, string value)
        {
            var property = StockLineProperty.Create(name, value);
            _properties.Add(property);
        }

        public void AddStockLineAction(StockLineAction stockLineAction)
        {
            _stockLineActions.Add(stockLineAction);
        }
        
        public void AddStockLineProperty(StockLineProperty  stockLineProperty)
        { 
            _properties.Add(stockLineProperty);
        }
        
        public StockLineProperty GetProperty(string name)
        {
            var prop = _properties.SingleOrDefault(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            return prop;
        }
         

        public void SetNetWeight(string weight)
        {
            NetWeight = weight;
        }

        public void SetGrossWeight(string weight)
        {
            GrossWeight = weight;
        }

        public void SetSurface(string surface)
        {
            Surface = surface;
        }

        public void SetVolume(string volume)
        {
            Volume = volume;
        }

        public void SetLength(string length)
        {
            Length = length;
        }

        public StockLineAction AddAction(string name, string application)
        {
            var stockLineAction = StockLineAction.Create(name);
            _stockLineActions.Add(stockLineAction);

            return stockLineAction;
        }

        public StockLineAction GetStockLineAction(Guid id)
        {
            var stockLineAction = _stockLineActions.SingleOrDefault(x => x.Id == id);
            return stockLineAction;
        }
    }
}