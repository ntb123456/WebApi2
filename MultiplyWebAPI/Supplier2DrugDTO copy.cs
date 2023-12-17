using System.ComponentModel.DataAnnotations;
namespace MultiplyWebAPI.DTOs
{
    public class PharmacyDrugDTO 
    {     
        [Required]
        public string ClinicName { get; set; }
        public long ItemCode { get; set;  }
        [Required]
        public string ItemName { get; set; }
        public string HSNCODE { get; set; }
        [Required]
        public string MoleculeName { get; set; }
        [Required]
        public string ItemGroup { get; set; }
        [Required]
        public string ItemCategory { get; set; }
        [Required]
        public string DispencingType { get; set; }
        [Required]
        public string ItemCompany { get; set; }
        [Required]
        public string PurchaseUnitOfMeasurement { get; set; }
        [Required]
        public double ConversionPUOM { get; set; }
        [Required]
        public string SellUnitOfMeasurement { get; set; }
        [Required]
        public double ConversionSUOM { get; set; }
        public string BaseUnitOfMeasurement { get; set; }
        [Required]
        public double ConversionBUOM { get; set; }

        [Required]
        public string ItemRoute { get; set; }
        [Required]
        public double BaseMRP { get; set; }
        [Required]
        public double BaseCP { get; set; }
        [Required]
        public int LifeHisItemId { get; set; }
        [Required]
        
        public bool BatchRequired { get; set; }
        [Required]
        public int ExpireAlertBeforeDays { get; set; }

        public int MinQty { get; set; }
        public int MaxQty { get; set; }
        public int ReOrderQty { get; set; }
        public double CGSTPer { get; set; }
        public double IGSTPer { get; set; }
        public double DiscountOnSale { get; set; }







    }
}