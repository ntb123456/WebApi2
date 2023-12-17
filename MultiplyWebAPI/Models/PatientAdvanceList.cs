namespace MultiplyWebAPI.Models
{
    public class PatientAdvanceList
    {

        public string AdvanceId { get; set; }
        public string AdvanceDateTime { get; set; }
        public string AdvanceNo { get; set; }
        public string MedicalRecordNo { get; set; }
        public string PatientName { get; set; }
        public decimal AdvanceAmount { get; set; }
        public string AdvanceRemark { get; set; }
        public string CollectedByUser { get; set; }

        public List<AdvancePaymentDetails> AdvancePaymentDetails { get; set; }
    }

    public class AdvancePaymentDetails
    {
        public string AdvanceId { get; set; }
        public string PaymentMode { get; set; }
        public string ReferenceNo { get; set; }
        public string ReferenceDate { get; set; }
        public decimal Amount { get; set; }
        // public PatientAdvanceList PatientAdvanceList { get; set; }

    }
    public class AdvanceList
    {
        public string AdvanceId { get; set; }
        public string ClinicName { get; set; }
        public string AdvanceDateTime { get; set; }
        public string AdvanceNo { get; set; }
        public string MedicalRecordNo { get; set; }
        public string PatientName { get; set; }
        public decimal AdvanceAmount { get; set; }
        public string AdvanceRemark { get; set; }
        public string CollectedByUser { get; set; }
    }
}