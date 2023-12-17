using System.ComponentModel.DataAnnotations;
namespace MultiplyWebAPI.DTOs
{
    public class SupplierMasterDTO
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Pannumber { get; set; }
        [Required]
        public string GSTINNO { get; set; }
        [Required]
        public string Description { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string Pincode { get; set; }
        public string ContactPerson1Name { get; set; }
        public string ContactPerson1Mobile { get; set; }
        public string ContactPerson1EmailId { get; set; }
        public string ContactPerson2Name { get; set; }
        public string ContactPerson2Mobile { get; set; }
        public string ContactPerson2EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string Fax { get; set; }
        public int ModeofPayment { get; set; }
        public int TaxNature { get; set; }
        public int TermofPayment { get; set; }
        public int Currency { get; set; }
        public string MSTNumber { get; set; }
        public string VATNumber { get; set; }
        public string CSTNumber { get; set; }
        public string DrugLicenceNumber { get; set; }
        public string ServiceTaxNumber { get; set; }
        public int SupplyCategory { get; set; }
        public string Depriciation { get; set; }
        public int POAutoCloseDays { get; set; } 

    }
};