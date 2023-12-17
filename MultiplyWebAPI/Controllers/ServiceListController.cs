using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{

    [Authorize]
    [ApiController]
    public class ServiceListController : Controller
    {
        public readonly IConfiguration _configuration;

        public ServiceListController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetAllServiceList")]
        public List<ServiceList> GetAllServiceList()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var serviceList = new List<ServiceList>();

            SqlCommand com = new SqlCommand("api_GetServiceNames", con);
            com.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var service = new ServiceList
                    {
                        ServiceGroupName = Convert.ToString(reader["ServiceGroup"]),
                        ServiceName  = Convert.ToString(reader["ServiceName"])
                    };
                    serviceList.Add(service);
                }

                return serviceList;
            }

        }
    }
}
