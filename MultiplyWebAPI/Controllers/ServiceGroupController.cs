using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{

    [Authorize]
    [ApiController]
    public class ServiceGroupController : Controller
    {
        public readonly IConfiguration _configuration;

        public ServiceGroupController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetAllServiceGroups")]
        public List<ServiceGroup> GetAllServiceGroups()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var serviceGroupList = new List<ServiceGroup>();

            SqlCommand com = new SqlCommand("api_GetServiceGroups", con);
            com.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var serviceGroup = new ServiceGroup
                    {
                        ServiceGroupName = Convert.ToString(reader["ServiceGroup"])
                    };
                     serviceGroupList.Add(serviceGroup);
                }

                return serviceGroupList;
            }
                        
        }
  
    }
}
