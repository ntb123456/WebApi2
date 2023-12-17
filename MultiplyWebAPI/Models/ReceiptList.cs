namespace MultiplyWebAPI.Models
{
    public class ReceiptList
    {
        public string ReceiptId { get; set; }
        public string ClinicName { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptType { get; set; }
        public string ReferenceNo { get; set; }
        public string MedicalRecordNo { get; set; }
        public string PatientName { get; set; }
        public decimal ReceiptAmount { get; set; }
    }
    public class ReceiptPaymentDetails
    {
        public string ReceiptId { get; set; }
        public string PaymentMode { get; set; }
        public string ReferenceNo { get; set; }
        public string ReferenceDate { get; set; }
        public decimal Amount { get; set; }
        public string AdvanceNo { get; set; }
    }
}
