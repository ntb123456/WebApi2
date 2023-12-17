using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class ServiceMasterController : Controller
    {
       
        public readonly IConfiguration _configuration;

        public ServiceMasterController (IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        [HttpPost]
        //[Route("[controller]")]
        [Route("CreateService")]
        public int CreateService(ServiceMaster _serviceMaster)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            
            if (con.State == ConnectionState.Closed)
                con.Open();
            
            SqlCommand com = new SqlCommand("api_CreateService", con);
            com.CommandType = CommandType.StoredProcedure;

            
            com.Parameters.AddWithValue("@ServiceCode", _serviceMaster.ServiceCode);
            com.Parameters.AddWithValue("@SpecializationName", _serviceMaster.SpecializationName);
            com.Parameters.AddWithValue("@SubSpecializationName", _serviceMaster.SubSpecializationName);
            com.Parameters.AddWithValue("@ServiceName", _serviceMaster.ServiceName);
            com.Parameters.AddWithValue("@LifeHISServiceId", _serviceMaster.HISServiceId);
            
            try
            {
                com.Parameters.Add("@ResultStatus", SqlDbType.Int).Direction = ParameterDirection.Output;
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
