using System;
using System.Collections.Generic;

namespace KitsSkate.DATA.EF.Models
{
    public partial class OrderedGear
    {
        public int GearOrderId { get; set; }
        public int GearId { get; set; }
        public int OrderId { get; set; }
        public short? OrderQuantity { get; set; }

        public virtual Gear Gear { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
