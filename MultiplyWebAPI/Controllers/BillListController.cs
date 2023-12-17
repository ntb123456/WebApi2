using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class BillListController : Controller
    {
        public readonly IConfiguration _configuration;

        public BillListController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetBillList")]
        public List<BillList> GetBillList(DateTime? billDate)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            var patientBillList = new List<BillList>();

            SqlCommand com = new SqlCommand("api_GetBills", con);
            com.CommandType = CommandType.StoredProcedure;
            if (billDate == null)
                billDate = DateTime.Now;

            com.Parameters.AddWithValue("@BillDate", billDate);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var patientBill = new BillList
                    {
                        BillId = Convert.ToString(reader["BillId"]),
                        ClinicName =  Convert.ToString(reader["ClinicName"]),
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
                    patientBillList.Add(patientBill);
                }

            }
            con.Close();
            return patientBillList;
        }

        [HttpGet]
        [Route("GetServiceDetailsByBillId")]
        public List<BillServiceDetails> GetServiceDetailsByBillNo(string billId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var billServiceDetails = new List<BillServiceDetails>();

            SqlCommand com = new SqlCommand("api_GetServiceDetailsByBillNo", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BillId", billId);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var billService = new BillServiceDetails
                    {
                        BillId = Convert.ToString(reader["BillId"]),
                        ServiceDateTime = Convert.ToString(reader["ServiceDateTime"]),
                        ServiceName = Convert.ToString(reader["ServiceName"]),
                        ServiceDoctorName = Convert.ToString(reader["ServiceDoctorName"]),
                        ServiceRate = Convert.ToDecimal(reader["ServiceRate"]),
                        ServiceQuantity = Convert.ToInt32(reader["ServiceQuantity"]),
                        ServiceTotalAmount = Convert.ToDecimal(reader["ServiceTotalAmount"]),
                        ServiceDiscountAmount = Convert.ToDecimal(reader["ServiceDiscountAmount"]),
                        ServiceTaxAmount = Convert.ToDecimal(reader["ServiceTaxAmount"]),
                        ServiceNetAmount = Convert.ToDecimal(reader["ServiceNetAmount"]),
                        ServicePaidAmount = Convert.ToDecimal(reader["ServicePaidAmount"])
                    };
                    billServiceDetails.Add(billService);
                }

                return billServiceDetails;
            }
        }

        [HttpGet]
        [Route("GetServiceGroupDetailsByBillId")]
        public List<BillServiceGroupDetails> GetServiceGroupDetailsByBillId(string billId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var billServiceGroupDetails = new List<BillServiceGroupDetails>();

            SqlCommand com = new SqlCommand("api_GetServiceGroupDetailsByBillNo", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BillId", billId);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var billServiceGroup = new BillServiceGroupDetails
                    {
                        BillId = Convert.ToString(reader["BillId"]),
                        ServiceGroup = Convert.ToString(reader["ServiceGroup"]),
                        Narration = Convert.ToString(reader["Narration"]),
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        DiscountAmount = Convert.ToDecimal(reader["DiscountAmount"]),
                        NetAmount = Convert.ToDecimal(reader["NetAmount"])
                    };
                    billServiceGroupDetails.Add(billServiceGroup);
                }

                return billServiceGroupDetails;
            }
        }

        [HttpGet]
        [Route("GetPaymentDetailsByBillId")]
        public List<BillPaymentDetails> GetPaymentDetailsByBillNo(string billId)
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

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetAllPatientBillList")]
        public List<PatientBillList> GetAllPatientBillList(DateTime? billDate)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            var patientBillList = new List<PatientBillList>();

            SqlCommand com = new SqlCommand("api_GetBills", con);
            com.CommandType = CommandType.StoredProcedure;
            if (billDate == null)
                billDate = DateTime.Now;

            com.Parameters.AddWithValue("@BillDate", billDate);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var patientBill = new PatientBillList
                    {
                        BillId =Convert.ToString(reader["BillId"]),
                        BillNo = Convert.ToString(reader["BillNo"]),
                        BillDateTime = Convert.ToString(reader["BillDateTime"]),
                        MedicalRecordNo = Convert.ToString(reader["MedicalRecordNo"]),
                        PatientName = Convert.ToString(reader["PatientName"]),
                        BillType = Convert.ToString(reader["BillType"]),
                        BillCategory = Convert.ToString(reader["BillCategory"]),
                        BillUser = Convert.ToString(reader["BillUser"]),
                        TotalBillAmount= Convert.ToDecimal(reader["TotalBillAmount"]),
                        DiscountAmount= Convert.ToDecimal(reader["DiscountAmount"]),
                        TaxAmount = Convert.ToDecimal(reader["TaxAmount"]),
                        NetBillAmount = Convert.ToDecimal(reader["NetBillAmount"]),
                        PaidBillAmount = Convert.ToDecimal(reader["PaidBillAmount"])
                    };
                    patientBillList.Add(patientBill);
                }

            }

            foreach (var patientBill in patientBillList)
            {
                patientBill.BillServiceDetails = GetBillServiceDetailsByBillId(con, patientBill.BillId);
            }

            foreach (var patientBill in patientBillList)
            {
                patientBill.BillPaymentDetails  = GetBillPaymentDetailsByBillId(con, patientBill.BillId);
            }

            con.Close();
            return patientBillList;
        }

        private List<BillServiceDetails> GetBillServiceDetailsByBillId(SqlConnection connection, string billId)
        {
            var billServiceDetails = new List<BillServiceDetails>();

            SqlCommand com = new SqlCommand("api_GetBillServiceDetails", connection);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BillId", billId);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var billService = new BillServiceDetails
                    {
                        BillId = Convert.ToString(reader["BillId"]),
                        ServiceDateTime = Convert.ToString(reader["ServiceDateTime"]),
                        ServiceName = Convert.ToString(reader["ServiceName"]),
                        ServiceDoctorName = Convert.ToString(reader["ServiceDoctorName"]),
                        ServiceRate = Convert.ToDecimal(reader["ServiceRate"]),
                        ServiceQuantity = Convert.ToInt32(reader["ServiceQuantity"]),
                        ServiceTotalAmount = Convert.ToDecimal(reader["ServiceTotalAmount"]),
                        ServiceDiscountAmount = Convert.ToDecimal(reader["ServiceDiscountAmount"]),
                        ServiceTaxAmount = Convert.ToDecimal(reader["ServiceTaxAmount"]),
                        ServiceNetAmount = Convert.ToDecimal(reader["ServiceNetAmount"]),
                        ServicePaidAmount = Convert.ToDecimal(reader["ServicePaidAmount"])
                    };
                    billServiceDetails.Add(billService);
                }

                return billServiceDetails;
            }
        }
        private List<BillPaymentDetails> GetBillPaymentDetailsByBillId(SqlConnection connection, string billId)
        {
            var billPaymentDetails = new List<BillPaymentDetails>();

            SqlCommand com = new SqlCommand("api_GetBillPaymentDetails", connection);
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
                        Amount = Convert.ToDecimal(reader["PaidAmount"])
                    };
                    billPaymentDetails.Add(billPayment);
                }

                return billPaymentDetails;
            }

        }
    }
}
