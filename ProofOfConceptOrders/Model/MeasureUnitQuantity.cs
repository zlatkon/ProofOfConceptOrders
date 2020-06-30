using Newtonsoft.Json;

namespace ProofOfConceptOrders.Model
{
    public class MeasureUnitQuantity
    {
        [JsonConstructor]
        protected MeasureUnitQuantity(decimal quantity, string handlingUnit)
        {
            Quantity = quantity;
            HandlingUnit = handlingUnit;
        }

        public static MeasureUnitQuantity Create(decimal quantity, string handlingUnit)
        {
            var trimmedHandlingUnit = handlingUnit ?? "".Trim();
            return new MeasureUnitQuantity(quantity, trimmedHandlingUnit);
        }

        public static MeasureUnitQuantity Empty => new MeasureUnitQuantity(0, "");
        
        [JsonProperty]
        public decimal Quantity { get; private set; }

        [JsonProperty]
        public string HandlingUnit { get; private set; }
    }
}