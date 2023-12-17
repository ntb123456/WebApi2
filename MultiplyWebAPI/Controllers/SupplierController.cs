using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class SupplierController : Controller
    {
        public readonly IConfiguration _configuration;

        public SupplierController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetSupplierList")]
        public List<SupplierList> GetAllServiceList()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var SupplierList = new List<SupplierList>();

            SqlCommand com = new SqlCommand("api_GetSupplierList", con);
            com.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Supplier = new SupplierList
                    {
                        SupplierCode = Convert.ToString(reader["SupplierCode"]),
                        SupplierName = Convert.ToString(reader["SupplierName"]),
                        Address = Convert.ToString(reader["Address"]),
                        Country = Convert.ToString(reader["Country"]),
                        State = Convert.ToString(reader["State"]),
                        City = Convert.ToString(reader["City"]),
                        Pincode = Convert.ToString(reader["Pincode"]),
                        ContactPerson = Convert.ToString(reader["ContactPerson"]),
                        EmailId = Convert.ToString(reader["EmailId"]),
                        ContactNo = Convert.ToString(reader["ContactNo"]),
                        GSTINNo = Convert.ToString(reader["GSTINNo"])
                    };
                    SupplierList.Add(Supplier);
                }

                return SupplierList;
            }

        }
    }
}
