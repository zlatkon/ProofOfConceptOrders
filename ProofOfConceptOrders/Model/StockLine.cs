using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConceptOrders.Model
{
    public class StockLine
    {
        private readonly List<StockLineQuantity> _stockLineQuantities;
        private readonly List<StockLineProperty> _properties;
        private readonly List<StockLineAction> _stockLineActions;

        private StockLine()
        {
            _stockLineQuantities = new List<StockLineQuantity>();
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
        
        [JsonProperty]
        public Guid Id { get; private set; }
        [JsonProperty]
        public Guid WmsStocklineId { get; private set; }
        [JsonProperty]
        public Guid ArticleId { get; private set; }
        [JsonProperty]
        public string Product { get; private set; }
        public IReadOnlyCollection<StockLineQuantity> StockLineQuantities => _stockLineQuantities;
        public IReadOnlyCollection<StockLineProperty> Properties => _properties;
        public IReadOnlyCollection<StockLineAction> StockLineActions => _stockLineActions;
        public int Pallets => 12;
        public string HandlingUnits => GetStockLineQuantity("Unit");
        [JsonProperty]
        public string NetWeight { get; private set; }
        [JsonProperty]
        public string GrossWeight { get; private set; }
        [JsonProperty]
        public string Surface { get; private set; }
        [JsonProperty]
        public string Volume { get; private set; }
        [JsonProperty]
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

        public void AddStockLineProperty(StockLineProperty stockLineProperty)
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