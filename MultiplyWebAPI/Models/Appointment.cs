namespace MultiplyWebAPI.Models
{
    public class Appointment
    {
        public int ClinicId { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public DateTime ApptDate { get; set; }
        public DateTime ApptTime { get; set; }
        public int ApptReasonId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string Gender { get; set; }
        public string CountryCode { get; set; }
        public string ContactNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsExisitingPatient { get; set; }
        public string ApptRemarks { get; set; }
    }
    public class Clinic
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
    }
    public class ClinicDepartment
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
    public class ClinicDepartmentDoctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
    public class AppointmentReasons
    {
        public int ApptReasonId { get; set; }
        public string ApptReason { get; set; }
    }

    public class DoctorTimes
    {
        public int DoctorTimesId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }

    public class DoctorBookedTimeSlots
    {
        public DateTime ApptDate { get; set; }
        public DateTime ApptFromTime { get; set; }
        public DateTime ApptToTime { get; set; }
    }
}
