namespace MultiplyWebAPI.Models
{
    public class PharmacyBill
    {
        public string BillId { get; set; }
        public string BillNo { get; set; }
        public string BillDateTime { get; set; }
        public string MedicalRecordNo { get; set; }
        public string PatientName { get; set; }
        public string BillType { get; set; }
        public string BillCategory { get; set; }
        public string BillUser { get; set; }
        public decimal TotalBillAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetBillAmount { get; set; }
        public decimal PaidBillAmount { get; set; }

        public List<BillServiceDetails> PharmacyBillItemDetails { get; set; }
        public List<BillPaymentDetails> PharmacyBillPaymentDetails { get; set; }
    }

    public class PharmacyBillItemDetails
    {
        public string BillId { get; set; }
        public string ItemName { get; set; }
        public string ItemBatchCode { get; set; }
        public string ItemExpiryDate { get; set; }
        public decimal ItemMRP { get; set; }
        public int ItemQuantity { get; set; }
        public string ItemUOM { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ItemDiscountAmount { get; set; }
        public decimal SGSTPercentage { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal CGSTPercentage { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal IGSTPercentage { get; set; }
        public decimal IGSTAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TotalBillAmount { get; set; }
        public decimal NetBillAmount { get; set; }
        public decimal RoundOffAmount { get; set; }
    }
    public class PharmacyBillPaymentDetails
    {
        public string BillId { get; set; }
        public string PaymentMode { get; set; }
        public string ReferenceNo { get; set; }
        public string ReferenceDate { get; set; }
        public decimal Amount { get; set; }
        public string AdvanceNo { get; set; }
        public string AdvanceDateTime { get; set; }
    }

    public class PharmacyBillList
    {
        public string BillId { get; set; }
        public string ClinicName { get; set; }
        public string BillNo { get; set; }
        public string BillDateTime { get; set; }
        public string MedicalRecordNo { get; set; }
        public string PatientName { get; set; }
        public string BillType { get; set; }
        public string BillCategory { get; set; }
        public string BillUser { get; set; }
        public decimal TotalBillAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetBillAmount { get; set; }
    
    }
    public class PharmacyBillGSTDetails
    {
        public string BillId { get; set; }
        public decimal SGSTPercentage { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal CGSTPercentage { get; set; }
        public decimal CGSTAmount { get; set; }
    }
}
