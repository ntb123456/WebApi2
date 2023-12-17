using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class PharmacyBillController : Controller
    {
        public readonly IConfiguration _configuration;

        public PharmacyBillController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetPharmacyBillList")]
        public List<PharmacyBillList> GetPharmacyBillList(DateTime? billDate)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            var PharmacyBillList = new List<PharmacyBillList>();

            SqlCommand com = new SqlCommand("api_GetOPDPharmacyBills", con);
            com.CommandType = CommandType.StoredProcedure;
            if (billDate == null)
                billDate = DateTime.Now;

            com.Parameters.AddWithValue("@BillDate", billDate);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var PharmacyBill= new PharmacyBillList
                    {
                        BillId = Convert.ToString(reader["BillId"]),
                        ClinicName = Convert.ToString(reader["ClinicName"]),
                        BillNo = Convert.ToString(reader["BillNo"]),
                        BillDateTime = Convert.ToString(reader["BillDateTime"]),
                        MedicalRecordNo = Convert.ToString(reader["MedicalRecordNo"]),
                        PatientName = Convert.ToString(reader["PatientName"]),
                        BillType = Convert.ToString(reader["BillType"]),
                        BillCategory = Convert.ToString(reader["BillCategory"]),
                        BillUser = Convert.ToString(reader["BillUser"]),
                        TotalBillAmount = Convert.ToDecimal(reader["TotalBillAmount"]),
                        DiscountAmount = Convert.ToDecimal(reader["DiscountAmount"]),
                        TaxAmount = Convert.ToDecimal(reader["TaxAmount"]),
                        NetBillAmount = Convert.ToDecimal(reader["NetBillAmount"]),
                    };
                    PharmacyBillList.Add(PharmacyBill);
                }

            }
            con.Close();
            return PharmacyBillList;
        }

        [HttpGet]
        [Route("GetPharmacyItemsByBillId")]
        public List<PharmacyBillItemDetails> GetPharmacyItemsByBillNo(string billId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var PharmacyBillItemDetails = new List<PharmacyBillItemDetails>();

            SqlCommand com = new SqlCommand("api_GetPharmacyBillItems", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BillId", billId);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var PharmacyBillItem = new PharmacyBillItemDetails
                    {
                        BillId = Convert.ToString(reader["BillId"]),
                        ItemName = Convert.ToString(reader["ItemName"]),
                        ItemBatchCode = Convert.ToString(reader["BatchCode"]),
                        ItemExpiryDate = Convert.ToString(reader["ExpiryDate"]),
                        ItemMRP = Convert.ToDecimal(reader["MRP"]),
                        ItemQuantity = Convert.ToInt32(reader["Quantity"]),
                        ItemUOM = Convert.ToString(reader["UOM"]),
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        ItemDiscountAmount = Convert.ToDecimal(reader["ConcessionAmount"]),
                        SGSTPercentage = Convert.ToDecimal(reader["SGSTPercentage"]),
                        SGSTAmount = Convert.ToDecimal(reader["SGSTAmount"]),
                        CGSTPercentage = Convert.ToDecimal(reader["CGSTPercentage"]),
                        CGSTAmount = Convert.ToDecimal(reader["CGSTAmount"]),
                        IGSTPercentage = Convert.ToDecimal(reader["IGSTPercentage"]),
                        IGSTAmount = Convert.ToDecimal(reader["IGSTAmount"]),
                        NetAmount = Convert.ToDecimal(reader["NetAmount"]),
                        TotalBillAmount = Convert.ToDecimal(reader["TotalBillAmount"]),
                        NetBillAmount = Convert.ToDecimal(reader["NetBillAmount"]),
                        RoundOffAmount = Convert.ToDecimal(reader["RoundOff"])
                    };
                    PharmacyBillItemDetails.Add(PharmacyBillItem);
                }

                return PharmacyBillItemDetails;
            }
        }

        [HttpGet]
        [Route("GetPharmacyBillGSTDetails")]
        public List<PharmacyBillGSTDetails> GetPharmacyBillGSTDetailsByBillNo(string billId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var PharmacyBillGSTDetails = new List<PharmacyBillGSTDetails>();

            SqlCommand com = new SqlCommand("api_GetPharmacyBillGSTDetails", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BillId", billId);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var PharmacyGSTItem = new PharmacyBillGSTDetails
                    {
                        BillId = Convert.ToString(reader["BillId"]),
                        SGSTPercentage = Convert.ToDecimal(reader["SGSTPercentage"]),
                        SGSTAmount = Convert.ToDecimal(reader["SGSTAmount"]),
                        CGSTPercentage = Convert.ToDecimal(reader["CGSTPercentage"]),
                        CGSTAmount = Convert.ToDecimal(reader["CGSTAmount"])
                    };
                    PharmacyBillGSTDetails.Add(PharmacyGSTItem);
                }

                return PharmacyBillGSTDetails;
            }
        }

        [HttpGet]
        [Route("PaymentDetailsByBillId")]
        public List<BillPaymentDetails> GetPaymentDetailsByBillId(string billId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            var billPaymentDetails = new List<BillPaymentDetails>();

            SqlCommand com = new SqlCommand("api_GetPaymentDetailsByBillNo", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BillId", billId);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var billPayment = new BillPaymentDetails
                    {
                        BillId = Convert.ToString(reader["BillId"]),
                        PaymentMode = Convert.ToString(reader["PaymentMode"]),
                        ReferenceNo = Convert.ToString(reader["ReferenceNo"]),
                        ReferenceDate = Convert.ToString(reader["ReferenceDate"]),
                        Amount = Convert.ToDecimal(reader["PaidAmount"]),
                        AdvanceNo = Convert.ToString(reader["AdvanceNo"]),
                        AdvanceDateTime = Convert.ToString(reader["AdvanceDate"])
                    };
                    billPaymentDetails.Add(billPayment);
                }
                return billPaymentDetails;
            }

        }
    }
}
