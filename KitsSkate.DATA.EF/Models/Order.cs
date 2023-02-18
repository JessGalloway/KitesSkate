using System;
using System.Collections.Generic;

namespace KitsSkate.DATA.EF.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderedGears = new HashSet<OrderedGear>();
        }

        public int OrderId { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime PurchaseDate { get; set; }
        public string ShipToName { get; set; } = null!;
        public string ShipCity { get; set; } = null!;
        public string? ShipState { get; set; }
        public string ShipZip { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderedGear> OrderedGears { get; set; }
    }
}
