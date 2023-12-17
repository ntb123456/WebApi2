using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using System.Data;

namespace MultiplyWebAPI.Controllers
{
    [ApiController]
    public class AccessTokenController : Controller
    {
        public readonly IConfiguration _configuration;

        public AccessTokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetUserClinics")]
        public List<UserClinics> GetUserClinics(string LoginName)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var userClinics = new List<UserClinics>();

            SqlCommand com = new SqlCommand("api_GetUserClinics", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@LoginName", LoginName);

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var userClinic = new UserClinics
                    {
                        ClinicId  = Convert.ToInt32(reader["UnitId"]),
                        ClinicName = Convert.ToString(reader["ClinicName"])
                    };
                    userClinics.Add(userClinic);
                }

                return userClinics;
            }

        }

        [HttpPost]
        [Route("ValidateUser")]
        public async Task<IActionResult> ValidateUser(string strUserName, string strUserPassword)
        {

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand com = new SqlCommand("api_AuthenticateUser", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@UserName", strUserName);
            com.Parameters.AddWithValue("@UserPassword", strUserPassword);
           
            SqlParameter outputParameterUserId = new SqlParameter("@UserId", SqlDbType.BigInt);
            outputParameterUserId.Direction = ParameterDirection.Output;
            com.Parameters.Add(outputParameterUserId);

            com.ExecuteNonQuery();
           
            var _userData = new UserModel
            {
              
              UserId = Convert.ToInt64(outputParameterUserId.Value),
              UserName = strUserName,
              UserPassword = strUserPassword
            };
           
            
            con.Close();


            if (_userData.UserId != 0)
            {
               _userData.UserMessage = "Login Success";

                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", _userData.UserId.ToString()),
                    new Claim("UserName", _userData.UserName),
                    new Claim("UserMessage", _userData.UserMessage)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);


                _userData.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(_userData);
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }

    }
}
