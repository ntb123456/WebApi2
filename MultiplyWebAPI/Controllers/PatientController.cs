using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;


namespace MultiplyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class PatientController : Controller
    {
        public readonly IConfiguration _configuration;
        public PatientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("CreatePatient")]
        public int CreatePatient(Patient _patient)
        {
            int result = 0;

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand com = new SqlCommand("usp_AddVisitFromHIS", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@PatientCategoryId", _patient.PatientCategoryId);
            com.Parameters.AddWithValue("@center_id", _patient.UnitId);
            com.Parameters.AddWithValue("@mr_no", _patient.RegNo);
            com.Parameters.AddWithValue("@dateofbirth", _patient.DateOfBirth);
            com.Parameters.AddWithValue("@full_name", _patient.PatientName);
            com.Parameters.AddWithValue("@reg_date", _patient.RegDate);
            com.Parameters.AddWithValue("@patient_gender", _patient.Gender);
            com.Parameters.AddWithValue("@visit_datetime", _patient.VisitDate);
            com.Parameters.AddWithValue("@age", _patient.Age);
            com.Parameters.AddWithValue("@patient_id", _patient.PatientId);
            com.Parameters.AddWithValue("@doctor_id", _patient.DoctorId);
            com.Parameters.AddWithValue("@email_id", _patient.EmailId);
            com.Parameters.AddWithValue("@patient_phone", _patient.MobileNo);
            com.Parameters.AddWithValue("@patient_address", _patient.Address);
            com.Parameters.AddWithValue("@first_name", _patient.FirstName);
            com.Parameters.AddWithValue("@middle_name", _patient.MiddleName);
            com.Parameters.AddWithValue("@last_name", _patient.LastName);
            com.Parameters.AddWithValue("@salutation", _patient.Prefix);
            com.Parameters.AddWithValue("@doctor_name", _patient.DoctorName);
            com.Parameters.AddWithValue("@his_visitid", _patient.HisVisitId);
            com.Parameters.AddWithValue("@his_visitReason", _patient.ReasonForVisit);
            com.Parameters.AddWithValue("@estimated_dateofbirth", _patient.EstimatedDateOfBirth);
       
            com.Parameters.AddWithValue("@partner_mr_no", _patient.partner_mr_no);
            com.Parameters.AddWithValue("@partner_dateofbirth", _patient.partner_dateofbirth);
            com.Parameters.AddWithValue("@partner_gender", _patient.partner_gender);
            com.Parameters.AddWithValue("@partner_age", _patient.partner_age);
            com.Parameters.AddWithValue("@partner_email_id", _patient.partner_email_id);
            com.Parameters.AddWithValue("@partner_phone", _patient.partner_phone);
            com.Parameters.AddWithValue("@partner_address", _patient.partner_address);
            com.Parameters.AddWithValue("@partner_first_name", _patient.partner_first_name);
            com.Parameters.AddWithValue("@partner_middle_name", _patient.partner_middle_name);
            com.Parameters.AddWithValue("@partner_last_name", _patient.partner_last_name);
            com.Parameters.AddWithValue("@partner_salutation", _patient.partner_prefix);
            com.Parameters.AddWithValue("@partner_estimated_dateofbirth", _patient.partner_estimated_dateofbirth);
            
            com.Parameters.AddWithValue("@partner_estimated_dateofbirth", _patient.partner_his_visitDate); 
            com.Parameters.AddWithValue("@partner_his_visitid", _patient.partner_his_visitId);
            com.Parameters.AddWithValue("@partner_his_visitReason", _patient.partner_ReasonForVisit);

            try
            {
                //com.Parameters.Add("@ResultStatus", SqlDbType.Int).Direction = ParameterDirection.Output;
                //com.ExecuteNonQuery();
                //result = 200;
                //return result;

                SqlParameter outputParam = new SqlParameter("@ResultStatus", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                com.Parameters.Add(outputParam);
                com.ExecuteNonQuery();
                result = Convert.ToInt32(outputParam.Value);
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
