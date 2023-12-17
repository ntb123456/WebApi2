using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    public class FPPatientController : Controller
    {

        public readonly IConfiguration _configuration;

        public FPPatientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetFPPatientList")]
        public List<FPPatient> GetFPPatientList()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ClinicDBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var FPPatientList = new List<FPPatient>();

            SqlCommand com = new SqlCommand("api_GetFPPatients", con);
            com.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var FPPatient = new FPPatient
                    {
                        PatientId  = Convert.ToInt64(reader["PatientId"]),
                        PatientName  = Convert.ToString(reader["PatientName"]),
                        PatientAge = Convert.ToInt32(reader["PatientAge"]),
                        EmailId = Convert.ToString(reader["EmailId"]),
                    };
                    FPPatientList.Add(FPPatient);
                }

                return FPPatientList;
            }

        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetFPPatientId")]
        public List<FPPatient> GetFPPatientById(long PatientId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ClinicDBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var FPPatientList = new List<FPPatient>();

            SqlCommand com = new SqlCommand("api_GetFPPatientById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PatientId", PatientId);

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var FPPatient = new FPPatient
                    {
                        PatientId = Convert.ToInt64(reader["PatientId"]),
                        PatientName = Convert.ToString(reader["PatientName"]),
                        PatientAge = Convert.ToInt32(reader["PatientAge"]),
                        EmailId = Convert.ToString(reader["EmailId"]),
                    };
                    FPPatientList.Add(FPPatient);
                }

                return FPPatientList;
            }
        }

        [HttpPost]
        //[Route("[controller]")]
        [Route("CreateFPPatient")]
        public int CreatePatient(FPPatient fPPatient)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ClinicDBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand com = new SqlCommand("fp_api_CreatePatient", con);
            com.CommandType = CommandType.StoredProcedure;


            com.Parameters.AddWithValue("@PatientName", fPPatient.PatientName);
            com.Parameters.AddWithValue("@PatientAge", fPPatient.PatientAge);
            com.Parameters.AddWithValue("@EmailId", fPPatient.EmailId);
           
            try
            {
                com.Parameters.Add("@PatientId", SqlDbType.BigInt).Direction = ParameterDirection.Output;
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
    }
}

