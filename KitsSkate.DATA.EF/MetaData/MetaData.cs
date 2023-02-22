using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitsSkate.DATA.EF.Models //.MetaData
{
   
    public class BrandsMetaData 
    {
        //Primary Key(PK)
        public int BrandId { get; set; }

        [Required(ErrorMessage = "*Field is required")]
        [StringLength(50, ErrorMessage = "*cannot exceed 50 characters")]
        [Display(Name = "Brand")]
        public string BrandName { get; set; } = null!;



        [StringLength(500, ErrorMessage = "*cannot exceed 500 characters")]
        [Display(Name = "Description")]
        public string BrandDescription { get; set; }

        [StringLength(50, ErrorMessage = "*cannot exceed 50 characters")]
        [Display(Name = "Gear Type")]
        public string GearType { get; set; } = null!;


    }

    public class GearMetaData
    {
        //PK
        public int GearId { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "*cannot exceed 200 characters")]
        [Display(Name = "Gear")]
        public string GearName { get; set; } = null!;

        [Required]
        //[DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="{0:c}")]
        [Range(0, (double)decimal.MaxValue)]
        [Display(Name = "Price")]
        public decimal GearPrice { get; set; }


        [StringLength(500, ErrorMessage = "*cannot exceed 500 characters")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string? GearDescription { get; set; }

        [Required]
        [Display(Name = "In Stock")]
        [Range(0, short.MaxValue)]
        public short GearInStock { get; set; }

        [Required]
        [Display(Name = "On Order")]
        [Range(0, short.MaxValue)]
        public short GearOnOrder { get; set; }


        [Display(Name ="Discontinued?")]        
        public bool GearAvailable { get; set; }

        public int BrandId { get; set; }

        [StringLength(75, ErrorMessage = "*Cannot exceed 75 characters")]
        [Display(Name = "Image")]
        public string? ProductImage { get; set; }

    }

    public class OrdersMetaData 
    { 
        //PK
        public int OrderId { get; set; }

        public string UserId { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "*Cannot exceed 100 characters")]
        [Display(Name = "Ship To")]
        public string ShipToName { get; set; } = null!;

        [StringLength(50, ErrorMessage = "*Cannot exceed 50 characters")]
        [Display(Name = "City")]
        [Required]
        public string ShipCity { get; set; } = null!;

        [StringLength(2, ErrorMessage = "*Must be exactly 2 characters")]
        [Display(Name = "State")]
        public string? ShipState { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "*Must be exactly 5 characters")]
        [Display(Name = "Zip")]
        [DataType(DataType.PostalCode)]
        public string ShipZip { get; set; } = null!;

    }

    public class UsersMetaData
    {

        public string UserId { get; set; } = null!;
        [StringLength(50)]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; } = null!;
        [StringLength(150)]
        public string? Address { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(2)]
        public string? State { get; set; }
        [StringLength(5)]
        [DataType(DataType.PostalCode)]
        public string? Zip { get; set; }
        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

    }
    
}//end namespace
