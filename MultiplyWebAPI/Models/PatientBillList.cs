namespace MultiplyWebAPI.Models
{
    public class PatientBillList
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

        public List<BillServiceDetails> BillServiceDetails { get; set; }
        public List<BillPaymentDetails> BillPaymentDetails { get; set; }

    }

    public class BillServiceDetails
    {
        public string BillId { get; set;}
        public string ServiceDateTime { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDoctorName { get; set; }
        public decimal ServiceRate { get; set; }
        public int ServiceQuantity { get; set; }
        public decimal ServiceTotalAmount { get; set; }
        public decimal ServiceDiscountAmount { get; set; }
        public decimal ServiceTaxAmount { get; set; }
        public decimal ServiceNetAmount { get; set; }
        public decimal ServicePaidAmount { get; set; }

    }

    public class BillServiceGroupDetails
    {
        public string BillId { get; set; }
        public string ServiceGroup { get; set; }
        public string Narration { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
    }

    public class BillPaymentDetails
    {
        public string BillId { get; set; }
        public string PaymentMode { get; set; }
        public string ReferenceNo { get; set; }
        public string ReferenceDate { get; set; }
        public decimal Amount { get; set; }
        public string AdvanceNo { get; set; }
        public string AdvanceDateTime { get; set; }
        // public PatientAdvanceList PatientAdvanceList { get; set; }

    }
    public class BillList
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
}
