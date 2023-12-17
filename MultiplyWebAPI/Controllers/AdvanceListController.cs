using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class AdvanceListController : Controller
    {
        public readonly IConfiguration _configuration;

        public AdvanceListController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        //[Route("[controller]")]
        [Route("GetAdvanceList")]
        public List<AdvanceList> GetAdvanceList(DateTime? advanceDate)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            var AdvanceList = new List<AdvanceList>();

            SqlCommand com = new SqlCommand("api_GetAdvances", con);
            com.CommandType = CommandType.StoredProcedure;
            if (advanceDate == null)
                advanceDate = DateTime.Now;

            com.Parameters.AddWithValue("@AdvanceDate", advanceDate);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var patientAdvance = new AdvanceList
                    {
                        AdvanceId = Convert.ToString(reader["AdvanceId"]),
                        ClinicName = Convert.ToString(reader["ClinicName"]),
                        AdvanceDateTime = Convert.ToString(reader["AdvanceDateTime"]),
                        AdvanceNo = Convert.ToString(reader["AdvanceNo"]),
                        MedicalRecordNo = Convert.ToString(reader["MedicalRecordNo"]),
                        PatientName = Convert.ToString(reader["PatientName"]),

                        AdvanceAmount = Convert.ToDecimal(reader["AdvanceAmount"]),
                        AdvanceRemark = Convert.ToString(reader["AdvanceRemarks"]),
                        CollectedByUser = Convert.ToString(reader["User"])

                    };
                    AdvanceList.Add(patientAdvance);
                }

            }
            con.Close();
            return AdvanceList;
        }

        [HttpGet]
        [Route("GetPaymentDetailsByAdvanceId")]
        public List<AdvancePaymentDetails> GetPaymentDetailsYyAdvanceId(string advanceId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var AdvancePaymentDetails = new List<AdvancePaymentDetails>();

            SqlCommand com = new SqlCommand("api_GetAdvancePaymentDetails", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@AdvanceId", advanceId);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var patientAdvancePayment = new AdvancePaymentDetails
                    {
                        AdvanceId = Convert.ToString(reader["AdvanceId"]),
                        PaymentMode = Convert.ToString(reader["PaymentMode"]),
                        ReferenceNo = Convert.ToString(reader["ReferenceNo"]),
                        ReferenceDate = Convert.ToString(reader["ReferenceDate"]),
                        Amount = Convert.ToDecimal(reader["PaidAmount"])
                    };
                    AdvancePaymentDetails.Add(patientAdvancePayment);
                }

                return AdvancePaymentDetails;
            }

        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetAllPatientAdvanceList")]
        public List<PatientAdvanceList> GetAllPatientAdvanceList(DateTime? advanceDate)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            var patientAdvanceList = new List<PatientAdvanceList>();

            SqlCommand com = new SqlCommand("api_GetAdvances", con);
            com.CommandType = CommandType.StoredProcedure;
            if (advanceDate == null)
                advanceDate = DateTime.Now;

            com.Parameters.AddWithValue("@AdvanceDate", advanceDate);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var patientAdvance = new PatientAdvanceList
                    {
                        AdvanceId = Convert.ToString(reader["AdvanceId"]),
                        AdvanceDateTime = Convert.ToString(reader["AdvanceDateTime"]),
                        AdvanceNo = Convert.ToString(reader["AdvanceNo"]),
                        MedicalRecordNo = Convert.ToString(reader["MedicalRecordNo"]),
                        PatientName = Convert.ToString(reader["PatientName"]),

                        AdvanceAmount = Convert.ToDecimal(reader["AdvanceAmount"]),
                        AdvanceRemark = Convert.ToString(reader["AdvanceRemarks"]),
                        CollectedByUser = Convert.ToString(reader["User"])

                    };
                    patientAdvanceList.Add(patientAdvance);
                }
               
            }
           
            foreach (var patientAdvance in patientAdvanceList)
            {
                patientAdvance.AdvancePaymentDetails = GetAdvancePaymentDetailsByAdvanceId(con, patientAdvance.AdvanceId);
            }
            con.Close();
            return patientAdvanceList;
        }

        private List<AdvancePaymentDetails> GetAdvancePaymentDetailsByAdvanceId(SqlConnection connection, string advanceId)
        {
            var AdvancePaymentDetails = new List<AdvancePaymentDetails>();

            SqlCommand com = new SqlCommand("api_GetAdvancePaymentDetails", connection);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@AdvanceId", advanceId);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var patientAdvancePayment = new AdvancePaymentDetails
                    {
                        AdvanceId = Convert.ToString(reader["AdvanceId"]),
                        PaymentMode = Convert.ToString(reader["PaymentMode"]),
                        ReferenceNo = Convert.ToString(reader["ReferenceNo"]),
                        ReferenceDate = Convert.ToString(reader["ReferenceDate"]),
                        Amount = Convert.ToDecimal(reader["PaidAmount"])
                    };
                    AdvancePaymentDetails.Add(patientAdvancePayment);
                }

                return AdvancePaymentDetails;
            }


        }
    }
}
