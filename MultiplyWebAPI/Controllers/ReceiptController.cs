using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class ReceiptController : Controller
    {
        public readonly IConfiguration _configuration;

        public ReceiptController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetReceiptList")]
        //[Route("[controller]")]
        public List<ReceiptList> GetReceiptList(DateTime? ReceiptDate, long? ClinicId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            var ReceiptList = new List<ReceiptList>();

            SqlCommand com = new SqlCommand("api_GetReceipts", con);
            com.CommandType = CommandType.StoredProcedure;
            if (ReceiptDate == null)
                ReceiptDate = DateTime.Now;

            if (ClinicId == null)
                ClinicId = 0;

            com.Parameters.AddWithValue("@ReceiptDate", ReceiptDate);
            com.Parameters.AddWithValue("@UnitId", ClinicId);

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Receipt = new ReceiptList
                    {
                        ReceiptId  = Convert.ToString(reader["ReceiptId"]),
                        ClinicName = Convert.ToString(reader["ClinicName"]),
                        ReceiptDate  = Convert.ToString(reader["ReceiptDate"]),
                        ReceiptType = Convert.ToString(reader["ReceiptType"]),
                        ReferenceNo = Convert.ToString(reader["ReferenceNo"]),
                        MedicalRecordNo = Convert.ToString(reader["MedicalRecordNo"]),
                        PatientName = Convert.ToString(reader["PatientName"]),
                        ReceiptAmount = Convert.ToDecimal(reader["ReceiptAmount"])
                    };
                    ReceiptList.Add(Receipt);
                }
            }
            con.Close();
            return ReceiptList;
        }

        [HttpGet]
        [Route("GetPaymentDetailsByReceiptId")]
        public List<ReceiptPaymentDetails> GetPaymentDetailsByAdvanceId(string ReceiptId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var ReceiptPaymentDetails = new List<ReceiptPaymentDetails>();

            SqlCommand com = new SqlCommand("api_GetReceiptPaymentDetails", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@ReceiptId", ReceiptId);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var receiptPayment = new ReceiptPaymentDetails
                    {
                        ReceiptId = Convert.ToString(reader["ReceiptId"]),
                        PaymentMode = Convert.ToString(reader["PaymentMode"]),
                        ReferenceNo = Convert.ToString(reader["ReferenceNo"]),
                        ReferenceDate = Convert.ToString(reader["ReferenceDate"]),
                        Amount = Convert.ToDecimal(reader["PaidAmount"]),
                        AdvanceNo = Convert.ToString(reader["AdvanceNo"])
                    };
                    ReceiptPaymentDetails.Add(receiptPayment);
                }

                return ReceiptPaymentDetails;
            }

        }

    }
}
