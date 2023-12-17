namespace MultiplyWebAPI.Models
{
    public class Patient
    {
        public int PatientCategoryId { get; set; }
        public int UnitId { get; set; }
        public string RegNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime RegDate { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public DateTime? VisitDate { get; set; }
        public int Age { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string DoctorName { get; set; }
        public string HisVisitId { get; set; }
        public string ReasonForVisit { get; set; }
        public DateTime? EstimatedDateOfBirth { get; set; }
        public string partner_mr_no { get; set; }
        public string partner_dateofbirth { get; set; }
        public string partner_gender { get; set; }
        public int partner_age { get; set; }
        public string partner_email_id { get; set; }
        public string partner_phone { get; set; }
        public string partner_address { get; set; }
        public string partner_first_name { get; set; }
        public string partner_middle_name { get; set; }
        public string partner_last_name { get; set; }
        public string partner_prefix { get; set; }
        public string partner_estimated_dateofbirth { get; set; }
        public DateTime? partner_his_visitDate { get; set; }
        public string partner_his_visitId { get; set; }
        public string partner_ReasonForVisit { get; set; }
    }

    public enum PatientCategory
    {
        Couple = 7,
        EggDonor = 8,
        SpermDonor = 9,
        Surrogate = 10,
        Invdividual = 11
    }
}
