using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class RefundController : Controller
    {
        public readonly IConfiguration _configuration;

        public RefundController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetRefundList")]
        //[Route("[controller]")]
        public List<RefundList> GetRefundList(DateTime? ReceiptDate, long? ClinicId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            var RefundList = new List<RefundList>();

            SqlCommand com = new SqlCommand("api_GetRefunds", con);
            com.CommandType = CommandType.StoredProcedure;
            if (ReceiptDate == null)
                ReceiptDate = DateTime.Now;

            if (ClinicId == null)
                ClinicId = 0;

            com.Parameters.AddWithValue("@RefundDate", ReceiptDate);
            com.Parameters.AddWithValue("@UnitId", ClinicId);

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Refund = new RefundList
                    {
                        RefundId = Convert.ToString(reader["RefundId"]),
                        ClinicName = Convert.ToString(reader["ClinicName"]),
                        RefundDate = Convert.ToString(reader["RefundDateTime"]),
                        RefundType = Convert.ToString(reader["RefundType"]),
                        ReferenceNo = Convert.ToString(reader["RefundNo"]),
                        MedicalRecordNo = Convert.ToString(reader["MedicalRecordNo"]),
                        PatientName = Convert.ToString(reader["PatientName"]),
                        RefundAmount = Convert.ToDecimal(reader["Amount"]),
                        RefundUserName = Convert.ToString(reader["RefundByUser"])
                    };
                    RefundList.Add(Refund);
                }
            }
            con.Close();
            return RefundList;
        }

        [HttpGet]
        [Route("GetPaymentDetailsByRefundId")]
        public List<RefundtPaymentDetails> GetPaymentDetailsByRefundId(string ReceiptId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var refundtPaymentDetails = new List<RefundtPaymentDetails>();

            SqlCommand com = new SqlCommand("api_GetRefundPaymentDetails", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@RefundId", ReceiptId);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var receiptPayment = new RefundtPaymentDetails
                    {
                        ReceiptId = Convert.ToString(reader["ReceiptId"]),
                        PaymentMode = Convert.ToString(reader["PaymentMode"]),
                        ReferenceNo = Convert.ToString(reader["ReferenceNo"]),
                        ReferenceDate = Convert.ToString(reader["ReferenceDate"]),
                        Amount = Convert.ToDecimal(reader["PaidAmount"])
                    };
                    refundtPaymentDetails.Add(receiptPayment);
                }

                return refundtPaymentDetails;
            }

        }

    }
}

