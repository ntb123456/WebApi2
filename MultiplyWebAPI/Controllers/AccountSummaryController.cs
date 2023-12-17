 using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class AccountSummaryController : Controller
    {
        public readonly IConfiguration _configuration;

        public AccountSummaryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetAccountSummaryDetails")]
        public List<AccountCollectionData> GetAccountSummaryDetails(DateTime? accountDate)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            var accountSummaryList = new List<AccountCollectionData>();
            if (con.State == ConnectionState.Closed)
                con.Open();

            if (accountDate == null)
                accountDate = DateTime.Now;

            SqlCommand com = new SqlCommand("api_GetAccountData", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@AccountDate", accountDate);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var accountSummary = new AccountCollectionData
                    {
                        AccountDate = Convert.ToString(reader["Date"]),
                        ClinicId = Convert.ToInt64(reader["ClinicId"]),
                        Clinic = Convert.ToString(reader["ClinicName"]),
                        ClinicLocation = Convert.ToString(reader["ClinicLocation"]),
                        Branch = Convert.ToString(reader["CostCentre"]),
                        BranchId = Convert.ToInt64(reader["CostCentreId"])
                    };
                    accountSummaryList.Add(accountSummary);
                }
            }

            foreach (var accountSummary in accountSummaryList)
            {
                accountSummary.AccountData = GetAccountDetailsByDate(con, accountDate, accountSummary.ClinicId, accountSummary.BranchId);
            }
            con.Close();
            return accountSummaryList;
        }

        private List<AccountData> GetAccountDetailsByDate(SqlConnection connection, DateTime? accountDate, long ClinicId, long CostCentreId)
        {
            var _accountDetails = new List<AccountData>();

            SqlCommand com = new SqlCommand("api_GetAccountDataDetails", connection);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@AccountDate", accountDate);
            com.Parameters.AddWithValue("@ClinicId", ClinicId);
            com.Parameters.AddWithValue("@CostCentreId", CostCentreId);

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var _account = new AccountData
                    {
                        AccountHead = Convert.ToString(reader["AccountHead"]),
                        Amount = Convert.ToDouble(reader["Amount"])
                    };
                    _accountDetails.Add(_account);
                }

                return _accountDetails;
            }
        }
    }
}