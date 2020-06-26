namespace ProofOfConceptOrders.Model
{
    public class StockLineQuantity
    {
        private StockLineQuantity()
        {
        }

        public static StockLineQuantity Create(string type, decimal quantity, string handlingUnit)
        {
            return new StockLineQuantity
            {
                Type = type ?? ""
                    .ToUpper()
                    .Trim(),
                Quantity = MeasureUnitQuantity.Create(quantity, handlingUnit)
            };
        }

        public string Type { get; private set; }
        public MeasureUnitQuantity Quantity { get; private set; }

        public void ChangeQuantity(decimal quantity, string handlingUnit)
        {
            Quantity = MeasureUnitQuantity.Create(quantity, handlingUnit);
        }
    }
}