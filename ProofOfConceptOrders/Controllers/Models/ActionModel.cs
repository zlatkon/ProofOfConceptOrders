using System.Collections.Generic;

namespace ProofOfConceptOrders.Controllers.Models
{
    public class ActionModel
    {
        public ActionModel()
        {
            Properties = new List<PropertyModel>();
        }

        public string Name { get; set; }
        public IEnumerable<PropertyModel> Properties { get; set; }
    }
}