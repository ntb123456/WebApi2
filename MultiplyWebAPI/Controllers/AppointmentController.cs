using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    //[Authorize]
    //[ApiController]
    public class AppointmentController : Controller
    {
        public readonly IConfiguration _configuration;
        public AppointmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("CreateAppointment")]
        public int CreateAppointment(Appointment _appointment)
        {
            int result = 0;

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand com = new SqlCommand("api_CreateAppointment", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@ClinicId", _appointment.ClinicId);
            com.Parameters.AddWithValue("@DepartmentId", _appointment.DepartmentId);
            com.Parameters.AddWithValue("@DoctorId", _appointment.DoctorId);
            com.Parameters.AddWithValue("@ApptDate", _appointment.ApptDate);
            com.Parameters.AddWithValue("@ApptTime", _appointment.ApptTime);
            com.Parameters.AddWithValue("@ApptReasonId", _appointment.ApptReasonId);
            com.Parameters.AddWithValue("@PatientFirstName", _appointment.PatientFirstName);
            com.Parameters.AddWithValue("@PatientLastName", _appointment.PatientLastName);
            com.Parameters.AddWithValue("@Gender", _appointment.Gender);
            com.Parameters.AddWithValue("@DateOfBirth", _appointment.DateOfBirth);
            com.Parameters.AddWithValue("@CountryCode", _appointment.CountryCode);
            com.Parameters.AddWithValue("@ContactNo", _appointment.ContactNo);
            com.Parameters.AddWithValue("@IsExisitingPatient", _appointment.IsExisitingPatient);
            com.Parameters.AddWithValue("@ApptRemarks", _appointment.ApptRemarks);
            try
            {
                com.Parameters.Add("@ResultStatus", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                result = 200;
                return result;
            }

            catch (Exception ex)
            {
                result = 204;
                return result;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetClinicList")]
        public List<Clinic> GetClinicList()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var clinicList = new List<Clinic>();

            SqlCommand com = new SqlCommand("api_GetClinics", con);
            com.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var clinic = new Clinic
                    {
                        ClinicId = Convert.ToInt32(reader["ID"]),
                        ClinicName = Convert.ToString(reader["ClinicName"])
                    };
                    clinicList.Add(clinic);
                }

                return clinicList;
            }

        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetDepartmentsByClinicId")]
        public List<ClinicDepartment> GetDepartmentsByClinicId(int ClinicId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var ClinicDepartmentList = new List<ClinicDepartment>();

            SqlCommand com = new SqlCommand("api_GetDepartmentDetailsByClinicId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ClinicId", ClinicId);
            
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var clinicDepartment = new ClinicDepartment
                    {
                        DepartmentId  = Convert.ToInt32(reader["DepartmentID"]),
                        DepartmentName = Convert.ToString(reader["DepartmentName"])
                    };
                    ClinicDepartmentList.Add(clinicDepartment);
                }

                return ClinicDepartmentList;
            }

        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetDoctorsByClinicDepartmentId")]
        public List<ClinicDepartmentDoctor> GetDoctorsByClinicDepartmentId(int ClinicId, int DepartmentId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var ClinicDepartmentDoctorList = new List<ClinicDepartmentDoctor>();

            SqlCommand com = new SqlCommand("api_GetDoctorByClinicDepartmentId", con);
            com.CommandType = CommandType.StoredProcedure;
            
            com.Parameters.AddWithValue("@ClinicId", ClinicId);
            com.Parameters.AddWithValue("@DepartmentId", DepartmentId);

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var clinicDepartmentDoctor = new ClinicDepartmentDoctor
                    {
                        DoctorId= Convert.ToInt32(reader["DoctorID"]),
                        DoctorName = Convert.ToString(reader["DoctorName"])
                    };
                    ClinicDepartmentDoctorList.Add(clinicDepartmentDoctor);
                }

                return ClinicDepartmentDoctorList;
            }

        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetAppointmentReasonList")]
        public List<AppointmentReasons> GetAppointmentReasonList()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var AppointmentReasonList = new List<AppointmentReasons>();

            SqlCommand com = new SqlCommand("api_GetAppointmentReasons", con);
            com.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var appointmentReason = new AppointmentReasons
                    {
                         ApptReasonId = Convert.ToInt32(reader["ID"]),
                        ApptReason  = Convert.ToString(reader["AppointmentReason"])
                    };
                    AppointmentReasonList.Add(appointmentReason);
                }

                return AppointmentReasonList;
            }

        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetDoctorTimesForDay")]
        public List<DoctorTimes> GetDoctorTimesForDay(int ClinicId, int DepartmentId, int DoctorId, DateTime ApptDate)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var DoctorTimes = new List<DoctorTimes>();

            SqlCommand com = new SqlCommand("api_GetDoctorTime", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@UnitId", ClinicId);
            com.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            com.Parameters.AddWithValue("@DoctorId", DoctorId);
            com.Parameters.AddWithValue("@Date", ApptDate);

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var doctorTimes = new DoctorTimes
                    {
                        DoctorTimesId  = Convert.ToInt32(reader["ScheduleId"]),
                        StartTime = Convert.ToDateTime(reader["StartTime"]),
                        EndTime = Convert.ToDateTime(reader["EndTime"])
                    };
                    DoctorTimes.Add(doctorTimes);
                }

                return DoctorTimes;
            }

        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetDoctorBookedSlots")]
        public List<DoctorBookedTimeSlots> GetDoctorBookedSlots(int ClinicId, int DepartmentId, int DoctorId, DateTime ApptDate)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var doctorBookedTimeSlots = new List<DoctorBookedTimeSlots>();

            SqlCommand com = new SqlCommand("api_GetAppointmentListByDoctorIDAndDate", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@UnitId", ClinicId);
            com.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            com.Parameters.AddWithValue("@DoctorId", DoctorId);
            com.Parameters.AddWithValue("@AppointmentDate", ApptDate);

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var doctorTimes = new DoctorBookedTimeSlots
                    {
                        ApptDate = Convert.ToDateTime(reader["AppointmentDate"]),
                        ApptFromTime  = Convert.ToDateTime(reader["FromTime"]),
                        ApptToTime = Convert.ToDateTime(reader["ToTime"])
                    };
                    doctorBookedTimeSlots.Add(doctorTimes);
                }

                return doctorBookedTimeSlots;
            }

        }
    }
}
