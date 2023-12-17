namespace MultiplyWebAPI.Models
{
    public class RefundList
    {
        public string RefundId { get; set; }
        public string ClinicName { get; set; }
        public string RefundDate { get; set; }
        public string RefundType { get; set; }
        public string ReferenceNo { get; set; }
        public string MedicalRecordNo { get; set; }
        public string PatientName { get; set; }
        public decimal RefundAmount { get; set; }
        public string RefundUserName { get; set; }
    }
    public class RefundtPaymentDetails
    {
        public string ReceiptId { get; set; }
        public string PaymentMode { get; set; }
        public string ReferenceNo { get; set; }
        public string ReferenceDate { get; set; }
        public decimal Amount { get; set; }
    }
}
