using System;
using System.Collections.Generic;

namespace KitsSkate.DATA.EF.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Gears = new HashSet<Gear>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string? BrandDescription { get; set; }
        public string? Geartype { get; set; }

        public virtual ICollection<Gear> Gears { get; set; }
    }
}
