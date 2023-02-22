using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace KitsSkate.DATA.EF.Models //.MetaData
{

    [ModelMetadataType(typeof(BrandsMetaData))]

    public partial class Brand { }


    [ModelMetadataType(typeof(OrdersMetaData))]
    public partial class Order { }

    [ModelMetadataType(typeof(GearMetaData))]
    public partial class Gear { }

    [ModelMetadataType(typeof(UsersMetaData))]
    public partial class User { }

}
