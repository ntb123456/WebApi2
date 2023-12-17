using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class PatientListController : Controller
    {
        public readonly IConfiguration _configuration;

        public PatientListController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllPatientList")]
        //[Route("[controller]")]
        public List<PatientList> GetAllPatientList(DateTime? RegistrationDate, long? ClinicId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            
            if (con.State == ConnectionState.Closed)
                con.Open();

            var patientList = new List<PatientList>();

            SqlCommand com = new SqlCommand("api_GetPatients", con);
            com.CommandType = CommandType.StoredProcedure;
            if (RegistrationDate == null)
                RegistrationDate = DateTime.Now;
            
            if (ClinicId == null)
                ClinicId = 0;
            
            com.Parameters.AddWithValue("@RegistrationDate", RegistrationDate);
            com.Parameters.AddWithValue("@UnitId", ClinicId);

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    var patient = new PatientList
                    {
                        PatientId = Convert.ToString(reader["PatientId"]),
                        ClinicName = Convert.ToString(reader["ClinicName"]),
                        RegistrationDateTime = Convert.ToString(reader["RegistrationDateTime"]),
                        PatientName = Convert.ToString(reader["PatientName"]),
                        Gender = Convert.ToString(reader["Gender"]),
                        MedicalRecordNo = Convert.ToString(reader["MedicalRecordNo"]),
                        ContactNo = Convert.ToString(reader["ContactNo"]),
                        EmailId = Convert.ToString(reader["EmailId"]),
                        AddressLine1 = Convert.ToString(reader["AddressLine1"]),
                        AddressLine2 = Convert.ToString(reader["AddressLine2"]),
                        Country = Convert.ToString(reader["Country"]),
                        State = Convert.ToString(reader["State"]),
                        City = Convert.ToString(reader["City"]),
                        Area = Convert.ToString(reader["Area"]),
                        Pincode = Convert.ToString(reader["Pincode"])
                    };
                    patientList.Add(patient);
                }
           }
         
            con.Close();
            return patientList;
        }

        [HttpGet]
        [Route("GetPatientByMrNo")]
        //[Route("[controller]")]
        public List<PatientList> GetPatientByMrNo(string MedicalRecordNo)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            var patientList = new List<PatientList>();

            SqlCommand com = new SqlCommand("api_GetPatientByMrNo", con);
            com.CommandType = CommandType.StoredProcedure;
            
            com.Parameters.AddWithValue("@MrNo", MedicalRecordNo);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var patient = new PatientList
                    {
                        PatientId = Convert.ToString(reader["PatientId"]),
                        ClinicName = Convert.ToString(reader["ClinicName"]),
                        RegistrationDateTime = Convert.ToString(reader["RegistrationDateTime"]),
                        PatientName = Convert.ToString(reader["PatientName"]),
                        Gender = Convert.ToString(reader["Gender"]),
                        MedicalRecordNo = Convert.ToString(reader["MedicalRecordNo"]),
                        ContactNo = Convert.ToString(reader["ContactNo"]),
                        EmailId = Convert.ToString(reader["EmailId"]),
                        AddressLine1 = Convert.ToString(reader["AddressLine1"]),
                        AddressLine2 = Convert.ToString(reader["AddressLine2"]),
                        Country = Convert.ToString(reader["Country"]),
                        State = Convert.ToString(reader["State"]),
                        City = Convert.ToString(reader["City"]),
                        Area = Convert.ToString(reader["Area"]),
                        Pincode = Convert.ToString(reader["Pincode"])
                    };
                    patientList.Add(patient);
                }
            }
            con.Close();
            return patientList;
        }
    }
}