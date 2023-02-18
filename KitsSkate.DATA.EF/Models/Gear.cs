using System;
using System.Collections.Generic;

namespace KitsSkate.DATA.EF.Models
{
    public partial class Gear
    {
        public Gear()
        {
            OrderedGears = new HashSet<OrderedGear>();
        }

        public int GearId { get; set; }
        public string GearName { get; set; } = null!;
        public decimal GearPrice { get; set; }
        public string? GearDescription { get; set; }
        public short GearInStock { get; set; }
        public short GearOnOrder { get; set; }
        public bool GearAvailable { get; set; }
        public int BrandId { get; set; }
        public string? ProductImage { get; set; }
        public string? GearTypeId { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<OrderedGear> OrderedGears { get; set; }
    }
}
