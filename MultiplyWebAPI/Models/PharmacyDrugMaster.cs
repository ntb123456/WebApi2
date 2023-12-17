namespace MultiplyWebAPI.Models
{
    public class PharmacyDrugMaster
    {
        public string DrugCode { get; set; }
        public long DrugCodeID { get; set; }
        public string DrugName { get; set; }
        public string HSNCODE { get; set; }
        public long DrugNameID { get; set; }
        public string DrugMoleculeName { get; set; }
        public long DrugMoleculeNameID { get; set; }
        public string DrugGroup { get; set; }
        public long DrugGroupID { get; set; }
        public string DrugCategory { get; set; }
        public long DrugCategoryID { get; set; }
        public string DispencingType { get; set; }
        public long DispencingTypeID { get; set; }
        public string DrugRoute { get; set; }
        public long DrugRouteID { get; set; }
        public string ManufacturedBy { get; set; }
        public long ManufacturedByID { get; set; }
        public string BaseUnitOfMeasurement { get; set; }
        public long BaseUnitOfMeasurementID { get; set; }
        public double BaseMRP    { get; set; }
        public long BaseMRPID { get; set; }
        public double BaseCostPrice { get; set; }
        public long BaseCostPriceID  { get; set; }
        public long HISDrugID { get; set; }
        public string ItemName { get; set; }
        public long ItemNameID { get; set; }
        public string ItemGroup { get; set; }
        public long ItemGroupID { get; set; }
        public string ItemCategory { get; set; }
        public long ItemCategoryID { get; set; }
        public Boolean BatchRequired { get; set; }
        public long BatchRequiredID { get; set; }
        public Boolean UseOfExpiryDate { get; set; }
        public long UseOfExpiryDateID { get; set; }
        public Boolean GSTApplicable { get; set; }
        public long GSTApplicableID { get; set; }
        public string GroupName { get; set; }
        public long GroupNameID { get; set; }
        public string CategoryName { get; set; }
        public long CategoryNameID { get; set; }
        public string UoMName { get; set; }
        public long UoMNameID { get; set; }
      
        //--------

        public string ConversionPUOM { get; set; }
        public long ConversionPUOMID { get; set; }
        public string SellUnitOfMeasurement { get; set; }
        public long SellUnitOfMeasurementID { get; set; }
        public string ConversionSUOM { get; set; }
        public long ConversionSUOMID { get; set; }

        public string StockUM { get; set; }
        public long StockUMID { get; set; }


        public string ConversionStockUM { get; set; }
        public long ConversionStockUMID { get; set; }

        public int ExpireAlertBeforeDays { get; set; }
        public long ExpireAlertBeforeDaysID { get; set; }

        public int MinQty { get; set; }
        public long MinQtyID { get; set; }
        public int MaxQty { get; set; }
        public long MaxQtyID { get; set; }
        public int ReOrderQty { get; set; }
        public int ReOrderQtyID { get; set; }
        public double CGSTPer { get; set; }
        public double CGSTPerID { get; set; }
        public double IGSTPer { get; set; }
        public double IGSTPerID { get; set; }
        public double DiscountOnSale { get; set; }
        public long DiscountOnSaleID { get; set; }
        public long ItemCode { get; set; }
        public string MoleculeName { get; set; }
        public long MoleculeNameID { get; set; }
        public string ItemCompany { get; set; }
        public long ItemCompanyID { get; set; }
        public string PurchaseUnitOfMeasurement { get; set; }
        public long PurchaseUnitOfMeasurementID { get; set; }
        public string ItemRoute { get; set; }
        public long ItemRouteID { get; set; }
        public double BaseCP { get; set; }
        public long BaseCPId { get; set; }
        public int LifeHisItemId { get; set; }
        public string UnitOfMeasure { get; set; }
        public long UnitOfMeasureID { get; set; }

    }

    //public class PharmacyItem
    //{ 
    //    public string ItemName { get; set; }
    //    public string ItemGroup { get; set; }
    //    public string ItemCategory { get; set; }
    //    public string BaseUnitOfMeasurement { get; set; }
    //    public Boolean BatchesRequired { get; set; }
    //    public Boolean UseOfExpiryDate { get; set; }
    //    public Boolean GSTApplicable { get; set; }
    //}
    /*public class ItemGroup
        {
            public string GroupName { get; set; }

        }*/
    /* public class ItemCategory 
     {
         public string CategoryName { get; set; }

     }
     public class ItemUnitOfMeasurement
     {
         public string UoMName { get; set; }

     } */
}
